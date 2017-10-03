using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour
{
	private float speed;
	private Vector2 posLeft;
	private Vector2 posRight;
	private bool toLeftMovement;
	private bool toRightMovement;
	private int periodBlueMod;
	private int countBlueModTime;
	private bool onBlue;

	void Awake()
	{
		periodBlueMod = 120;
		countBlueModTime = 0;
		onBlue = false;
	}

	void Start()
	{
		speed = 0.1f;
		posLeft = new Vector2 (-2 + 2.0f / 4, -2.88f);
		posRight = new Vector2 (2.0f / 4 * 3, -2.88f);
		transform.position = posRight;
	}

	void Update()
	{
		if(toLeftMovement)
		{
			if (transform.position.x >= posLeft.x) {
				transform.Translate (-speed, 0, 0);
			} else {
				toLeftMovement = false;
			}
		}

		if(toRightMovement)
		{
			if (transform.position.x <= posRight.x) {
				transform.Translate (speed, 0, 0);
			} else {
				toRightMovement = false;
			}
		}

		if (onBlue) {
			countBlueModTime++;
			if (countBlueModTime > periodBlueMod) {
				onBlue = false;
				if(contact.instance != null)
					contact.instance.blueMod = false;
				GameObject temp = GameObject.Find ("Player");
				temp.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("pixelAudi");
				countBlueModTime = 0;
			}
		}
	}

	void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
		bool space = Input.GetKeyDown (KeyCode.Space);
		if (space) {
			Debug.Log ("Space pressed!");
			if(contact.instance != null)
				contact.instance.blueMod = true;
			onBlue = true;
			GameObject temp = GameObject.Find ("Player");
			temp.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("pixelAudiBlue");
		}

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

		if (!toLeftMovement && !toRightMovement)
		{
			if (movement.x < 0) {
				toLeftMovement = true;
			}

			if (movement.x > 0) {
				toRightMovement = true;
			}
		}
    }

}
