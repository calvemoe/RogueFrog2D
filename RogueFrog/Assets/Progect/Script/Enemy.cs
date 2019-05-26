using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //enemy starting speed
    public float speed = 1f;

    private Rigidbody2D rbEnemy;
    private float boundary;

	void Awake () {
        rbEnemy = GetComponent<Rigidbody2D>();
        boundary = (Screen.width / 100f) / 2f + 0.32f;
    }
	
	// Update is called once per frame
	void Update () {
        rbEnemy.velocity = new Vector2(speed, 0);

        if(transform.position.x > boundary) {
            transform.position = new Vector3(-transform.position.x + 0.32f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -boundary) {
            transform.position = new Vector3(-transform.position.x - 0.32f, transform.position.y, transform.position.z);
        }

    }
}
