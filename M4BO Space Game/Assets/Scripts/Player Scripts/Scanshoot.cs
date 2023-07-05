using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scanshoot : MonoBehaviour
{
    public AudioSource smallLaserSound;
    public AudioSource bigLaserSound;

    public GameObject laser;
    public GameObject bigLaser;
    public GameObject gun;

    public float reloadTime;
    public float switchTime;
    public int laserSpeed = 5;

    internal bool canShoot = true;
    public bool gunEquip = true;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (canShoot)
            {
                smallLaserSound.Play();
                GameObject newLaser = Instantiate(laser);
                newLaser.transform.rotation = transform.rotation;
                newLaser.transform.position = gun.transform.position;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        Destroy(hit.collider.gameObject, .2f);
                        GameManagement.score++;
                    }
                }
            }
        }

        if (!canShoot)
        {
            reloadTime += Time.deltaTime;
            if (reloadTime >= 2.5)
            {
                canShoot = true;
                reloadTime = 0;
            }
        }
    }
}
