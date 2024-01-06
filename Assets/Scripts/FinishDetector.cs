using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] float delaySec;
    [SerializeField] ParticleSystem finishedParticleSystem;
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You finished!");

            // Get the Audio Source of the Audio Source
            GetComponent<AudioSource>().Play();

            // Show the Finished Effect
            this.finishedParticleSystem.Play();

            // Wait 2 sec then Load new Scene
            Invoke(nameof(ReloadScene), delaySec);
        }
    }

    void ReloadScene()
    {
        // Load Level 1
        SceneManager.LoadScene(0);
    }
}
