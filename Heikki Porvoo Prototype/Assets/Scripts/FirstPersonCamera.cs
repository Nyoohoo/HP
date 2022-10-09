using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Remove Time.deltaTime if issues occur
        float inputX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
