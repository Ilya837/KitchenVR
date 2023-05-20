using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public string objectTag = "ObjectOFF";
    public Canvas startCanvas;
    public GameObject[] objectON;
    public GameObject startCheck;
    public GameObject endCheck;
    private bool objectsEnabled = false;

    private void Start()
    {
       
    }

    public void ToggleObjects()

    {
        objectsEnabled = !objectsEnabled;

        GameObject[] objectsToControl = GameObject.FindGameObjectsWithTag(objectTag);

        foreach (GameObject obj in objectON)
        {
            obj.SetActive(objectsEnabled);
        }
        Debug.Log(objectsToControl.Length);
        startCanvas.gameObject.SetActive(!objectsEnabled);
        startCheck.SetActive(!objectsEnabled);
        endCheck.SetActive(!objectsEnabled);

    }
}