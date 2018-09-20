using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D_s : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
 
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButton(0))
        {
            Vector2 relativePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

            if (relativePosition.x < 0.5f)
            {
                Debug.Log("LEFT!");
                GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
            }
            else if (relativePosition.x > 0.5f)
            {
                Debug.Log("RIGHT!");
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
            }
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //keep player within bounce
        float zDistance = Camera.main.transform.position.z - transform.position.z;

        float leftLimit = Camera.main.ScreenToWorldPoint(new Vector3(
            0, 
            0, 
            -zDistance / (Mathf.Cos(Camera.main.transform.localEulerAngles.x * Mathf.Deg2Rad))
        )).x;

        float rightLimit = Camera.main.ScreenToWorldPoint(new Vector3(
            Screen.width,
            0,
            -zDistance / (Mathf.Cos(Camera.main.transform.localEulerAngles.x * Mathf.Deg2Rad))
        )).x;

        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
    }
}
