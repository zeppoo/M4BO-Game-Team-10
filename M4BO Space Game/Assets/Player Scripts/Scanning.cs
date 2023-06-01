using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Scanning : MonoBehaviour
{
    public string[] scannedObjects;
    [SerializeField] public LayerMask scannable;
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Vector3(transform.)

            if (Physics.Raycast(ray, out hit, scannable))
            {
                Debug.DrawRay(ray.origin, ray.direction, UnityEngine.Color.green, 100f);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}

