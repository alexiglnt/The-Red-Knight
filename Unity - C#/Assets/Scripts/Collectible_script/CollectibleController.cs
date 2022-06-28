using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public int CoinsAmount = 0;
    public int StrengthAmount = 0;
    public int ArmorAmount = 0;
    public int HealAmount = 0;

    public GameObject songObject;

    public void DestroyAndSong()
    {
            Destroy(gameObject);
            Instantiate(songObject, transform.position, Quaternion.identity);
    }
}
