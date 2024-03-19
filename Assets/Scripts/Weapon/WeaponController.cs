using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static Models;

public class WeaponController : MonoBehaviour
{
    public Camera playerCamera;

    //Shooting
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;

    //Burst
    public int bulletsPerBurst = 3;
    public int burstBulletsLeft;

    //Spread
    public float spreadIntesity;

    //Bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;

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


    private void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletsPerBurst;

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

        targetWeaponMovementRotation = Vector3.SmoothDamp(targetWeaponMovementRotation, Vector3.zero,ref targetWeaponMovementRotationVelocity, settings.MovementSwaySmoothing);
        newWeaponMovementRotation = Vector3.SmoothDamp(newWeaponMovementRotation, targetWeaponMovementRotation, ref newWeaponMovementRotationVelocity, settings.MovementSwaySmoothing);



        transform.localRotation = Quaternion.Euler(newWeaponRotation + newWeaponMovementRotation);
    }

    private void Update()
    {
        Debug.Log(isShooting);
        if (readyToShoot && isShooting)
        {
            burstBulletsLeft = bulletsPerBurst;
            FireWeapon();
            if (currentShootingMode == ShootingMode.Single || currentShootingMode == ShootingMode.Burst)
            {
                isShooting = false;
            }
        }
    }

    public void FireWeapon()
    {
        readyToShoot = false;

        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        bullet.transform.forward = shootingDirection;

        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));


        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }

        if (currentShootingMode == ShootingMode.Burst && burstBulletsLeft > 1)
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingDelay);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    private Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        } 
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - bulletSpawn.position;

        float x = UnityEngine.Random.Range(-spreadIntesity, spreadIntesity);
        float y = UnityEngine.Random.Range(-spreadIntesity, spreadIntesity);

        return direction + new Vector3(x, y, 0);
    }

    public void StartShoot()
    {
        isShooting = true;
    }

    public void CancelShoot()
    {
        if (currentShootingMode == ShootingMode.Auto)
        {
            Debug.Log("Cancel");

            isShooting = false;
        }
    }


    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

}
