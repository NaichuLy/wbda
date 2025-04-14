using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform cameraPivot;
    [SerializeField] Camera mainCamera;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] Vector2 verticalRotationLimit = new Vector2(-40, 70);

    [SerializeField] Vector3 closePos = new Vector3(0, 2, -4);
    [SerializeField] Vector3 farPos = new Vector3(0, 4, -8);

    bool _farView = false;
    float _horizontalRotation = 0f;
    float _verticalRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCamera.transform.localPosition = closePos;
    }

    private void Update()
    {
        HandleViewSwitch();
        HandleCameraRotation();
        FollowPlayer();
    }

    private void HandleViewSwitch()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _farView = !_farView;
            if (_farView )
            {
                mainCamera.transform.localPosition = farPos;
            }
            else
            {
                mainCamera.transform.localPosition = closePos;
            }
        }
    }
    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        _horizontalRotation += mouseX; 
        _verticalRotation -= mouseY; 

        _verticalRotation = Mathf.Clamp(_verticalRotation, verticalRotationLimit.x, verticalRotationLimit.y);

        cameraPivot.rotation = Quaternion.Euler(_verticalRotation, _horizontalRotation, 0f);
    }
    private void FollowPlayer()
    {
        transform.position = player.position;
    }



}
