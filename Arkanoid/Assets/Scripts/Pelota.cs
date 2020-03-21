using UnityEngine;

public class Pelota : MonoBehaviour
{
	//parametros de configuracion
	[SerializeField] Paleta paleta = null;
	[SerializeField] float xPush = 2f;
	[SerializeField] float yPush = 15f;
	[SerializeField] AudioClip clip = null;
	[SerializeField] float randomFactor = 0.2f;

	Vector2 paddleToBallVector;
	bool hasStarted = false;

	//Referencias a objetos del juego
	AudioSource myAudioSource;
	Rigidbody2D myRigidbody2D;

	// Start is called before the first frame update
	void Start()
	{
		//Distancia entre la posicion de la pelota y la posicion de la paleta
		paddleToBallVector = transform.position - paleta.transform.position;
		myRigidbody2D = GetComponent<Rigidbody2D>();
		myAudioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!hasStarted)
		{
			LockBallToPaddle();
			LaunchOnMouseClick();
		}

	}

	/*
	 * La pelota sale eyectada si hay un click y comienza el juego
	 */
	private void LaunchOnMouseClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			hasStarted = true;
			myRigidbody2D.velocity = new Vector2(xPush,yPush);
		}
	}

	/*
	 * Setea la posicion de la pelota en el medio de la paleta  
	 */
	private void LockBallToPaddle()
	{
		Vector2 posPaleta = new Vector2(paleta.transform.position.x, paleta.transform.position.y);
		transform.position = posPaleta + paddleToBallVector;
	}


	/*
	 * Si el juego comenzo, cuando la pelota colisiona, se reproducira el sonido de la misma
	 */
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor)); //utilizado para evitar loops de la pelota de derecha a izquierda horizontalmente
		if (hasStarted)
		{
			myAudioSource.PlayOneShot(clip);
			myRigidbody2D.velocity += velocityTweak;
		}

	}
}
