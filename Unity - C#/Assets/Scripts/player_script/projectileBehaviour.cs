using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehaviour : MonoBehaviour
{
    public Animator animator;
    public float Speed = 0f;
    private GameObject enemy;

    private playerCombat playerCombat;
    private GameObject player;

    public GameObject songObject;
    void Start()
    {
        
        Destroy(gameObject,1.5f);
        player = GameObject.Find("player_knight");
        playerCombat = player.GetComponent<playerCombat>();
    }
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "heal"|| collision.tag == "strength" || collision.tag == "armor" || collision.tag == "coins" || collision.tag == "object")
        {
        }
        else
        {
            if (collision.tag == "degat" )
            {
                collision.GetComponent<EnemyLife>().TakeDamage(playerCombat.projectileDamage);
            }
            animator.SetBool("IsDead", true);
            Speed = 0f;
            Instantiate(songObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
            Destroy(gameObject);
        }
     
    }
}
