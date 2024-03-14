using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon")]
    public WeaponController currentWeapon;
    private void Awake()
    {
        if (currentWeapon)
        {
            currentWeapon.Initialise(this);
        }
    }
}
