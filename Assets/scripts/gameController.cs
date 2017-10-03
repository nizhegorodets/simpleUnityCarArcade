using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gameController : MonoBehaviour {
	public List<GameObject> otherCars;
	public Vector2 spawnVector;
	public float wait;
	public bool gameOver;
	public bool gameRestart;
	public static gameController Instance;
	public GameObject gameOverText;

	void Start()
	{
		StartCoroutine( Spawn ());
		gameOver = false;
		gameRestart = false;
		gameOverText = GameObject.Find ("textGameOver");
		gameOverText.GetComponent<TextMesh> ().text = "";
	}

	void Awake()
	{

		Instance = this;
	}

	void Update()
	{
		if (gameRestart) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (wait);
		while (true) {
			float numberCar = UnityEngine.Random.Range (0, otherCars.Count);

			float xPos;
			if (UnityEngine.Random.Range (0.0f, 1.0f) >= 0.5f) {
				xPos = -2 / 2;
				Debug.Log ("Left");
			} else {
				xPos = 2 / 2;
				Debug.Log ("Right");
			}

			Vector2 spawnPosition = new Vector2 (xPos, 4.0f);
			Quaternion spawnRotaion = Quaternion.identity;
			Debug.Log ((int)numberCar);
			Instantiate (otherCars[(int)numberCar], spawnPosition, spawnRotaion);
			yield return new WaitForSeconds (wait);
			if (gameOver) {
				gameRestart = true;
				break;
			}
		}
	}

	public void gameOverF()
	{
		gameOver = true;
		gameOverText.GetComponent<TextMesh> ().text = "Game over\n Press Space";
	}
}
