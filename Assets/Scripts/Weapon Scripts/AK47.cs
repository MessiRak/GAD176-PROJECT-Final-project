using TMPro;
using UnityEngine;
using System.Collections;

public class AK47 : Weapon
{
    [SerializeField] private float projectileSpeed = 30f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] AudioClip gunShotSound; //mp3 goes here
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private int currentAmmo;
    [SerializeField] private TMP_Text ammoText;

    private bool isReloading = false;
    private AudioSource audioSource;

    float timer = 0;

    void Start()
    {
        fireRate = 0.05f;
        damage = 5;
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
            if (Input.GetMouseButton(0) && timer >= fireRate && currentAmmo > 0)
            {
                Fire();
                timer = 0;
                currentAmmo--;
                UpdateAmmoUI();

                if (gunShotSound != null)
                {
                    audioSource.PlayOneShot(gunShotSound); //playes gun sound
                }

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload()); //reloads the weapon back to full ammo
            }
        }
    }

    public void Fire()
    {
        FireProjectile(bulletPrefab, projectileSpeed); //shoots the bullet prefab
    }

    protected override void FireProjectile(GameObject bulletPrefab, float projectileSpeed)
    {
        base.FireProjectile(bulletPrefab, projectileSpeed);
    }

    IEnumerator Reload() //reload function
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
