using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitAreaController : MonoBehaviour
{
    private bool _isCountering = false;
    public bool IsCountering { get { return _isCountering; } }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<Collider2D>().isTrigger == true)
        {
            _isCountering = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _isCountering = false;
    }
}
