using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stalactitController : MonoBehaviour
{
    public GameObject stalactit;
    int alea = 0;
    bool timeOK = true;
    public int aleamax=5;

    private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (timeOK==true)
            {
                alea = Random.Range(1, aleamax);
                if (alea == 5)
                {
                    Instantiate(stalactit, new Vector2(other.transform.position.x,other.transform.position.y + 10), Quaternion.identity);
                    Destroy(GameObject.Find("boiteDegat(Clone)"),2f);

                }
                print($"spawn{alea}");
                timeOK = false;
                yield return new WaitForSeconds(0.4f);
                timeOK = true;            }   
        }
    }
}
