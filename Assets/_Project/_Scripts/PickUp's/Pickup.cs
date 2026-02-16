using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Collectible,
        AddTime,
        AddHealth
    }

    [SerializeField] private PickupType pickupType;
    [SerializeField] private int value = 1;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        switch (pickupType)
        {
            case PickupType.Collectible:
                FindObjectOfType<CollectibleManager>().AddCollectible(value);
                break;

            case PickupType.AddTime:
                FindObjectOfType<Timer>().AddTime(value);
                break;

            case PickupType.AddHealth:
                other.GetComponent<PlayerStats>().AddHealth(value);
                break;
        }

        PlaySound();
        Destroy(gameObject);
    }

    void PlaySound()
    {
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }
    }
}
