using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour
{
    public float life=200;
    public float Mana=200;
    public int attackDamage=80;
    public int projectileDamage=40;
    // Start is called before the first frame update

    // Update is called once per frame

    public void easy()
    {
        life = 200;
        Mana = 200;
        attackDamage = 80;
        projectileDamage = 40;
    }

    public void normal()
    {
        life = 100;
        Mana = 100;
        attackDamage = 40;
        projectileDamage = 20;
    }

    public void hard()
    {
        life = 50;
        Mana = 50;
        attackDamage = 20;
        projectileDamage = 10;
    }

    public void choix_difficulty(int valeur)
    {
        if (valeur == 0)
        {
            easy();
            Debug.Log("easy");
        }
        if (valeur == 1)
        {
            normal();
            Debug.Log("medium");
        }
        if (valeur == 2)
        {
            hard();
            Debug.Log("Hard");
        }
    }
}
