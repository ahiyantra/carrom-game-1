using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    public Camera mainCamera;
    float width = Screen.width;
    float height = Screen.height;

    // Start is called before the first frame update
    void Start()
    {
        if (width == 1080 && height == 2460)
        {
            mainCamera.aspect = 1f / 2f; // width divided by height
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
