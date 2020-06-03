using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private int currentLevelIndex;

    private void Awake()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        if (currentLevelIndex == 0)
        {
            StartCoroutine(LoadMainMenuAfterSplashScreen());
        }
    }

    private IEnumerator LoadMainMenuAfterSplashScreen()
    {
        yield return new WaitForSeconds(4);
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentLevelIndex + 1);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
