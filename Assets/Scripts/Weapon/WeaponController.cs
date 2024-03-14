using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static Models;

public class WeaponController : MonoBehaviour
{
    public WeaponSettingsModel settings;
    

    private Vector3 newWeaponRotation;
    private Vector3 newWeaponRotationVelocity;

    private Vector3 targetWeaponRotation;
    private Vector3 targetWeaponRotationVelocity;
    private void Start()
    {
        newWeaponRotation = transform.localRotation.eulerAngles;
    }
    public void ProcessWeaponMoveWithCamera(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        targetWeaponRotation.x -= (mouseY * Time.deltaTime) * settings.SwayAmount;
        targetWeaponRotation.y += (mouseX * Time.deltaTime) * settings.SwayAmount;

        targetWeaponRotation.x = Mathf.Clamp(targetWeaponRotation.x, -settings.SwayClampX, settings.SwayClampX);
        targetWeaponRotation.y = Mathf.Clamp(targetWeaponRotation.y, -settings.SwayClampY, settings.SwayClampY);


        targetWeaponRotation = Vector3.SmoothDamp(targetWeaponRotation, Vector3.zero,ref targetWeaponRotationVelocity, settings.SwayResetSmoothing);
        newWeaponRotation = Vector3.SmoothDamp(newWeaponRotation, targetWeaponRotation, ref newWeaponRotationVelocity, settings.SwaySmoothing);
        transform.localRotation = Quaternion.Euler(newWeaponRotation);

    }

}
