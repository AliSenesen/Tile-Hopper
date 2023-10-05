using System;
using UnityEngine;


public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] private float colorChangeSpeed = .5f; 
    
    private float hueValue = 0f;

    private void Update()
    {
        ChangeColor();
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        transform.position =
            Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 3);
    }

    private void ChangeColor()
    {
        hueValue += colorChangeSpeed * Time.deltaTime;
        hueValue = Mathf.Repeat(hueValue, 1.0f); 

        Color newColor = Color.HSVToRGB(hueValue, 0.2f, 0.2f);
        mainCamera.backgroundColor = newColor;
    }
}