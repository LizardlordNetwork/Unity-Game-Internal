using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{

    private float HealthBoost = 20f;

    //private void OnCollision2D(Collision2D other)
    private void OnCollision2D(Collision2D other)
    {
        Debug.Log("Health Up");
        //On collison checking if the "Collectable" tag is on the object.
        if (other.gameObject.tag == "Player")
        {
            //getting the players health from another script and then taking way the attack damage from it
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+HealthBoost);
            //destroying the object
            //Destroy(gameObject);
        }
    }
}
