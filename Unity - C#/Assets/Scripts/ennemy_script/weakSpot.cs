using UnityEngine;

public class weakSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject.transform.parent.gameObject);
        }
    }
}
