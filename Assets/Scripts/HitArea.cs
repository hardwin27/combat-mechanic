using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    private bool isCountering = false;

    private void Update() 
    {
        print(isCountering);    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(GetComponent<Collider2D>().isTrigger == true)
        {
            isCountering = true;
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        isCountering = false;    
    }

    public bool GetIsCountering()
    {
        return isCountering;
    }
}
