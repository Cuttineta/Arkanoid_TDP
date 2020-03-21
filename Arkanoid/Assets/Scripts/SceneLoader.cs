using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().DestroyGS();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadInfoScene()
    {
        SceneManager.LoadScene("Info Scene");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
