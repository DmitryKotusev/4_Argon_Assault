using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")]
    [SerializeField]
    float xSpeed = 4f;
    [Tooltip("In m")]
    [SerializeField]
    float xRange = 5f;
    [Tooltip("In ms^-1")]
    [SerializeField]
    float ySpeed = 4f;
    [Tooltip("In m")]
    [SerializeField]
    float yRange = 3f;

    void Update()
    {
        HandleXInput();
        HandleYInput();
        HandleRotation();
    }

    private void HandleXInput()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;

        transform.localPosition = new Vector3(
            Mathf.Clamp(xOffsetThisFrame + transform.localPosition.x, -xRange, xRange),
            transform.localPosition.y,
            transform.localPosition.z
       );
    }

    private void HandleYInput()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            Mathf.Clamp(yOffsetThisFrame + transform.localPosition.y, -yRange, yRange),
            transform.localPosition.z
       );
    }

    private void HandleRotation()
    {

    }
}
