using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;

    public float range = 20;
    public float attackRange = 10;


    public bool canSee = false;

    public GameObject target;
    
    private GameObject enemy;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        enemy.tag = "Enemy";
        animator = transform.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 lookAtPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        if (distance <= range && distance > attackRange)
        {
            Debug.Log("target is in range!");
            enemy.transform.LookAt(lookAtPos);
            enemy.transform.position += speed * Time.deltaTime * enemy.transform.forward;
            animator.SetTrigger("Running");
        }
        else if (distance <= attackRange)
        {
            Debug.Log("target is in attack Range");
            enemy.transform.LookAt(lookAtPos);
            animator.SetTrigger("Attack");
        }
        else
        {
            Debug.Log("target is out of range!");
            animator.SetTrigger("Idling");
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
