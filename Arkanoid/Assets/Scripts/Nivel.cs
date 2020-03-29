using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    [SerializeField] int bloquesActuales=0;

    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void AumentarBloques()
    {
        bloquesActuales++;
    }

    /*
     * Disminuye la cantidad de bloques que hay en el nivel.
     * Si no hay mas bloques para destruir, se carga la sig
     * escena o se termina el juego (el jugador gana)
     */
    public void DestruirBloque()
    {
        bloquesActuales--;
        if (bloquesActuales <= 0)
        {
            if (tag == "UltimoNivel")
            {
                sceneloader.LoadWinGame();
            }
            else
            {
                sceneloader.LoadNextScene();
            }
        }
    }
}
