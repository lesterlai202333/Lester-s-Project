using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public static float playerHealth;

    void Start()
    {
        playerHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !GameOver.dead)
        {
            TakeDamage(40);
            Debug.Log("damage taken");
        }
        if (Input.GetKeyDown(KeyCode.O) && !GameOver.dead)
        {
            Heal(40);
            Debug.Log("Healed");
        }
    }

    public void TakeDamage (float damage)
    {
        playerHealth -= damage;
        healthBar.fillAmount = playerHealth / 100f;
    }

    public void Heal(float healingAmount)
    {
        playerHealth += healingAmount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        healthBar.fillAmount = playerHealth / 100f;
    }
}
