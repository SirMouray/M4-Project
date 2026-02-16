using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 rotationAxis = new Vector3(0, 1, 0);
    [SerializeField] private float rotationSpeed = 100f;

    [Header("Floating Settings")]
    [SerializeField] private float floatAmplitude = 0.25f;
    [SerializeField] private float floatFrequency = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update() // Rotazione e movimento su e giù
    {
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime, Space.Self);

        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
