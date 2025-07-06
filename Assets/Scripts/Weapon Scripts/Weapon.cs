using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected int damage;
    protected float range;
    protected float fireRate;
    protected float reloadTime;

    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Camera playerCam;

    protected virtual void FireProjectile(GameObject bulletPrefab, float projectileSpeed)
    {
        if (playerCam == null) return;

        // Get direction from camera
        Vector3 shootDirection = playerCam.transform.forward;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
        bullet.GetComponent<Bullet>().Initialize(projectileSpeed, range, gameObject);
    }

    protected void FireHitScan()
    {
        if (playerCam == null) return;

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }
}
