using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scanshoot : MonoBehaviour
{
    public float reloadTime;
    public float switchTime;

    public bool gunEquip = false;

    [SerializeField]public List<string> scannedObjects;

    public LayerMask scannable;

    public GameObject bullet;

    internal bool canShoot = true;

    private float speed = 30f;
    private float destroyTime = 10f;
    private float switchCooldownTime = 0;

    private float forwardPos = 2f;
    private float rightPos = .3f;
    private float upPos = .2f;

    private bool switchCooldown = true;

    private GameObject gun;

    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 || Input.mouseScrollDelta.y > 0)
        {
            if (switchCooldown)
            {
                gunEquip = !gunEquip;

                if (!gunEquip)
                {
                    transform.Find("Gun").gameObject.SetActive(false);
                    transform.Find("scanner").gameObject.SetActive(true);
                }
                else
                {
                    transform.Find("Gun").gameObject.SetActive(true);
                    transform.Find("scanner").gameObject.SetActive(false);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))//if left mouse gets clicked it checks which equipment is true
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (gunEquip == false)
            {
                if (Physics.Raycast(ray, out hit, scannable))
                {
                    if (hit.collider.gameObject.CompareTag("Scannable") && !scannedObjects.Contains(hit.collider.gameObject.name))
                    {
                        scannedObjects.Add(hit.collider.gameObject.name);
                    }
                }
            }
            else if (gunEquip == true && canShoot)
            {
                GameObject newBullet = Instantiate(bullet);
                newBullet.tag = "Bullet";
                newBullet.GetComponent<ParticleSystem>().Stop();
                newBullet.transform.position = transform.position + (transform.forward * forwardPos + transform.right * rightPos + transform.up * upPos);
                Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * speed;
                Destroy(newBullet, destroyTime);

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
