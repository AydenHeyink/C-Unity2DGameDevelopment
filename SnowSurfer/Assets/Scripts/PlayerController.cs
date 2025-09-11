using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] ParticleSystem powerupParticles;
    [SerializeField] ScoreManager scoreManager;

    InputAction moveAction;
    Rigidbody2D myRigidbody;
    SurfaceEffector2D surfaceEffector2D;

    Vector2 moveVector;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int activePowerupCount;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
        {
            myRigidbody.AddTorque(torqueAmount);
        }

        else if (moveVector.x > 0)
        {
            myRigidbody.AddTorque(-torqueAmount);
        }
    }

    private void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation > 360 || totalRotation < -360)
        {
            totalRotation = 0;
            scoreManager.AddScore(100);
        }
        previousRotation= currentRotation;
    }

    public void DisableController()
    {
        canControlPlayer= false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticles.Play();
        activePowerupCount++;
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }
        else if(powerup.GetPowerupType() == "torque")
        {
            torqueAmount+= powerup.GetValueChange();
        }
    }

    public void DeactivatePowerup(PowerupSO powerup)
    {
        activePowerupCount--;
        
        if (activePowerupCount == 0)
        {
            powerupParticles.Stop();
        }

        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }
    }
}
