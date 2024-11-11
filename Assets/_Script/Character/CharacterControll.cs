using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private AudioSource runStepSource;
    [SerializeField] SceneTransition sceneTransition;
    public bool canShoot = true;
    public bool canRotate = true;
   

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedIncrease;
    [SerializeField] private float maxSpeed;
    
   

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxAngle;
    [SerializeField] private float minAngle;

    [Header("Mouse Controll")]
    [SerializeField] private float mouseSensitive;
    [SerializeField] Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canShoot = true;
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
            CharacterMove();
        if (canRotate)
        {
            CharacterRotation();
            CameraRotation();
        }
            
    }

    private void CharacterRotation()
    {
       
        float horizontalRotation = Input.GetAxis("Mouse X");
        float desireRotationAngle = horizontalRotation * rotationSpeed * Time.deltaTime;
        float angle = transform.eulerAngles.y + desireRotationAngle;
        angle = angle > 180 ? angle - 360 : angle;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = rotation;
    }

    private void CharacterMove()
    {
        runStepSource.Play();
        Vector3 velocity = transform.forward * moveSpeed;
        moveSpeed += moveSpeedIncrease * Time.deltaTime;
        moveSpeed = Mathf.Min(moveSpeed, maxSpeed);
        rigidBody.velocity = velocity;
        
    }

    private void CameraRotation()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitive;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canRotate = false;
            canShoot = false;
            moveSpeed = 0;
            moveSpeedIncrease = 0;
            sceneTransition.SceneTransi();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadTrigger"))
        {
            spawnManager.SpawnTriggerEntered();
        }
    }

    
}
