using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB; // Propriété qui tiendra en réféence le rigid body de notre player
    SpriteRenderer playerRenderer; // Propriété qui tiendra la réféence du sprite rendered de notre player
    Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator
    public float maxSpeed; // Vitesse maximale que notre player peut atteindre en se déplacant

    public bool grounded = false; // Valeur qui traque si l'utilisateur est au sol ou non
    float groundCheckRadius = 0.2f; // Raduis du cercle pour tester si l'utilisateur est en contact avec le sol (Peut etre change en fonction des assets)
    public LayerMask groundLayer; // Rééence au layer avec lequel nous allons checker la colision
    public Transform[] groundedList; // Rééence au GroundCheckLocation que nous avons déini dans le KnightPlayer
    public float jumpPower; // Force avec laquelle nous allons projeter notre personnage en l'air
    bool canMove = true;

    int cpt = 1;

    private playerCombat PlayerCombat;
    private GameObject player;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se situe au sein du même objet
        // Récupérer le component sprite renderer en dessous de cette ligne
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        player = GameObject.Find("player_knight");
        PlayerCombat = player.GetComponent<playerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cpt <= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canMove)
            {
                playerAnim.SetBool("IsGrounded", false);
                playerRB.velocity = new Vector2(playerRB.velocity.x,0f);
                playerAnim.SetFloat("VerticalVelocity", playerRB.velocity.y);
                playerRB.AddForce(new Vector2(0, jumpPower),
                ForceMode2D.Impulse);
                grounded = false;
                cpt += 1;
                
            }
        }
        else if (grounded)
        {
            cpt = 1;
        }


        if (Physics2D.OverlapCircle(groundedList[2].position, groundCheckRadius, groundLayer) == false)
            grounded = false;

        for (int i = 0; i < 3; ++i)
        {
            if (Physics2D.OverlapCircle(groundedList[i].position, groundCheckRadius, groundLayer) == true)
                grounded = true;
        }

        

        playerAnim.SetBool("IsGrounded", grounded);
        float move = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        if (canMove)
        {
            transform.position += new Vector3(move, 0, 0) * Time.deltaTime * maxSpeed;
            if (!Mathf.Approximately(0, move))
                transform.rotation = move > 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
            playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y); // On utilise vector 2 car nous sommes dans un contexte 2D
            playerAnim.SetFloat("moveSpeed", Mathf.Abs(move)); // Defini une valeur pour le float MoveSpeed dans notre animator
            playerAnim.SetFloat("VerticalVelocity", Mathf.Abs(movevertical));
        }
        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y); // Si movement non autorise, on arrete la velocite
            playerAnim.SetFloat("MoveSpeed", 0); // on arrete aussi l'animation en cours si on etait en train de courir
            playerAnim.SetFloat("VerticalVelocity", 0);
        }
    }



    public void CanMoveTrue()
    {
        PlayerCombat.setSpeedtoNormal();
        canMove = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "damageObstacle")
        {
            playerRB.AddForce(new Vector2(1, 1) * 30, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "triggerDebut")
        {
            Debug.Log("Bonjour humain, bienvenu !");
        }
        if (collision.gameObject.tag == "bumper")
        {
            playerRB.AddForce(new Vector2(1, 1) * 20, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "transition1")
        {
            SceneManager.LoadScene("Transition_1");
        }
        if (collision.gameObject.tag == "transition2")
        {
            SceneManager.LoadScene("Transition_2");
        }
        if (collision.gameObject.tag == "fin")
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        //Debug.Log("E");
        //if (collision.gameObject.tag == "Door1") // GameObject.Find("Door1")
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        Debug.Log("Porte");
        //        //SceneManager.LoadScene("Level_1");

        //    }
        //}

        if (collision.gameObject.tag == "Door1")
        {
            SceneManager.LoadScene("Level_1");
        }
        else if (collision.gameObject.tag == "Door2")
        {
            SceneManager.LoadScene("Level_2");
        }
        else if (collision.gameObject.tag == "Door3")
        {
            SceneManager.LoadScene("Level_3");
        }
        else if (collision.gameObject.tag == "DoorNextScene")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else if (collision.gameObject.tag == "DoorLastScene")
        {
            SceneManager.LoadScene("Level_3");
        }


    }

}