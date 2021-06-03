using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BallOfThought : MonoBehaviour
{
    public float scaleUp = 1f;
    public float time = .2f;

    private float originalScale;

    public TextMeshProUGUI fraseTxt;
    public FraseDisplay frase;
    public CanvasGroup canvasGroup;

    void Start()
    {
        originalScale = transform.localScale.x;

        fraseTxt.text = frase.conteudo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.DOScale(scaleUp, time);
        canvasGroup.DOFade(1, time);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.DOScale(originalScale, time);
        canvasGroup.DOFade(0, time);
    }
}
