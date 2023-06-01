using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Scanning : MonoBehaviour
{
    public List<string> scannedObjects;
    [SerializeField] public LayerMask scannable;
    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit, scannable))
            {
                if (hit.collider.gameObject.CompareTag("Scannable") && !scannedObjects.Contains(hit.collider.gameObject.name))
                {
                    scannedObjects.Add(hit.collider.gameObject.name);
                }
            }
        }
    }
}

