using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollision2D(Collision2D other)
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
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
