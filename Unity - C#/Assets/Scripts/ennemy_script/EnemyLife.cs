using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public Animator animator;
    public GameObject enemy;

    
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        EnnemyPatrol ennemyPatrol = enemy.GetComponent<EnnemyPatrol>();
        ennemyPatrol.speed = 0f;

        animator.SetBool("IsDead", true);

        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        this.enabled = false;

        Destroy(transform.parent.gameObject,10.0f);
    }

}
