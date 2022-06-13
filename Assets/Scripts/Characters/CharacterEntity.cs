using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : MonoBehaviour
{
    public delegate void HealthUpdateHandler();
    public event HealthUpdateHandler HealthUpdated;

    private int _maxHealth;
    private int _health;

    public int MaxHealth { get { return _maxHealth; } }
    public int Health { get { return _health; } }

    public void TakingDamage(int damageDealt)
    {
        _health -= damageDealt;
        HealthUpdated?.Invoke();
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
