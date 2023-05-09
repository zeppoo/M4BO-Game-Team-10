using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Rigidbody rb;
    Vector2 rotation = Vector2.zero;
	public float sensitivity = 3;
	public float moveSpeed;


	void Update () 
    {
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x += -Input.GetAxis("Mouse Y");
		transform.eulerAngles = (Vector2)rotation * sensitivity;

		if (Input.GetButton("Vertical"))
		{
			transform.Translate(0,0,Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
		}

		if (Input.GetButton("Horizontal"))
		{
			transform.Translate(Input.GetAxis("Horizontal"),0,0 * Time.deltaTime);
		}
	}
}
