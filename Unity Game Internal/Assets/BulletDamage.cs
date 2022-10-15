using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;

    //The amonut of time before a bullet should despawn
    private float despawnTime = 10f;
    //How long the bullte as been alive
    private float TimeAlive;
    // Start is called before the first frame update

    //public Transfrom Direction;

    void Start()
    {
        //transform.LookAt(gameObject.GetComponent<EnemyMovement>().firePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (despawnTime <= TimeAlive)
        {
            //resetting the attack timer back to 0 at the end of an attack
            Destroy(gameObject);
        }
        else
        {
            TimeAlive += Time.deltaTime;
        }
        //transform.rotation = gameObject.GetComponent<EnemyMovement>().firePoint.rotation;
    }


    //private void OnCollision2D(Collision2D other)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit");
        //On collison checking if the "Collectable" tag is on the object.
        if (other.gameObject.tag == "Player")
        {
            //getting the players health from another script and then taking way the attack damage from it
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            //destroying the object
            Destroy(gameObject);
        }
    }
    /*  private void OnCollisionStay2D(Collision2D other)
    {
        //comapring if the game object has the player tag
        if (other.gameObject.tag == "Player")
        {*/
}
