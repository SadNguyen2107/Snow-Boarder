using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delaySec;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    private PlayerController playerController;
    private bool isCrash = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log("Crash Our Head!");

            if (!isCrash)
            {
                // Play the Particle System
                this.crashEffect.Play();

                // Get the Component and play crashSFX
                GetComponent<AudioSource>().PlayOneShot(crashSFX);

                // Disable Control in PlayerController
                GetComponent<PlayerController>().DisableControls();

                // Change the Status of the Crash
                isCrash = true;

                // Wait a sec then load new scene
                Invoke(nameof(ReloadScene), this.delaySec);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
