using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InfiniteFall : MonoBehaviour
{


    private bool _active = true;
    
    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        Debug.DrawLine(new Vector3(position.x - 5, position.y, position.z), new Vector3(position.x + 5, position.y, position.z));
    }


    public void activate()
    {
        _active = true;
    }

    public void deactivate()
    {
        _active = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_active)
        {
            other.transform.position = transform.position;
            Camera.main.gameObject.transform.position = transform.position;
        }
    }
}
