using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // setting the players movemnet speed. This can be changed while testing.
    public float EnemyMove = 5f;
    private Transform target;
    [SerializeField] private float attackDamage = 10f;
    //Setting an attack speed for the enemy. This measn that they deal damage at a certain rate instead off every frame.
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    //Variables for Enemy shhoting
    public Transform firePoint;
    public GameObject bulletPrefab;
    //setting the force of the bullet
    public float bulletForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            Debug.Log(target);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float step = EnemyMove * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            Vector2 direction = target.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            Shoot();
        }
        
    }

    void Shoot()
    {
        

        if (attackSpeed <= canAttack)
        {
            //Spawning in the bullet using a bullet prefab and spawning it at the firepoint.
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, target.rotation /*firePoint.rotation*/);

            //getting a rigid body fro the bullet to apply force to.
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            //applying force to the rigid body. 
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            //resetting the attack timer back to 0 at the end of an attack
            canAttack = 0f;
        }
        else
        {
            canAttack += Time.deltaTime;
        }
    }

    //Method for when the player collides with the enemy over a period of time to take damage.
    private void OnCollisionStay2D(Collision2D other)
    {
        //comapring if the game object has the player tag
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                //getting the players health from another script and then taking way the attack damage from it
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                //resetting the attack timer back to 0 at the end of an attack
                canAttack = 0f; 
            }
            else
            {
                canAttack += Time.deltaTime;
            }
            
        }
    }
}
