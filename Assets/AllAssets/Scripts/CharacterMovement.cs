using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rt;
    private int jumpAmount;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Ajump = Animator.StringToHash("Ajump");
    
    public float speed;
    public float jump;
    public int maxJump;
    public Animator rx;
    public ParticleSystem particles;

    private void Start()
    {
        rt = gameObject.GetComponent<Rigidbody2D>();
        rx.SetFloat(Speed, 0);
        jumpAmount = maxJump;
        rx.SetBool(Ajump, false);
       
        particles.Stop();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (jumpAmount > 0)
            {
                rx.SetBool(Ajump, true);
                Jump();     
            } 
        }
        
        Fart();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rx.SetBool(Ajump, true);
            rt.AddForce(jump * transform.up, ForceMode2D.Impulse);
            jumpAmount -= 1;
        }
    }
    
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // transfer this into update

        switch (horizontal)
        {
            case 1:
                MoveCharacterX(0);
                break;
            case 0:
                rt.velocity = new Vector2(0, rt.velocity.y);
                rx.SetFloat(Speed, 0);
                rx.SetBool(Ajump, false);
                break;
            case -1:
                MoveCharacterX(180f);
                break;
        }
    }

    private void MoveCharacterX(float directionX)
    {
        rt.transform.rotation = Quaternion.Euler(0f, directionX, 0f);
        particles.transform.rotation = Quaternion.Euler(0f, directionX, 0f);

        horizontal = Input.GetAxisRaw("Horizontal");
        rt.velocity = new Vector3(horizontal * speed, rt.velocity.y, 0);
        rx.SetFloat(Speed, 1);
        rx.SetBool(Ajump, false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision) // adjust this
    {
        if (!collision.gameObject.CompareTag("isGround")) return;
        rx.SetBool(Ajump, false);
        jumpAmount = maxJump;
    }
    
    private void Fart()
    {
        if (Input.GetMouseButtonDown(0))
            particles.Play();
        else if (Input.GetMouseButtonUp(0))
            particles.Stop();
    }
}
