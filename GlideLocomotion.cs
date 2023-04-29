using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GlideLocomotion : LocomotionProvider
{
    public Transform rigRoot;
    public float velocity = 2f; //meters per second
    public float rotationSpeed = 100f; // degrees per second
    public Transform trackedTransorm;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        if (rigRoot == null)
        {
            rigRoot = transform;
        }
    }

    void Update()
    {
        if(!isMoving && !CanBeginLocomotion())
        {
            return;
        }

        float forward = Input.GetAxis("XRI_Right_Primary2DAxis_Vertical");
        float sideways = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");

        if(forward == 0f && sideways == 0f)
        {
            isMoving = false;
            EndLocomotion();
            return;
        }

        if(!isMoving)
        {
            isMoving= true;
            BeginLocomotion();
        }

        if (forward != 0f)
        {
            Vector3 moveDirection = Vector3.forward;
            
            if(trackedTransorm != null)
            {
                moveDirection = trackedTransorm.forward;
                moveDirection.y = 0f;
            }

            moveDirection *= -forward * velocity * Time.deltaTime;
            rigRoot.Translate(moveDirection);
        }

        if(trackedTransorm == null && sideways != 0f)
        {

            if (sideways != 0f)
            {
                float rotation = sideways * rotationSpeed * Time.deltaTime;
                rigRoot.Rotate(0, rotation, 0);
            }
        }
    }
}
