using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    public float range;
    public float attackRange;

    public double maxHealth;
    public double health;

    public bool canSee = false;

    public GameObject target;
    
    private GameObject enemy;
    private GameObject healthbar;

    private Animator animator;

    private void updateHealth()
    {
        RectTransform bar = healthbar.transform.Find("bar").GetComponent<RectTransform>();

        double size = health / maxHealth;

        bar.localScale = new Vector2((float)size, 1);

        if (health <= 0)
        {
            Destroy(enemy);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        enemy.tag = "Enemy";

        healthbar = transform.Find("Healthbar").gameObject;
        animator = transform.GetComponentInChildren<Animator>();

        healthbar.GetComponentInChildren<TextMesh>().text = enemy.name;

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth();

        float distance = Vector3.Distance(transform.position, target.transform.position);

        Vector3 lookAtPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        if (distance <= range && distance > attackRange)
        {
            enemy.transform.LookAt(lookAtPos);
            enemy.transform.position += speed * Time.deltaTime * enemy.transform.forward;
            animator.SetTrigger("Running");
        }
        else if (distance <= attackRange)
        {
            enemy.transform.LookAt(lookAtPos);
            animator.SetTrigger("Attack");
        }
        else
        {
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
