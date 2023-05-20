using UnityEngine;
using UnityEngine.UI;

public class gameExit : MonoBehaviour
{
    public Button exitButton;

    public void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}