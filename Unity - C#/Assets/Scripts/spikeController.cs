using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().Die();
        }
    }

}
