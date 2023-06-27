using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    internal float health;

    public GameObject playerGui;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        RectTransform bar = playerGui.transform.Find("Healthbar").Find("bar").GetComponent<RectTransform>();

        double size = health / maxHealth;

        if (health > 0)
        {
            bar.localScale = new Vector2((float)size, 1f);
        }
        else if (health <= 0)
        {
            bar.localScale = new Vector2(0f, 1f);
        }
    }
}
