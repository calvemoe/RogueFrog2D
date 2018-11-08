﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //scoring 
    public delegate void PlayerHandler();
    public event PlayerHandler OnPlayerMoved;
    public event PlayerHandler OnPlayerEscaped;

    //player movement
    public float jumpDistance = 0.32f;

    private bool jumped;
    private Vector3 startingPosition;
 
	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
	}

    // Update is called once per frame
    void Update() {
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

            Collider2D hitCollider = Physics2D.OverlapCircle(targetPosition, 0.05f);
            if ((hitCollider == null || hitCollider.GetComponent<Enemy>() != null) && tryToMove == true)
            {
                GetComponent<AudioSource>().Play();
                jumped = true;
                transform.position = targetPosition;
                if (OnPlayerMoved != null)
                {
                    OnPlayerMoved();
                }
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
            if (OnPlayerEscaped != null)
            {
                OnPlayerEscaped();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }
    }
}
