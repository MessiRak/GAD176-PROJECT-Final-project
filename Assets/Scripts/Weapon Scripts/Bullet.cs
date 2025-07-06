using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float projectileSpeed;
    private float maxRange;
    private Vector3 startPosition;
    private GameObject weapon;

    public void Initialize(float speed, float range, GameObject w)
    {
        projectileSpeed = speed;
        maxRange = range;
        weapon = w;
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;

        // Destroy bullet if travelled further than maxRange
        if (Vector3.Distance(startPosition, transform.position) > maxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BaseEnemy enemy = other.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(20); // You can change this number based on weapon damage
        }

        Destroy(gameObject);
    }

}
