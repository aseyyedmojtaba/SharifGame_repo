using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 3f;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScene());
        }

    }
    public IEnumerator LoadStartScene()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(timeToWait);
        LoadeNextScene();
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadeMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptionScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Option Screen");
    }
    public void LoadeNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
