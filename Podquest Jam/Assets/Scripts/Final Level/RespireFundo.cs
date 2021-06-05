using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;

public class RespireFundo : MonoBehaviour
{
    public RectTransform outerCircle;
    public RectTransform innerCircle;
    public float vezesParaPassar;

    public Vector3 minScale;
    public Vector3 maxScale;

    [SerializeField] private float duration;

    public TextMeshProUGUI inspireTXT;
    private bool isExpiring = false;
    private float tempoRespirando;
    private int vezesRespirado = 0;

    void Start()
    {
        innerCircle.localScale = minScale;
        inspireTXT.text = "inspire";

    }

    // Update is called once per frame
    void Update()
    {
        tempoRespirando = math.clamp(tempoRespirando,0f,duration);
        if (isExpiring)
            Expirando();
        else
            Inpirando();
    }

    void Inpirando()
    {


        if (Input.GetButton("Interact"))
        {

            innerCircle.localScale = Vector3.Lerp(minScale, maxScale, tempoRespirando/duration);
            
            tempoRespirando += Time.deltaTime;
            if (tempoRespirando >= duration)
            {
                inspireTXT.text = "expire!";
            }

        }
        else
        {
            if (tempoRespirando >= duration)
            {
                isExpiring = true;
            }
            innerCircle.localScale = Vector3.Lerp(minScale, maxScale, tempoRespirando/duration);
            tempoRespirando -= Time.deltaTime;
        }

        

    }
    void Expirando()
    {
        tempoRespirando -= Time.deltaTime;
        if(tempoRespirando <= 0)
        {
            inspireTXT.text = "inspire";
            isExpiring = false;
            vezesRespirado++;
            if (vezesParaPassar <= vezesRespirado)
            {
                Debug.Log("ACABOu");
                //aqui faz o que for quando acabar.
            }
        }
        innerCircle.localScale = Vector3.Lerp(minScale, maxScale, tempoRespirando/duration);

        

    }
}
