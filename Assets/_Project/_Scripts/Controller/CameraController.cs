using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;         
    [SerializeField] private Transform cameraTransform;

    [Header("Mouse Settings")]
    [SerializeField] private float sensitivity = 200f;
    [SerializeField] private float minVerticalAngle = -30f;
    [SerializeField] private float maxVerticalAngle = 60f;

    [Header("Offsets")]
    [SerializeField] private Vector3 shoulderOffset = new Vector3(0.6f, 1.8f, -3f);

    private float _verticalRotation;
    private float _horizontalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleRotation();
        FollowTarget();
    }

    private void FollowTarget()
    {
        transform.position = target.position;
        cameraTransform.localPosition = shoulderOffset;
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _horizontalRotation += mouseX;
        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, minVerticalAngle, maxVerticalAngle);

        transform.rotation = Quaternion.Euler(_verticalRotation, _horizontalRotation, 0f);
    }

    public float GetCameraYRotation()
    {
        return _horizontalRotation;
    }
}
