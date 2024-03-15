using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static Models;

public class WeaponController : MonoBehaviour
{

    [Header("References")]
    public Animator weaponAnimator;

    [Header("Settings")]
    public WeaponSettingsModel settings;
    

    private Vector3 newWeaponRotation;
    private Vector3 newWeaponRotationVelocity;

    private Vector3 targetWeaponRotation;
    private Vector3 targetWeaponRotationVelocity;

    private Vector3 newWeaponMovementRotation;
    private Vector3 newWeaponMovementRotationVelocity;

    private Vector3 targetWeaponMovementRotation;
    private Vector3 targetWeaponMovementRotationVelocity;

    private PlayerMotor motor;
    private bool isInitialised = false;
    public void Initialise(PlayerMotor motor)
    {
        this.motor = motor;
        isInitialised = true;
    }

    private void Start()
    {
        newWeaponRotation = transform.localRotation.eulerAngles;
    }
    public void ProcessWeaponMoveWithCamera(Vector2 input_view, Vector2 input_move)
    {
        if (!isInitialised)
        {
            return;
        }

        weaponAnimator.speed = motor.weaponAnimationSpeed;

        float mouseX = input_view.x;
        float mouseY = input_view.y;
        targetWeaponRotation.x -= (mouseY * Time.deltaTime) * settings.SwayAmount;
        targetWeaponRotation.y += (mouseX * Time.deltaTime) * settings.SwayAmount;

        targetWeaponRotation.x = Mathf.Clamp(targetWeaponRotation.x, -settings.SwayClampX, settings.SwayClampX);
        targetWeaponRotation.y = Mathf.Clamp(targetWeaponRotation.y, -settings.SwayClampY, settings.SwayClampY);
        targetWeaponRotation.z = targetWeaponRotation.y;

        targetWeaponRotation = Vector3.SmoothDamp(targetWeaponRotation, Vector3.zero,ref targetWeaponRotationVelocity, settings.SwayResetSmoothing);
        newWeaponRotation = Vector3.SmoothDamp(newWeaponRotation, targetWeaponRotation, ref newWeaponRotationVelocity, settings.SwaySmoothing);

        targetWeaponMovementRotation.z = settings.MovementSwayX * input_move.x;
        targetWeaponMovementRotation.x = -settings.MovementSwayY * input_move.y;

        targetWeaponMovementRotation = Vector3.SmoothDamp(targetWeaponMovementRotation, Vector3.zero,ref targetWeaponMovementRotation, settings.MovementSwaySmoothing);
        newWeaponMovementRotation = Vector3.SmoothDamp(newWeaponMovementRotation, targetWeaponMovementRotation, ref newWeaponMovementRotationVelocity, settings.MovementSwaySmoothing);



        transform.localRotation = Quaternion.Euler(newWeaponRotation + newWeaponMovementRotation);
    }

}
