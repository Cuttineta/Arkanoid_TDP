using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    [SerializeField] AudioClip sonido = null;
    [SerializeField] Sprite[] hitSprites; //Contendra los sprites de los bloques con diferentes daños
    [SerializeField] int puntos = 10;

    Nivel nivel = null;

    int golpesRecibidos = 0;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        nivel = FindObjectOfType<Nivel>();
        if (tag == "Breakable")
        {
            nivel.AumentarBloques();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            RecibirGolpe();
        }
    }
    /*
     * Reproduce el sonido correspondiente, destruye el objeto de juego y añade los puntos
     * al puntaje del juego
     */
    private void BloqueDestruido()
    {
        AudioSource.PlayClipAtPoint(sonido, Camera.main.transform.position);
        Destroy(gameObject);
        nivel.DestruirBloque();
        FindObjectOfType<GameStatus>().AddToScore(puntos);
    }

    private void RecibirGolpe()
    {
        golpesRecibidos++;
        int maxHits = hitSprites.Length + 1;
        if (golpesRecibidos >= maxHits)
        {
            BloqueDestruido();
            puntos = 10;
        }
        else
        {
            CambiarSprite();
            puntos += 5;
        }
    }

    private void CambiarSprite()
    {
        int spriteIndex = golpesRecibidos - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Fuera del arreglo");
        }
    }
}
