using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    private int _groundContacts;

    public bool IsGrounded => _groundContacts > 0;

    private void OnTriggerEnter(Collider other)
    {
        if (IsInLayer(other.gameObject.layer))
        {
            _groundContacts++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsInLayer(other.gameObject.layer))
        {
            _groundContacts = Mathf.Max(0, _groundContacts - 1);
        }
    }

    private bool IsInLayer(int layer)
    {
        return (_groundLayer.value & (1 << layer)) != 0;
    }
}