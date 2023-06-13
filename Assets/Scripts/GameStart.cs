using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public string objectTag = "ObjectOFF";
    public Canvas startCanvas;
    public GameObject[] objectON;
    public GameObject startCheck;
    public GameObject endCheck;
    public GameObject gameOver;

    public GameObject gameOverCheck;
    private bool objectsEnabled = false;
    public PlateScript plate;
    public Text ScoreText;

    private void Start()
    {
       
    }

    public void ToggleObjects()

    {
        objectsEnabled = !objectsEnabled;


        foreach (GameObject obj in objectON)
        {
            obj.SetActive(objectsEnabled);
        }
        startCanvas.gameObject.SetActive(!objectsEnabled);
        startCheck.SetActive(!objectsEnabled);
        endCheck.SetActive(!objectsEnabled);

    }

    public void ToggleObjects2()
    {
        objectsEnabled = !objectsEnabled;


        foreach (GameObject obj in objectON)
        {
            obj.SetActive(objectsEnabled);
        }


        gameOver.SetActive(!objectsEnabled);
        gameOverCheck.SetActive(!objectsEnabled);

        



    }

    public void OnGameOver()
    {
        objectsEnabled = !objectsEnabled;


        foreach (GameObject obj in objectON)
        {
            obj.SetActive(objectsEnabled);
        }

        gameOver.SetActive(!objectsEnabled);
        gameOverCheck.SetActive(!objectsEnabled);

        plate.OnGameOver();
        ScoreText.text="Score: " + plate.score;
        plate.score = 0;
        plate.scoreText.text = "score: \n" + 0;

    }
}