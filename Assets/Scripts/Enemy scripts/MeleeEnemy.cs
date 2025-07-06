using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    protected override void Start()
    {
        maxHealth = 150;
        damageAmount = 10;
        base.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player!");
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }

}

