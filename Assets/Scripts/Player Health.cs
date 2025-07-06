using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText; // Reference to UI text element

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; //if enemy collides with player it subtracts health by amount of damage dealt by the enemy
        Debug.Log("Player took damage: " + amount); 

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die(); //if player health reaches 0, destroys player object
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player Died!"); //death message
        gameObject.SetActive(false);
    }
}
