using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private bool canInteract = false;
    
    private float originalScale;
    public float scaleUp = 1f;
    public float time = .2f;
    public AudioSource doorSFX;


    public Transform arrowTransform;
    public SpriteRenderer arrowSprite;

    void Start()
    {
        originalScale = arrowTransform.localScale.x;
    }

    void Update()
    {
        if(canInteract && Input.GetButtonDown("Interact"))
        {
            print("next phase");
            doorSFX.Play();
            GameManager.instance.NextLevel();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        arrowTransform.DOScale(scaleUp, time);
        arrowSprite.DOFade(1, time);

        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        arrowTransform.DOScale(originalScale, time);
        arrowSprite.DOFade(0, time);

        canInteract = false;
    }
}
