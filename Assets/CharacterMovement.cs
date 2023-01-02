using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rt;
    public float speed;
    public float jump;
    int jumpAmount = 0;
    public int maxJump;
    public Animator rx;
    public ParticleSystem particles;
    void Start()
    {
        rt = gameObject.GetComponent<Rigidbody2D>();
        rx.SetFloat("Speed", 0);
        jumpAmount = maxJump;
        rx.SetBool("Ajump", false);
        ParticleSystem particles = GetComponent<ParticleSystem>();
    }
    private void Update()
         {
          if (Input.GetKeyDown(KeyCode.W))
          {
            if (jumpAmount > 0)
            {
                rx.SetBool("Ajump", true);
                Jump();     
            } 
          }
            fart();
         }

        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.W))
       {
            rx.SetBool("Ajump", true);
            rt.AddForce(jump * transform.up, ForceMode2D.Impulse);
            jumpAmount -= 1;
           

        }
        }
        void FixedUpdate()
        {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == -1) 
        {
            rt.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            particles.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            horizontal = Input.GetAxisRaw("Horizontal");
            rt.velocity = new Vector3(horizontal * speed, rt.velocity.y, 0);
            rx.SetFloat("Speed", 1);
            rx.SetBool("Ajump", false);

        }
        else if (horizontal == 1)
		{
            rt.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            particles.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            horizontal = Input.GetAxisRaw("Horizontal");
            rt.velocity = new Vector3(horizontal * speed, rt.velocity.y, 0);
            rx.SetFloat("Speed", 1);
            rx.SetBool("Ajump", false);
        }
        else if(horizontal == 0)
		{
            rt.velocity = new Vector2(0, rt.velocity.y);
            rx.SetFloat("Speed", 0);
            rx.SetBool("Ajump", false);

        }
        }   
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "isGround")
            {
                rx.SetBool("Ajump", false);
                jumpAmount = maxJump;
            }
		    
        }
       void fart()
	   {
        particles.Stop();

        if (Input.GetMouseButtonDown(0))
        {
           
            particles.Play();

        }
        else if (Input.GetMouseButtonUp(0))
		{
            particles.Play();
        }
        else
		{
            particles.Stop();

        }
    }
    }
