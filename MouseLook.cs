using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera Control/Mouse Look")]

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;

    public Transform playerBody;

    private float xRotate = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseAim();
        
    }

    void MouseAim()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotate -= mouseY;

        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
