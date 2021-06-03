using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // if player, kill it.
            collision.gameObject.GetComponent<PlayerAnimation>().OnDeath();
        }
    }
}
