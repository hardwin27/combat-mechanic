using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private bool _isGrounded = false;
    public bool IsGrounded { get { return _isGrounded; } }

    void OnTriggerStay2D(Collider2D other)
    {
        _isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _isGrounded = false;
    }
}
