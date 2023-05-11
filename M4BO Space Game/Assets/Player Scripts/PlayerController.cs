using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTr;
    public Transform cameraTransform ;
    public float moveSpeed = 10;

    void Start()
    {
        playerTr = GetComponent<Transform>();
        cameraTransform = GameObject.Find("PlayerCamera").GetComponent<Transform>();
    }

	void Update () 
    {
        playerTr.rotation = new Quaternion(0,cameraTransform.rotation.y, 0, 1);
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
