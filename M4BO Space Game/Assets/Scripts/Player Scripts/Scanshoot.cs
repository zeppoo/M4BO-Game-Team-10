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

    private float switchCooldownTime = 0;
    public float reloadTime;
    public float switchTime;
    public int laserSpeed = 5;

    private bool switchCooldown = true;
    internal bool canShoot = true;
    public bool gunEquip = true;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 || Input.mouseScrollDelta.y > 0)
        {
            if (switchCooldown)
            {
                gunEquip = !gunEquip;
            }
        }

        if (Input.GetMouseButtonDown(0))//if left mouse gets clicked it checks which equipment is true
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (gunEquip == false)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    bigLaserSound.Play();
                    GameObject newLaser = Instantiate(bigLaser);
                    newLaser.transform.rotation = transform.rotation;
                    newLaser.transform.position = gun.transform.position;
                }
            }
            else if (gunEquip == true && canShoot)
            {
                smallLaserSound.Play();
                GameObject newLaser = Instantiate(laser);
                newLaser.transform.rotation = transform.rotation;
                newLaser.transform.position = gun.transform.position;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        Destroy(hit.collider.gameObject);
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

        if (!switchCooldown)
        {
            switchCooldownTime += Time.deltaTime;

            if (switchCooldownTime >= switchTime)
            {
                switchCooldown = true;
                switchCooldownTime = 0;
            }
        }
    }
}
