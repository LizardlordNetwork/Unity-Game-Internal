using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    // setting the players movemnet speed. This can be changed while testing.
    public float PlayerMove = 5f;

    //Adding a rigid body to the object so it can move
    public Rigidbody2D rb;

    //vector movement  in 2 dimensions
    Vector2 movement;

    [SerializeField] private float attackDamage = 50f;
    //Setting an attack speed for the enemy. This measn that they deal damage at a certain rate instead off every frame.
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * PlayerMove * Time.fixedDeltaTime);
    }


    //Method for when the player collides with the enemy over a period of time to take damage.
    private void OnCollisionStay2D(Collision2D other)
    {
        //comapring if the game object has the player tag
        if (other.gameObject.tag == "Enemy")
        {
            if (attackSpeed <= canAttack)
            {
                //getting the players health from another script and then taking way the attack damage from it
                other.gameObject.GetComponent<EnemyMovement>().UpdateHealth(-attackDamage);
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
