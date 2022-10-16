using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Creating the players health and setting it as a variable. Making it a float to allow decimals.
    private float Health = 0f;

    //Making a private variable but setting it as a Serialize field to allow it to be edited inside the unity editor.
    [SerializeField] private float maxHealth = 100f;

    //The amount of health gained when collecting The Halth Powerup.
    public float HealthBoost = 20f;

    //Creating the Healthbar as object in the script.
    public HealthBar HealthBar;


    // Start is called before the first frame update
    void Start()
    {
        //setting health to the maximum health at the start of the game
        Health = maxHealth;
        
        //setting the health bar to full at the start of the game
        HealthBar.SetMaxHealth(Convert.ToInt32(maxHealth));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method for when health updates (gains or loses health) 
    public void UpdateHealth(float modification)
    {
        //Adding the modifacation  to the health
        Health += modification;

        //updating the health bar when there is a modification to the players health
        HealthBar.SetHealth(Convert.ToInt32(Health));

        //If the health is greater then the max health then setting it back to the max health
        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
        else if (Health <= 0f)
        {
            //if health is equal to or less then 0 then setting it back to 0 so it doesnt cause issues with negatives
            Health = 0f;

            //When the player dies then Unity gets the index of the loaded scene and then takes 1 off and loads that index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


            //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, target.rotation /*firePoint.rotation*/);
        }
    }

    //On colliding with a trigger run this code
    private void OnTriggerEnter2D(Collider2D collisions)
    {
        //On collison checking if the "HealthUp" tag is on the object.
        if (collisions.CompareTag("HealthUp"))
        {
            //debug to make sure it works
            Debug.Log("Health Up");

            //running the update health method from above and passing in the health boost variable as the modification
            UpdateHealth(HealthBoost);

            //destroying the object
            Destroy(collisions.gameObject);

        }
    }
}
