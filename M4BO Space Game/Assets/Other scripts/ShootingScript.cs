using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public float reloadTime = 2.5f;

    private bool canShoot = true;

    private float speed = 30f;

    private float forwardPos = 2f;
    private float rightPos = .3f;
    private float upPos = .2f;

    private float destroyTime = 10f;

    public GameObject bullet;

    IEnumerator wait()
    {
        yield return new WaitForSeconds(reloadTime);

        canShoot = !canShoot;
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canShoot) { return; }
            canShoot = !canShoot;

            GameObject newBullet = Instantiate(bullet);
            newBullet.tag = "Bullet";
            newBullet.GetComponent<ParticleSystem>().Stop();

            if (!newBullet.GetComponent<DamageScript>())
            {
                newBullet.AddComponent<DamageScript>();
            }

            Transform cam = transform.Find("PlayerCamera").transform;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.position = transform.position + (cam.forward * forwardPos + cam.right * rightPos + cam.up * upPos);

            bulletRB.velocity += cam.forward * speed;

            Destroy(newBullet, destroyTime);

            StartCoroutine(wait());
        }
    }
}
