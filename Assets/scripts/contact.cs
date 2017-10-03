using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contact : MonoBehaviour {
	public GameObject explosion;
	public bool blueMod;
	public static contact instance;

	void Awake()
	{
		instance = this;
		blueMod = false;

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "boundary") {
			return;
		}
		if (!blueMod) {
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.Instance.gameOverF ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
