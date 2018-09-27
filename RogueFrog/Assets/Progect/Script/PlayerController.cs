using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (horizontalMovement > 0)
        {
            transform.position = new Vector3(transform.position.x + 0.32f, transform.position.y, transform.position.z);
        }
        else if (horizontalMovement < 0)
        {
            transform.position = new Vector3(transform.position.x - 0.32f, transform.position.y, transform.position.z);
        }
        if (verticalMovement > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.32f, transform.position.z);
        }
        else if (verticalMovement < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.32f, transform.position.z);
        }

    }
}
