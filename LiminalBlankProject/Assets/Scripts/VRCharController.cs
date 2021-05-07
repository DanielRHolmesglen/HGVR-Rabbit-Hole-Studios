using System.Collections;
using System.Collections.Generic;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class VRCharController : MonoBehaviour
{
    public float speed;
    public GameObject head;
    
    private CharacterController characterController;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var primaryInput = VRDevice.Device.PrimaryInputDevice;

        if (Input.GetKey(KeyCode.W) || primaryInput.GetButtonDown(VRButton.DPadUp))
        {
            var x = head.transform.forward.normalized;
            movement = new Vector3(x.x * speed, -.1f, x.z * speed);

            
        }
        else if (Input.GetKey(KeyCode.S) || primaryInput.GetButtonDown(VRButton.DPadDown))
        {
            var x = head.transform.forward.normalized;
             movement = new Vector3(-x.x * speed, -.1f, -x.z * speed);
        }
        else if (Input.GetKey(KeyCode.D) || primaryInput.GetButtonDown(VRButton.DPadRight))
        {
            var x = head.transform.right.normalized;
            movement = new Vector3(x.x * speed, -.1f, x.z * speed);
        }
        else if (Input.GetKey(KeyCode.A) || primaryInput.GetButtonDown(VRButton.DPadLeft))
        {
            var x = head.transform.right.normalized;
            movement = new Vector3(-x.x * speed, -.1f, -x.z * speed);
        }
        else
        {
             movement = new Vector3(0, -.1f, 0);
        }
        characterController.Move(movement);
    }
}
