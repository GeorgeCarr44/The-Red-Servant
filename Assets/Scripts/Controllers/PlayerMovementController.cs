using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Spell PrimarySpell;
    public Spell SecondarySpell;

    public float MoveSpeed;
    
    public Vector2 MovementDirection { get; private set; }
    public Vector2 AimDirection { get; private set; }

    private GameControls controls;
    private Rigidbody2D rb;
    private PlayerAnimator playerAnimator;
    private void Awake()
    {
        controls = new GameControls();

        controls.Player.CastPrimary.performed += ctx => PrimaryInvoke(); //call spells from spell management
        controls.Player.CastSecondary.performed += ctx => SecondaryInvoke();
        controls.Player.Move.canceled += ctx => MovementDirection = Vector2.zero;
        controls.Player.Move.performed += ctx => MovementDirection = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => MovementDirection = Vector2.zero;
        controls.Player.Look.performed += ctx => AimDirection = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => AimDirection = Vector2.zero;
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
        Debug.Log("PrimaryInvoke");
        if (PrimarySpell != null)
        {
            Debug.Log("has spell");
            PrimarySpell.Cast();
        }
        else
        {
            //Play poof noise and effect
            throw new NotImplementedException();
        }

    }
    private void SecondaryInvoke()
    {
        if (SecondarySpell != null)
        {
            SecondarySpell.Cast();
        }
        else
        {
            //Play poof noise and effect
            throw new NotImplementedException();
        }

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
