using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    //creating a slider to change the fill of the health bar
    public Slider slider;

    //creating a method to set the health bar to max when the player is on full health
    public void SetMaxHealth(int health)
    {
        //setting the slider values
        slider.maxValue = health;
        slider.value = health;
    }

    //setiing the slider value to the players current health
    public void SetHealth (int health)
    {
        slider.value = health;
    }

}
