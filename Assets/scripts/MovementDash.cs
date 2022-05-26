using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDash : MonoBehaviour
{

    PlayerMovement movescript;

    public float dashSpeed;
    public float dashTime;
    // Start is called before the first frame update
    void Start()
    {
        movescript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    
}
