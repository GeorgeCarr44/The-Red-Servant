using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Spell PrimarySpell;
    public Spell SecondarySpell;

    public float MoveSpeed;
    
    public Vector2 MovementDirection { get; private set; }
    public Vector2 AimDirection { get; private set; }

    private PS4Controls controls;
    private Rigidbody2D rb;
    private PlayerAnimator playerAnimator;
    private void Awake()
    {
        controls = new PS4Controls();

        controls.Gameplay.PrimarySpell.performed += ctx => PrimaryInvoke(); //call spells from spell management
        controls.Gameplay.SecondarySpell.performed += ctx => SecondaryInvoke();
        controls.Gameplay.Movement.performed += ctx => MovementDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => MovementDirection = Vector2.zero;
        controls.Gameplay.Look.performed += ctx => AimDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => AimDirection = Vector2.zero;
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Movement
        MoveCharacter(MovementDirection);
        AimCharacter(AimDirection);
    }
    private void MoveCharacter(Vector2 direction)
    {
        rb.AddForce(MovementDirection * MoveSpeed);
    }

    private void AimCharacter(Vector2 aimDirection)
    {
        if(aimDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.MoveRotation(angle);
        }
    }

    private void PrimaryInvoke()
    {

        if (PrimarySpell != null)
        {
            PrimarySpell();
        }
        else
        {
            //Play poof noise and effect
            throw new NotImplementedException();
        }

    }
    private void SecondaryInvoke()
    {
        if (secondarySpell != null)
        {
            secondarySpell.Cast();
        }
        else
        {
            //Play poof noise and effect
            throw new NotImplementedException();
        }

    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
