using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In mps")][SerializeField] float xSpeed = 20f;
    [Tooltip("In mps")] [SerializeField] float xRange = 10f;
    [Tooltip("In mps")] [SerializeField] float yRange = 8f;
    [SerializeField] GameObject fire;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -.01f;
    [SerializeField] float positionYawFactor = .01f;

    [Header("Control-throw Based")]
    [SerializeField] float controlRollFactor = -.01f;
    [SerializeField] float controlPitchFactor = -.01f;

    float xThrow;
    float yThrow;

    bool controlsEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
        {
            MoveXY();
            RotatePlayer();
            ProcessFiring();
        }
    }

   void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetFireActive(true);
        }
        else
        {
            SetFireActive(false); 
        }
    }

    private void SetFireActive(bool isActive){
       // fire.SetActive(true); // instantiate our fire object
        var emissionModule = fire.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;

    }


    void OnPlayerDeath() // called by string reference
    {
        controlsEnabled = false;
    }


    void MoveXY()
    {
        // Determine x position
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float adjustedXPos = Mathf.Clamp(rawNewXPos, -xRange - 4, xRange);

        // Determine y position 
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * xSpeed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float adjustedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        // Process transform for X and Y position
        transform.localPosition = new Vector3(adjustedXPos, adjustedYPos, transform.localPosition.z);
    }

    void RotatePlayer()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        // Quaternion.Euler (x , y , z) or (pitch, yaw, roll) 
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
