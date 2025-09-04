using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;

    InputAction moveAction;
    Rigidbody2D myRigidbody;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;

    Vector2 moveVector;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    float flipCount;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
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
            flipCount++;
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
}
