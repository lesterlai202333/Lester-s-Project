using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public static float playerHealth; //declaring variables

    void Start()
    {
        playerHealth = 100f; //sets the player health to 100 at the start of the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !GameOver.dead) //currently used to test the health/damage system
        {
            TakeDamage(40); //takes 40 damage, and a message in the debug log seciton
            Debug.Log("damage taken");
        }
        if (Input.GetKeyDown(KeyCode.O) && !GameOver.dead)
        {
            Heal(40); //heals by 40, and a message in the debug log section
            Debug.Log("Healed");
        }
    }

    public void TakeDamage (float damage) //defining take damage, and adjusting the fillamount of the health bar
    {
        playerHealth -= damage;
        healthBar.fillAmount = playerHealth / 100f;
    }

    public void Heal(float healingAmount)//defining healing, and adjusting the fill amount of the health bar
    {
        playerHealth += healingAmount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100); //this code ensures that the player health is always in range of 0 -- 100
        healthBar.fillAmount = playerHealth / 100f;
    }
}
