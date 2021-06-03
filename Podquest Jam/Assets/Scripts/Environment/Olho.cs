using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olho : MonoBehaviour
{
    private Transform player;

    private Vector3 center;
    public Transform pupila;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float speed = 1f;

    void Start()
    {
        center = transform.position;
        

        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
            LookAtPlayer();
    }

    void LookAtPlayer()
    {
        Vector2 lookDir = (player.position - center).normalized;
        
            
        pupila.position = Vector2.MoveTowards(pupila.position, (Vector2) center + (lookDir * radius), speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
