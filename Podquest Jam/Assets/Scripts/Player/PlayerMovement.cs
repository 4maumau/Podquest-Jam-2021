using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float jumpForce;
    [SerializeField] private float hangTime = 0.1f;
    private float hangCounter;

    [Header("Squeeze Time")]
    [SerializeField] private float xSqueeze = .4f;
    [SerializeField] private float ySqueeze = 1.2f;
    [SerializeField] private float squeezeTime = .5f;


    public float xMovement;
    private Rigidbody2D rb;

    public LayerMask whatIsGround;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private float checkGroundOffset = .4f;

    private PlayerAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();

        anim = GetComponent<PlayerAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");

        Jump();

        //handles coyotee time counter
        if (IsGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMovement * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        // jump on pc
        if (Input.GetButtonDown("Jump") && hangCounter > 0)
        {
            rb.velocity = Vector2.up * jumpForce;

            anim.DoSqueeze(xSqueeze, ySqueeze, squeezeTime);

            //jump sound
            //audioManager.PlaySound("PlayerJump");
            // create and destroy the dust effect
            //GameObject DustEffect = Instantiate(dustPrefab, legsPosition.transform.position, Quaternion.identity);
            //Destroy(DustEffect, 1f);
        }
    }

    

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, checkGroundOffset, whatIsGround);
        return raycastHit.collider != null;
    }
}
