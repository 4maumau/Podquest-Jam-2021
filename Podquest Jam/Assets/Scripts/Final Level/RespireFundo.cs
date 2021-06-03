using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class RespireFundo : MonoBehaviour
{
    public RectTransform outerCircle;
    public RectTransform innerCircle;
    

    [SerializeField] private float duration;

    public TextMeshProUGUI inspireTXT;
    private bool isExpiring = false;
    private float tempoRespirando;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        if (!isExpiring)
            Inpirando();
        else
            Expirando();
           
    }

    void Inpirando()
    {
        inspireTXT.text = "inspire";


        if (Input.GetButton("Interact"))
        {
            innerCircle.DOScale(4, duration).SetEase(Ease.Unset);
            tempoRespirando += Time.deltaTime;

        }
        else
        {
            innerCircle.DOScale(1, duration / 10).SetEase(Ease.Unset);
            tempoRespirando = 0;
        }

        if (tempoRespirando >= 5.5)
        {
            isExpiring = true;
            tempoRespirando = 0;
        }

    }
    void Expirando()
    {
        tempoRespirando += Time.deltaTime;
        if(tempoRespirando >= 5.5)
        {
            isExpiring = false;
        }

        inspireTXT.text = "expire";

        innerCircle.DOScale(1, duration).SetEase(Ease.Unset);
        

    }
}
