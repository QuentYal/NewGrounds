using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDash : MonoBehaviour
{

    [Header("Refrences")]
    public Transform orientation;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Dashing")]
    public float maxDashTime;
    public float dashForce;
    private float dashTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;
    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(dashKey) && (horizontalInput != 0 || verticalInput != 0))
        {
            StartDash();
        }

        if (Input.GetKeyUp(dashKey) && pm.dashing)
        {
            StopDash();
        }
    }

    private void StartDash()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        pm.dashing = true;

        rb.AddForce(inputDirection * -20f * 20f, ForceMode.Impulse);

        dashTimer = maxDashTime;
    }

    private void DashMovement()
    {
        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (rb.velocity.y > -0.1f)
        {
            rb.AddForce(inputDirection.normalized * dashForce, ForceMode.Force);

            dashTimer -= Time.deltaTime;
        }

        if (dashTimer <= 0)
        {
            StopDash();
        }
    }

    private void StopDash()
    {
        pm.dashing = false;
    }
}
