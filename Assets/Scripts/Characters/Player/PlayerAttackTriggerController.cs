using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTriggerController : MonoBehaviour
{
    private List<Rigidbody2D> _enemies = new List<Rigidbody2D>();
    public List<Rigidbody2D> Enemies { get { return _enemies; } }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _enemies.Add(other.GetComponent<Rigidbody2D>());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemies.Clear();
    }
}
