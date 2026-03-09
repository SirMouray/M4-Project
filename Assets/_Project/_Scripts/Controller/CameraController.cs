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

    [Header("Collision Settings")]
    [SerializeField] private LayerMask collisionMask;   // Imposta "Map"
    [SerializeField] private float sphereRadius = 0.3f; // Raggio della camera
    [SerializeField] private float collisionOffset = 0.2f;
    [SerializeField] private float minDistance = 0.5f;

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
        // Posizione pivot (spalle player)
        transform.position = target.position;

        // Posizione desiderata camera (world space)
        Vector3 desiredWorldPos = transform.TransformPoint(shoulderOffset);

        // Direzione verso la camera
        Vector3 direction = desiredWorldPos - target.position;
        float distance = direction.magnitude;

        RaycastHit hit;

        // SphereCast per evitare compenetrazione
        if (Physics.SphereCast(
            target.position,
            sphereRadius,
            direction.normalized,
            out hit,
            distance,
            collisionMask))
        {
            float adjustedDistance = Mathf.Clamp(
                hit.distance - collisionOffset,
                minDistance,
                distance
            );

            cameraTransform.localPosition = new Vector3(
                shoulderOffset.x,
                shoulderOffset.y,
                -adjustedDistance
            );
        }
        else
        {
            cameraTransform.localPosition = shoulderOffset;
        }
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
