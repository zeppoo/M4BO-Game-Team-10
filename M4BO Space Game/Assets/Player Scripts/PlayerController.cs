using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTr;
    Vector2 playerRot = Vector2.zero;
    Vector2 cameraRot = Vector2.zero;
	public float sensetivity = 3;
    public float moveSpeed = 10;

    void Start()
    {
        playerTr = GetComponent<Transform>();
    }

	void Update () 
    {
		cameraRot.y += Input.GetAxis("Mouse X");
		cameraRot.x += -Input.GetAxis("Mouse Y");
		transform.eulerAngles = (Vector2)cameraRot * sensetivity;
        playerRot.y = cameraRot.y;

        if (Input.GetButton("Vertical"))
        {
            playerTr.Translate(0,0,Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        }
        if (Input.GetButton("Horizontal"))
        {
            playerTr.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,0,0);
        }



	}
}
