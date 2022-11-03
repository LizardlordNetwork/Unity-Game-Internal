using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // setting the players movemnet speed. This can be changed while testing.
    public float EnemyMove = 5f;
    private Transform target;


    //Variables for Enemy shhoting
    public Transform firePoint;
    public GameObject bulletPrefab;
    //setting the force of the bullet
    public float bulletForce = 10f;

    //Creating the enemies health and setting it as a variable. Making it a float to allow decimals.
    private float Health = 0f;

    //Making a private variable but setting it as a Serialize field to allow it to be edited inside the unity editor.
    [SerializeField] private float maxHealth = 100f;


    //Setting an attack speed for the enemy. This measn that they deal damage at a certain rate instead off every frame.
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    public int killscore = 25;

    public GameObject Player;




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            //Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //setting health to the maximum health at the start of the game
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //If there is a target, run this code.
        if (target != null)
        {
            //Enemy movement speed per second
            float step = EnemyMove * Time.deltaTime;

            //Allowing the enemy to move towards the target position at the rate set above
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            //getting the direction of the target using vectors by taking away its postion from the postion of the target
            Vector2 direction = target.position - transform.position;

            //rotating the enemy using the direction found earlier
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            //shooting in the direction
            Shoot();
        }

    }

    void Shoot()
    {


        if (attackSpeed <= canAttack)
        {
            //Spawning in the bullet using a bullet prefab and spawning it at the firepoint.
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            //getting a rigid body fro the bullet to apply force to.
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            //applying force to the rigid body. 
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            //Vector2 direction = firePoint.rotation;
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);


            //resetting the attack timer back to 0 at the end of an attack
            canAttack = 0f;
        }
        else
        {
            canAttack += Time.deltaTime;
        }
    }



    //Method for when health updates (gains or loses health) 
    public void UpdateHealth(float modification)
    {
        //Adding the modifacation  to the health
        Health -= modification;

        //If the health is greater then the max health then setting it back to the max health
        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
        else if (Health <= 0f)
        {
            /*if health is equal to or less then 0 then setting it back to 0 so it doesnt cause issues with negatives
            Health = 0f;*/
            Die();
        }
    }

    public void Die()
    {
        Score_Counter.score += killscore;
        Destroy(gameObject);
    }
}
