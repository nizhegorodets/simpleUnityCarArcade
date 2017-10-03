using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCar : MonoBehaviour {
	public float speed;

	void Update () {
		transform.Translate (new Vector2 (0.0f, -speed));
		speed += 0.002f;
	}
}
