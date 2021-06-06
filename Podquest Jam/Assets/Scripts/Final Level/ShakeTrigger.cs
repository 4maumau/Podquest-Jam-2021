using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    bool wasTriggered = false;
    public float shakeIntensity = 7f;
    public float shakeTime = 1f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!wasTriggered)
        {
            wasTriggered = true;
            CinemachineShakeController.instance.ShakeCamera(shakeIntensity, shakeTime);
        }
    }
}
