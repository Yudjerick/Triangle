using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions OnFoot;
    public PlayerInput.WeaponActions Weapon;

    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerWeapon weapon;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;
        Weapon = playerInput.Weapon;
        
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        weapon = GetComponent<PlayerWeapon>();
        weapon.controller.Initialise(motor);

        Weapon.Shoot.performed += ctx => weapon.controller.StartShoot();
        Weapon.Shoot.canceled += ctx => weapon.controller.CancelShoot();

        OnFoot.Jump.performed += ctx => motor.Jump();

        OnFoot.Crouch.performed += ctx => motor.Crouch();

        OnFoot.Sprint.performed += ctx => motor.Sprint();

        Cursor.visible = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movement action
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate() {
        weapon.controller.ProcessWeaponMoveWithCamera(OnFoot.Look.ReadValue<Vector2>(), OnFoot.Movement.ReadValue<Vector2>());

        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable() {
        OnFoot.Enable();
        Weapon.Enable();
    }
    private void OnDisable() {
        OnFoot.Disable();
        Weapon.Disable();
    }
}
