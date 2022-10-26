using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    float cameraVerticalRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltatime might be a problem
        float inputX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
