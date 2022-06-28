using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    float speedSave;

    public projectileBehaviour projectilePrefab;
    public Transform LaunchOffset;
    public GameObject projectile;
    public int projectileDamage;



    private PlayerInventory playerInventory;
    private PlayerController playerController;
    private GameObject player;



    public GameObject myPrefab;


    public GameObject songObjectFireBall;
    public GameObject songObjectSword;


    void Start()
    {


        player = GameObject.Find("player_knight");
        playerController = player.GetComponent<PlayerController>();
        playerInventory = player.GetComponent<PlayerInventory>();
        speedSave = playerController.maxSpeed;


    }

    // Update is called once per frame
    void Update()

    {
        if (playerController.grounded)
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                
                playerController.maxSpeed = 0;
                animator.SetTrigger("Range");
                Instantiate(songObjectFireBall, transform.position, Quaternion.identity);
            }
            
            
        }

    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(songObjectSword, transform.position, Quaternion.identity);


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyLife>().TakeDamage(attackDamage+playerInventory.Strength);
        }
    }

    void Range()
    {
        if (playerInventory.Mana <= 0)
        {

        }
        else
        {
            Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
            playerInventory.Mana -= 10;
        }
        setSpeedtoNormal();
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void setSpeedtoNormal()
    {
        playerController.maxSpeed = speedSave;
    }
}

