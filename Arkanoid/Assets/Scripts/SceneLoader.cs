using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    /*
     * Carga la siguiente escena
     */
	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    /*
     * Inicia un nuevo juego y resetea el puntaje del juego
     */
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().DestroyGS();
    }
    /*
     * Sale de la aplicacion
     */
    public void QuitGame()
    {
        Application.Quit();
    }

    /*
     * Carga la escena de informacion
     */
    public void LoadInfoScene()
    {
        SceneManager.LoadScene("Info Scene");
    }
    /*
     * Carga la escena inicial
     */
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    /*
     * Carga la escena cuando el jugador gana el juego
     */
    public void LoadWinGame()
    {
        SceneManager.LoadScene("Win Game");
    }
}
