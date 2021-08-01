using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileDuration = 1.5f;
    private float projectileTimer;

    private void Awake() 
    {
        projectileTimer = projectileDuration;    
    }

    private void Update() 
    {
        projectileTimer -= Time.deltaTime;
        if(projectileTimer <= 0)
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.isTrigger)
        {
            other.transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x * 25.0f, 0.0f));
            Destroy(gameObject);
        }
    }
}
