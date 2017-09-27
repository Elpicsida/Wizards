using System;
using UnityEngine;

public class WizzardController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    public float moveForce = 30f;
    public float maxSpeed = 1f;
    public GameObject FireballBallistic;
    public GameObject FireballStraight;
    public GameObject FireballTime;
    [HideInInspector] public bool InputEnabled;
    [HideInInspector] public int Angle;
    private int FireStrength = 500;

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
            GameObject fireball = null;
            if (Input.GetKeyDown(KeyCode.F))
            {
                fireball = (GameObject)Instantiate<GameObject>(FireballBallistic);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                fireball = (GameObject)Instantiate<GameObject>(FireballStraight);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                fireball = (GameObject)Instantiate<GameObject>(FireballTime);
            }

            if (fireball != null)
            {
                var x = FireStrength * Mathf.Cos(Angle * Mathf.Deg2Rad);
                var y = FireStrength * Mathf.Sin(Angle * Mathf.Deg2Rad);
                int directionNum = facingRight ? 1 : -1;
                fireball.transform.position = this.transform.position + new Vector3(directionNum * 0.4f, 0.4f, 0f);
                var rigidBodyFireball = fireball.GetComponent<Rigidbody2D>();
                rigidBodyFireball.AddForce(new Vector2(x, y));
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
        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

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