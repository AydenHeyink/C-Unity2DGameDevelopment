using UnityEngine;

public class CharSelect : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;

    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }
}
