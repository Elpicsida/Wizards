using Assets.Scripts.Spells;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WizzardController : MonoBehaviour
{
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool InputEnabled;
    [HideInInspector] public int Angle;
    public float moveForce = 30f;
    public float maxSpeed = 1f;
    public int FireStrength = 500;
    
    private int currentSpell;
    private Rigidbody2D rb2d;
    private Wizard wizardStats;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        wizardStats = GetComponent<Wizard>();
    }

    void Activate()
    {
        InputEnabled = true;
    }

    void Deactivate()
    {
        InputEnabled = false;
    }
    
    void Update()
    {
        if (InputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (wizardStats.Spells.Count > 0)
                {
                    GameObject fireball = SpellFactory.GetSpell(wizardStats.Spells[currentSpell]);

                    if (fireball != null)
                    {
                        Spell spell = fireball.GetComponent<Spell>();
                        spell.Activate();
                        wizardStats.Spells.Remove(wizardStats.Spells[currentSpell]);
                    }
                }
                else
                {
                    Debug.Log("The wizzard doesn't have any spells left");
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (InputEnabled)
        {
            HandleCrosshair();
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");

        if (h == 0.0) rb2d.velocity = new Vector2();
        if (wizardStats.Condition > 0)
        {

            if (h * rb2d.velocity.x < maxSpeed)
            {
                rb2d.AddForce(Vector2.right * h * moveForce);
            }
            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                wizardStats.Condition -= 1;
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
                Debug.Log("Condition " + wizardStats.Condition);
            }
                
        }

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }
    
    private void HandleCrosshair()
    {
        float upDown = Input.GetAxis("Vertical");

        if (upDown != 0)
        {
            if (upDown > 0)
            {
                if (facingRight)
                {
                    if (Angle >= 270 || Angle < 90) Angle++;
                }
                else
                {
                    if (Angle <= 270 && Angle > 90) Angle--;
                }
            }
            else if (upDown < 0)
            {
                if (facingRight)
                {
                    if (Angle > 270 || Angle <= 90) Angle--;
                }
                else
                {
                    if (Angle < 270 && Angle >= 90) Angle++; ;
                }
            }
            Angle = (Angle + 360) % 360;
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        FlipAngle();
    }

    private void FlipAngle()
    {
        Angle = (540 - Angle) % 360; 
    }
}