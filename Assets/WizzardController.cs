﻿using UnityEngine;

public class WizzardController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    public float moveForce = 30f;
    public float maxSpeed = 1f;
    public float jumpForce = 1f;
    public Transform groundCheck;
    public GameObject FireballBallistic;
    public GameObject FireballStraight;
    public GameObject FireballTime;
    private bool inputEnabled;

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Activate()
    {
        inputEnabled = true;
    }

    void Deactivate()
    {
        inputEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputEnabled)
        {

        GameObject fireball = null;
        if (Input.GetKeyDown(KeyCode.F))
        {
            fireball = (GameObject)Instantiate<GameObject>(FireballBallistic);
            fireball.transform.position = this.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            fireball = (GameObject)Instantiate<GameObject>(FireballStraight);
            fireball.transform.position = this.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            fireball = (GameObject)Instantiate<GameObject>(FireballTime);
            fireball.transform.position = this.transform.position;
        }

        if (fireball != null)
        {
            
            if (facingRight)
            {
                var rigidBodyFireball = fireball.GetComponent<Rigidbody2D>();
                rigidBodyFireball.AddForce(new Vector2(300f, 300f));
            }
            else
            {
                var rigidBodyFireball = fireball.GetComponent<Rigidbody2D>();
                rigidBodyFireball.AddForce(new Vector2(-300f, 300f));
            }
        }

        }
    }

    void FixedUpdate()
    {
        if (inputEnabled)
        {
            float h = Input.GetAxis("Horizontal");

            //anim.SetFloat("Speed", Mathf.Abs(h));
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
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}