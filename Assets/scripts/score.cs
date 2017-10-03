using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {
	public GameObject scoreText;
	public float Score;


	void Start () {
		scoreText = GameObject.Find ("score");
		Score = 0;
		updateScore ();
	}

	void updateScore()
	{
		scoreText.GetComponent<TextMesh>().text = ((int)Score).ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		Score += 0.1f;
		updateScore ();
	}
}
