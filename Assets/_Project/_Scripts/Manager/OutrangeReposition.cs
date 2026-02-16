using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutrangeReposition : MonoBehaviour
{
    // Se il GroundCheck del player collide con il GameObject SubGround il player viene teletrasportato alla posizione di spawn
    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Restart(other.gameObject);
        }
    }

    public void Restart(GameObject player)
    {
        player.transform.position = spawnPoint.position;

        if (player.TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}