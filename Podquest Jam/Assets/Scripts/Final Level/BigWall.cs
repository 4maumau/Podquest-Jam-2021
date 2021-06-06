using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWall : MonoBehaviour
{
    private bool moving = false;
    public float velocity = 6f;

    public float transitionTime = .5f;

    private float normalVelocity = 6f;
    private float slowVelocity = 4.5f;
    public float fastVelocity = 10f;

    private static float farDistance = 36f;
    private float closeDistance = 20f;

    public Transform target;

    void Start()
    {
        Invoke("StartMoving", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
        
        if (target != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);

            print("distance to player: " + distanceToPlayer + "velocity: " + velocity);

            if (distanceToPlayer >= farDistance)
            {
                velocity = fastVelocity;

            }
            else if (distanceToPlayer <= closeDistance)
                velocity = Mathf.Lerp(velocity, slowVelocity, transitionTime * Time.deltaTime);
            else velocity = normalVelocity;

        }

    }

    public void StartMoving()
    {
        moving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // if player, kill it.
            collision.gameObject.GetComponent<PlayerAnimation>().OnDeath();
        }
    }

}
