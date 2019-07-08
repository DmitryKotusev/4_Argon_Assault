using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
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
    [SerializeField]
    GameObject[] guns;

    [Header("Screen-position based")]
    [SerializeField]
    float positionPitchFactor = -5f;
    [SerializeField]
    float positionYawFactor = 6f;

    [Header("Control-throw based")]
    [SerializeField]
    float controlPitchFactor = -20f;
    [SerializeField]
    float controlYawFactor = -20f;

    float xThrow;
    float yThrow;

    bool isControlEnabled = true;

    void Update()
    {
        if (isControlEnabled)
        {
            HandleXInput();
            HandleYInput();
            HandleRotation();
            HandleFiring();
        }
    }

    private void HandleFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGuns(true);
        }
        else
        {
            SetGuns(false);
        }
    }

    private void SetGuns(bool flag)
    {
        foreach (GameObject gun in guns)
        {
            ParticleSystem particles = gun.GetComponent<ParticleSystem>();
            ParticleSystem.EmissionModule emission = particles.emission;
            emission.enabled = flag;
        }
    }

    private void HandleXInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;

        transform.localPosition = new Vector3(
            Mathf.Clamp(xOffsetThisFrame + transform.localPosition.x, -xRange, xRange),
            transform.localPosition.y,
            transform.localPosition.z
       );
    }

    private void HandleYInput()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            Mathf.Clamp(yOffsetThisFrame + transform.localPosition.y, -yRange, yRange),
            transform.localPosition.z
       );
    }

    private void HandleRotation()
    {
        float pitch =
            transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlYawFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
}
