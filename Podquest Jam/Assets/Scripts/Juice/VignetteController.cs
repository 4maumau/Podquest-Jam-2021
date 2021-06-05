using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;

    private float intensity;
    public float minIntensity;
    public float maxIntensity = 1f;


    void Start()
    {
        volume.profile.TryGet(out vignette);

        vignette.intensity.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeIntensity()
    {
        float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, intensity);
    }

}
