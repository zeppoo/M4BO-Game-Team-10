using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;
    public float range = 20;
    public float damageRange = 40;

    public bool canSee = false;

    public GameObject target;
    
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        enemy.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 lookAtPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        if (distance <= range)
        {
            enemy.transform.LookAt(lookAtPos);
            enemy.transform.position += speed * Time.deltaTime * enemy.transform.forward;
        }
        /*
        else if (canSee && distance <= damageRange)
        {
            enemy.transform.LookAt(lookAtPos);
            enemy.transform.position += enemy.transform.forward * speed * Time.deltaTime;
        }
        else if (canSee && distance > damageRange)
        {
            canSee = false;
        }*/
    }
}
