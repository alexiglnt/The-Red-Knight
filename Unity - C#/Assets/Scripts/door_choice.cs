using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_choice : MonoBehaviour
{

    bool open = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            open = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "door1" || other.gameObject.tag == "door2")
        {
            open = false;
        }
            
    }
    private void OnTriggerStay2D(Collider2D other)
    {
            
        if (other.gameObject.tag == "door1" && open)
        {
           
                print("door1");
                
            
        }
        if (other.gameObject.tag == "door2" && open)
        {

            print("door2");

        }
        open = false;
    }
}
