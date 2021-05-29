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


    private float xMovement;
    private Rigidbody2D rb;

    public LayerMask whatIsGround;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private float checkGroundOffset = .4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
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

            DoSqueeze(xSqueeze, ySqueeze, squeezeTime);
            

            //jump sound
            //audioManager.PlaySound("PlayerJump");
            // create and destroy the dust effect
            //GameObject DustEffect = Instantiate(dustPrefab, legsPosition.transform.position, Quaternion.identity);
            //Destroy(DustEffect, 1f);
        }
    }

    void DoSqueeze(float _xSqueeze, float _ySqueeze, float _seconds)
    {
        StartCoroutine(JumpSqueeze(_xSqueeze, _ySqueeze, _seconds));
    }

    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, checkGroundOffset, whatIsGround);
        return raycastHit.collider != null;
    }
}
