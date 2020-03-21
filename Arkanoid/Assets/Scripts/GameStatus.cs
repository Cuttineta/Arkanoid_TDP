using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
	//Parametros de configuracion
	[Range(0.1f,10f)][SerializeField] float gameSpeed=1f;
	[SerializeField] TextMeshProUGUI scoreText = null;


	int currentScore = 0;

	/*
	 * Awake() obtiene la cantidad de instancias de GameStatus (sesion de juego donde
	 * tenemos el puntaje de cierto nivel). Si ya tenemos una instancia de GameStatus
	 * entonces no se creara ninguna instancia nueva. (Patron SINGLETON. Solo habrá una
	 * instancia de esta clase)
	 */
	private void Awake()
	{
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
		if (gameStatusCount > 1)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}else
		{
			DontDestroyOnLoad(gameObject);
		}
			
	}

	// Start is called before the first frame update
	private void Start()
	{
		scoreText.text = "Score: "+ currentScore.ToString();
			
	}

	// Update is called once per frame
	void Update()
	{
		Time.timeScale = gameSpeed;

	}
	/*
	 * Recibe por parametro un int que indica cuantos puntos se agregaran
	 * al puntaje del juego
	 */
	public void AddToScore(int points)
	{
		currentScore += points;
		scoreText.text = "Score: " + currentScore.ToString();


	}
	/*
	 * Destruye la instancia de la clase y resetea el puntaje del juego
	 */
	public void DestroyGS()
    {
		scoreText = null;
		Destroy(gameObject);

    }
}
