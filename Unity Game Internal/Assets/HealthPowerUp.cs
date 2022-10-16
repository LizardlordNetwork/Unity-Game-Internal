using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    //The amount of health gained when collecting The Health Powerup.
    private float HealthBoost = 20f;

    //When a collision occurs, run this code.
    private void OnCollision2D(Collision2D other)
    {
        //Debug log to show the code ran.
        Debug.Log("Health Up");

        //On collison checking if the "Player" tag is on the other object.
        if (other.gameObject.tag == "Player")
        {
            //getting the players health from another script, calling the "UpdateHealth" method and then passing in the "HealthBoost" variable.
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(+HealthBoost);
            //Destroying the object.
            //Destroy(gameObject);
        }
    }
}
