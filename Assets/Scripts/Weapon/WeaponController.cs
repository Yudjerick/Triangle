using UnityEngine;
using UnityEngine.Windows;
using static Models;

public class WeaponController : MonoBehaviour
{
    private PlayerWeapon characterWeapon;
    private InputManager inputManager;

    [Header("Settings")]
    public WeaponSettingsModel settings;

    private bool isInitialised;

    Vector3 newWeaponRotation;
    Vector3 newWeaponRotationVelocity;

    private void Start()
    {
        newWeaponRotation = transform.localRotation.eulerAngles;
    }

    public void Initialise(PlayerWeapon CharacterWeapon)
    {
        characterWeapon = CharacterWeapon;
        isInitialised = true;
    }

    private void Update()
    {
        if (!isInitialised)
        {
            return;
        }

        float mouseX = playerLook. input.x;
        float mouseY = input.y;
        //calculate rotation for looking up adn down
        newWeaponRotation.y -= (mouseY * Time.deltaTime) * settings.SwayAmount;
        newWeaponRotation.x = (mouseX * Time.deltaTime) * settings.SwayAmount;
        //rotate left and right
        transform.localRotation = Quaternion.Euler(newWeaponRotation);

    }
}
