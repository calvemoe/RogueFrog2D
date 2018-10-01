using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(gameObject.GetComponent<BoxCollider2D>().size);
        Debug.Log("Enemy corners: " + (transform.position.x + (gameObject.GetComponent<BoxCollider2D>().size.x / 2f)) +
                          ":" + (transform.position.y + (gameObject.GetComponent<BoxCollider2D>().size.y / 2f)) +
                          " " + (transform.position.x - (gameObject.GetComponent<BoxCollider2D>().size.x / 2f)) +
                          ":" + (transform.position.y + (gameObject.GetComponent<BoxCollider2D>().size.y / 2f)) +
                          " " + (transform.position.x - (gameObject.GetComponent<BoxCollider2D>().size.x / 2f)) +
                          ":" + (transform.position.y - (gameObject.GetComponent<BoxCollider2D>().size.y / 2f)) +
                          " " + (transform.position.x + (gameObject.GetComponent<BoxCollider2D>().size.x / 2f)) +
                          ":" + (transform.position.y - (gameObject.GetComponent<BoxCollider2D>().size.y / 2f)));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
