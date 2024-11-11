using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float topClamp = -90f;
    [SerializeField] private float bottomClamp = 90f;
  
    float xRotation = 0f;
    float yRotation = 0f; 


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotation();
    }

    public void MouseRotation()
    {
        //getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //clamp the rotation 
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        //rotation around the Y axis (look left and right)
        yRotation += mouseX;
        //apply rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
