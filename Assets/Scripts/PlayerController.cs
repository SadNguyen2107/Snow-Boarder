using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/PlayerController")]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float boostSpeed;
    [SerializeField] float baseSpeed;
    [SerializeField] float torqueAmount;
    private Rigidbody2D playerRigidbody2D;
    private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;

    // Start is called before the first frame updat e
    void Start()
    {
        this.playerRigidbody2D = GetComponent<Rigidbody2D>();

        // Get Surface Effect2D
        this.surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            this.RotatePlayer();
            this.RespondToBoost();
        }
        else
        {
            DisableControls();
        }

    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        // If we push up, => speed upp
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.surfaceEffector2D.speed = this.boostSpeed;
        }
        // otherwise keep normal speed
        else
        {
            this.surfaceEffector2D.speed = this.baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        // Rotate Backward
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.playerRigidbody2D.AddTorque(this.torqueAmount);
        }
        // Rotate Forward
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.playerRigidbody2D.AddTorque(-this.torqueAmount);
        }
    }
}
