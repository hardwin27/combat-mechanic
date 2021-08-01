using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> enemies;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        enemies.Add(other.GetComponent<Rigidbody2D>());
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        enemies.Clear();    
    }

    public List<Rigidbody2D> GetEnemies()
    {
        return enemies;
    }
}
