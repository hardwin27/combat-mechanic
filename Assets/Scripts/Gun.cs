using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    public void Shoot()
    {
        GameObject shootedPorjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        shootedPorjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(20.0f * transform.parent.localScale.x, 0.0f);
    }
}
