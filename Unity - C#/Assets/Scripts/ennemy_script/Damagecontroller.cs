using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagecontroller : MonoBehaviour
{

    public GameObject damageSound;
    public int Enemydamage;
    bool invincible = false;



    private IEnumerator OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           
            if (invincible == false)
            {
                col.GetComponent<PlayerInventory>().degat(Enemydamage);
                print($"vie { col.GetComponent<PlayerInventory>().life}");
                Instantiate(damageSound, transform.position, Quaternion.identity);
                invincible = true;
                yield return new WaitForSeconds(1);
                invincible = false;
            }
        }
    }
}