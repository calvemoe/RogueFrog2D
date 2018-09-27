using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpDistance = 0.32f;

    private bool jumped;

    private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 targetPosition = Vector2.zero;

        bool tryToMove = false;

        //Movement logic
        if (!jumped)
        {

            if (horizontalMovement > 0)
            {
                targetPosition = new Vector2(transform.position.x + jumpDistance, transform.position.y);
                tryToMove = true;
            }
            else if (horizontalMovement < 0)
            {
                targetPosition = new Vector2(transform.position.x - jumpDistance, transform.position.y);
                tryToMove = true;
            }
            else if (verticalMovement > 0)
            {
                targetPosition = new Vector2(transform.position.x, transform.position.y + jumpDistance);
                tryToMove = true;
            }
            else if (verticalMovement < 0)
            {
                targetPosition = new Vector2(transform.position.x, transform.position.y - jumpDistance);
                tryToMove = true;
            }

            Collider2D hitCollider = Physics2D.OverlapCircle(targetPosition, 0.1f);
            if (hitCollider == null && tryToMove == true)
            {
                jumped = true;
                transform.position = targetPosition;
            }
        }
        else
        {
            if (horizontalMovement == 0 && verticalMovement == 0)
            {
                jumped = false;
            }
        }

        //keep player in bounds.
        if (transform.position.y < -(Screen.height / 100f) / 2f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + jumpDistance);
        }

        if (transform.position.x < -(Screen.width / 100f) / 2f)
        {
            transform.position = new Vector2(transform.position.x + jumpDistance, transform.position.y);
        }

        if (transform.position.x > (Screen.width / 100f) / 2f)
        {
            transform.position = new Vector2(transform.position.x - jumpDistance, transform.position.y);
        }

        if (transform.position.y > (Screen.height / 100f) / 2f)
        {
            transform.position = startingPosition;
        }


    }
}
