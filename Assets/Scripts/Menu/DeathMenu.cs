using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;
    public TMP_Text scoreText;

    public void ShowDeathMenu(int gold)
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f; // pause game

        scoreText.text = "Gold: " + gold;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}