using System.Collections;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected int damageAmount = 10;
    [SerializeField] protected Transform player;
    [SerializeField] protected int damageToPlayer = 10;
    [SerializeField] protected float attackCooldown = 1f;
    private float lastAttackTime;

    protected int currentHealth;
    protected Renderer enemyRenderer;
    protected Color originalColor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time - lastAttackTime >= attackCooldown)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);
                lastAttackTime = Time.time;
            }
        }
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        enemyRenderer = GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }

        if (player == null && GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    protected virtual void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer() //this is the script for the enemy to chase the player
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position);
        direction.y = 0f;

        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        transform.forward = direction.normalized;
    }


    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (enemyRenderer != null)
        {
            StartCoroutine(FlashRed());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected IEnumerator FlashRed() //handles the player flashing red, when damaged and then returning back to original colour
    {
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyRenderer.material.color = originalColor;
    }
}
