using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbat : MonoBehaviour
{
    [SerializeField] private int health = 300;
    [SerializeField] private int damage = 10;
    public void TakeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
