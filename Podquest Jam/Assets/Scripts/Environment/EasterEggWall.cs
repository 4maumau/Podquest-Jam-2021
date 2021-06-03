using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EasterEggWall : MonoBehaviour
{
    SpriteRenderer wallRenderer;
    public static float duration = 0.3f;

    private void Start()
    {
        wallRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        wallRenderer.DOFade(0, duration);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        wallRenderer.DOFade(1, duration);
    }
}
