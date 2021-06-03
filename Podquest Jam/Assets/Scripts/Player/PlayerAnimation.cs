using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer sprite;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;

    private Animator animator;


    [Header("Death Animation")]
    public GameObject deathFxPrefab;
    [SerializeField] float deathShakeIntensity = 4f;
    [SerializeField] float deathShakeTime = .5f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.xMovement != 0)
            sprite.flipX = playerMovement.xMovement < 0;

        //Starts Animations

        if (playerMovement.IsGrounded())
        {
            if (playerMovement.xMovement != 0)
            {
                animator.Play("PlayerRun");
            }
            else if (playerMovement.xMovement == 0)
            {
                animator.Play("PlayerIdle");
            }
        }
        else
        {
            if (rb.velocity.y > 0)
                animator.Play("PlayerJumpUp");
            else
                animator.Play("PlayerJumpDown");
        }
    }

    public void OnDeath()
    {
        CinemachineShakeController.instance.ShakeCamera(deathShakeIntensity, deathShakeTime);
        GameManager.instance.InvokeRestart(2f);

        GameObject deathFxAnim = Instantiate(deathFxPrefab, transform.position, Quaternion.identity);
        Destroy(deathFxAnim, 2f);

        
        Destroy(gameObject);
    }

   

    public void DoSqueeze(float _xSqueeze, float _ySqueeze, float _seconds)
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

}
