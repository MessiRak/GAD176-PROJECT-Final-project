using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;

    private int currentWeaponIndex = 0;

    void Start()
    {
        ActivateWeapon(currentWeaponIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex < weapons.Length && weaponIndex != currentWeaponIndex)
        {
            weapons[currentWeaponIndex].SetActive(false);
            weapons[weaponIndex].SetActive(true);
            currentWeaponIndex = weaponIndex;
        }
    }

    private void ActivateWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == index);
        }
    }
}

