using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	[SerializeField]
	float moveSpeed = 5f;

	Rigidbody2D rb;
	Touch touch;
	Vector3 touchPosition, whereToMove;
	bool isMoving = false;
	Animator anim;
	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void Update () {

		if (isMoving)
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
					previousDistanceToTouchPos = 0;
					currentDistanceToTouchPos = 0;
					isMoving = true;
					anim.SetBool("Moving", true);
					touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
					touchPosition.z = 0;
					whereToMove = (touchPosition - transform.position).normalized;

					if(whereToMove.x < transform.position.x && transform.eulerAngles.y == 0)
			        {
			            Rotate(180);
			        }
			        if(whereToMove.x > transform.position.x && transform.eulerAngles.y == 180)
			        {
			            Rotate(0);
			        }

					rb.velocity = new Vector2 (whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
				}
		}

		if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
			isMoving = false;
			anim.SetBool("Moving", false);
			rb.velocity = Vector2.zero;
		}

		if (isMoving)
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
	}

    void Rotate(int direction)
    {  	
    	transform.eulerAngles = new Vector3(0, direction, 0);
    }
}
