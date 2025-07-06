using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    protected override void Start()
    {
        maxHealth = 80;
        base.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player!"); //debug statement, to check if its working
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
        }
    }

}
