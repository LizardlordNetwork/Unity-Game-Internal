using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    // setting the players movemnet speed. This can be changed while testing.
    public float PlayerMove = 5f;

    //Adding a rigid body to the object so it can move
    public Rigidbody2D rb;

    //a variable for vector movement in 2 dimensions
    Vector2 movement;

    public float attackDamage = 50f;
    public float attackBoost = 50f;
    //Setting an attack speed for the enemy. This measn that they deal damage at a certain rate instead off every frame.
    [SerializeField] private float attackSpeed = 0.2f;
    private float canAttack;

    //creating variables for the melee combat system
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;

    //Sprite renderer
    private SpriteRenderer PlayerSpriteRenderer;


    // This function is called just one time by Unity the moment the component loads
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //when the space key is pressed
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * PlayerMove * Time.fixedDeltaTime);

        //float Rotation = GetComponent<Pivot>().FindMouseRotation();
        //finding the difference between the mouse position and the current position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //normalizing to get rid of decimals
        difference.Normalize();

        //finding the rotation of the mouse using the x and y difference
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        // if the variable isn't empty (we have a reference to our SpriteRenderer
        if (PlayerSpriteRenderer != null)
        {
            if (rotationZ < -90 || rotationZ > 90)
            {
                // flip the sprite
                PlayerSpriteRenderer.flipX = true;
            }
            else
            {
                PlayerSpriteRenderer.flipX = false;
            }
                
        }
    }

    void attack()
    {
        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);

        
          //looping through all the enemies detected  
         foreach (Collider2D enemy in hitEnemies)
         {
            //if there is no enemy then say "miss" in the debug log
            if (enemy == null)
            {
                    Debug.Log("Miss");
            }
            else
            {
                //Telling us what enemy was hit in the debug log
                Debug.Log(enemy);

                //Giving feed back in the debug log
                Debug.Log("Hit");

                enemy.GetComponent<EnemyMovement>().UpdateHealth(attackDamage);

                // if (attackSpeed <= canAttack)
                // {
                //getting the Enemies health from another script and then taking way the attack damage from it


                //resetting the attack timer back to 0 at the end of an attack
                //canAttack = 0f;
                // }
                //else
                //{
                //canAttack += Time.deltaTime;
                //}

                //comapring if the game object has the player tag
                /*if (gameObject.tag == "Enemy")
                {
                    if (attackSpeed <= canAttack)
                    {


                        //resetting the attack timer back to 0 at the end of an attack
                        canAttack = 0f;
                    }
                    else
                    {
                        canAttack += Time.deltaTime;
                    }

                }*/
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    //On colliding with a trigger run this code
    private void OnTriggerEnter2D(Collider2D collisions)
    {
        //On collison checking if the "HealthUp" tag is on the object.
        if (collisions.CompareTag("AttackUp"))
        {
            //debug to make sure it works
            Debug.Log("Attack Up");

            //running the update health method from above and passing in the health boost variable as the modification
            AttackUp(attackBoost);

            //destroying the object
            Destroy(collisions.gameObject);

        }
    }

    void AttackUp(float modification)
    {
        //Adding the modifacation  to the health
        attackDamage += modification;
    }


}
