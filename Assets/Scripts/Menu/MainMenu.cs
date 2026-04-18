using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // your game scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // works in editor
        Application.Quit();    // works in build
    }
}