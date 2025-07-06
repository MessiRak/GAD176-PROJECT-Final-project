using TMPro;
using UnityEngine;
using System.Collections;

public class Glock : Weapon
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] AudioClip gunShotSound; //mp3 goes here
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int currentAmmo;
    [SerializeField] private TMP_Text ammoText; //glock specific text

    private bool isReloading = false;
    private AudioSource audioSource;

    float timer = 0;

    void Start()
    {
        fireRate = 0.1f;
        damage = 10;
        range = 50f;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (Input.GetMouseButtonDown(0) && timer >= fireRate && currentAmmo > 0) //single press of left click
            {
                Fire();
                timer = 0;
                currentAmmo--;
                UpdateAmmoUI();

                if (gunShotSound != null)
                {
                    audioSource.PlayOneShot(gunShotSound); //plays gun sound when bullet is shot
                }

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }
    }

    public void Fire()
    {
        FireProjectile(bulletPrefab, projectileSpeed);
    }

    protected override void FireProjectile(GameObject bulletPrefab, float projectileSpeed)
    {
        base.FireProjectile(bulletPrefab, projectileSpeed);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        isReloading = false;
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = $"Ammo: {currentAmmo} / {maxAmmo}";
        }
    }
}
