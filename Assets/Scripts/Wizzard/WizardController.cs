using Assets.Scripts.Spells;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool IsActive { get; set; }
    [HideInInspector] public int Angle;
    public float moveForce = 30f;
    public float maxSpeed = 1f;
    public int FireStrength = 500;
    
    private int currentSpell;
    private Rigidbody2D rb2d;
    public Wizard wizard;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Activate()
    {
        IsActive = true;
    }

    void Deactivate()
    {
        IsActive = false;
    }
    
    void Update()
    {
        if (IsActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (wizard.Spells.Count > 0)
                {
                    GameObject fireball = SpellFactory.GetSpell(wizard.Spells[currentSpell]);

                    if (fireball != null)
                    {
                        Spell spell = fireball.GetComponent<Spell>();
                        spell.Activate();
                        wizard.Spells.Remove(wizard.Spells[currentSpell]);
                    }
                }
                else
                {
                    Debug.Log("The wizard doesn't have any spells left");
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (IsActive)
        {
            HandleCrosshair();
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");

        if (h == 0.0) rb2d.velocity = new Vector2();
        if (wizard.Condition > 0)
        {

            if (h * rb2d.velocity.x < maxSpeed)
            {
                rb2d.AddForce(Vector2.right * h * moveForce);
            }
            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            {
                wizard.Condition -= 1;
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
                Debug.Log("Condition " + wizard.Condition);
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