using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    int Coins = 0;
    int coinsPalierRegenRate = 0;
    int coinsPalierDamageMana = 0;
    int Armor = 0;
    public int Strength = 0;

    float maxlife;
    public float life;

    float regenRate = 0.01f;
    float maxMana;
    public float Mana;

    public Text coinsText;
    public Text armorText;
    public Text strengthText;

    public Animator animator;

    private playerCombat PlayerCombat;
    private PlayerController playerController;
    private GameObject player;

    private SceneLoqder sceneLoqder;
    private GameObject scene;

    private CollectibleController collectibleController;
    private GameObject Collectible;

    public GameObject pauseMenuUI;

    public Image imgMana;
    public Image imgLife;

    public GameObject myPrefab;
    void Start()
    {
        
        coinsText.text = Coins.ToString();
        armorText.text = Armor.ToString();
        strengthText.text = Strength.ToString();
        
        player = GameObject.Find("player_knight");
        playerController = player.GetComponent<PlayerController>();
        PlayerCombat = player.GetComponent<playerCombat>();

        scene = GameObject.Find("SceneLoader");
        sceneLoqder = scene.GetComponent<SceneLoqder>();
        //choix_difficulty(val);

       
    }

    private void Update()
    {
        manaRegen();
        imgLife.fillAmount = (life / maxlife);
        imgMana.fillAmount = (Mana / maxMana);


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "difficulty")
        {
            Mana = myPrefab.GetComponent<difficulty>().Mana;
            life = myPrefab.GetComponent<difficulty>().life;
            maxlife = life;
            maxMana = Mana;
            PlayerCombat.attackDamage = myPrefab.GetComponent<difficulty>().attackDamage;
            PlayerCombat.projectileDamage = myPrefab.GetComponent<difficulty>().projectileDamage;
            Destroy(other.gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coins")
        {
            coins(other.GetComponent<CollectibleController>().CoinsAmount);
            print($"coins {Coins}");
            coinsText.text = Coins.ToString();
            other.GetComponent<CollectibleController>().DestroyAndSong();
        }
        if (other.gameObject.tag == "armor")
        {
            armor(other.GetComponent<CollectibleController>().ArmorAmount);
            print($"armor {Armor}");
            armorText.text = Armor.ToString();
            other.GetComponent<CollectibleController>().DestroyAndSong();
        }
        if (other.gameObject.tag == "strength")
        {

            strength(other.GetComponent<CollectibleController>().StrengthAmount);
            print($"strength {Strength}");
            strengthText.text = Strength.ToString();
            other.GetComponent<CollectibleController>().DestroyAndSong();
        }
        if (other.gameObject.tag == "heal")
        {
            if (life < maxlife)
            {
                Heal(other.GetComponent<CollectibleController>().HealAmount);
                print($"life {life}");
                other.GetComponent<CollectibleController>().DestroyAndSong();
            }
        }
    }


    void coins(int ManaAmount)
    {
        Coins += ManaAmount;
    }
    void armor(int ArmorAmount)
    {
        Armor += ArmorAmount;
    }
    void strength(int StrengthAmount)
    {
        Strength += StrengthAmount;
    }
    void Heal(int healAmount)
    {
        life += healAmount;
        if (life > maxlife)
            life = maxlife;
    }
    public void degat(int damage)
    {
        damage -= Armor;
        if (damage < 0)
            damage = 0;
        life -= damage;
        animator.SetTrigger("Hurt");
        if (life <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        animator.SetBool("IsDead", true);
        playerController.maxSpeed = 0f;

        this.enabled = false;

       
    }

    private void manaRegen()
    {
        if (Coins - coinsPalierDamageMana >= 10)
        {
            PlayerCombat.projectileDamage += 1;
            coinsPalierDamageMana += 10;
        }
            
        if (Coins - coinsPalierRegenRate >= 100)
        {
            regenRate *= 2;
            coinsPalierRegenRate += 100;
        }
            
        if (Mana >= maxMana)
        {
            
        }
        else
        {
            Mana += regenRate;
        }
            
    }

    private void DestroyPlayer()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Destroy(transform.gameObject);
    }

   
}
