using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;
using UnityEngine.UIElements;

public class DamageScript : MonoBehaviour
{
    bool canTouch = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (!canTouch) { return; }

        canTouch = !canTouch;

        string tag = gameObject.tag.ToLower();

        if (tag == "bullet")
        {
            Vector3 position = transform.position;

            Rigidbody rb = GetComponent<Rigidbody>();
            ParticleSystem particle = gameObject.GetComponent<ParticleSystem>();

            rb.velocity = new Vector3(0,0,0);
            rb.position = rb.position;

            Destroy(gameObject.GetComponent<Rigidbody>());

            gameObject.GetComponent<MeshRenderer>().enabled = false;

            particle.Play();

            if (collider.tag == "Enemy")
            {
                collider.GetComponent<EnemyScript>().canSee = true;
            }
        }
    }
}
