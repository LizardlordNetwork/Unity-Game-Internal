using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : MonoBehaviour
{
    public int damageBoost = 50;
    public float boostDuration = 30f;
    public float CurrentTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollision2D(Collision2D other)
    {
        Debug.Log("AttackUp");
        //On collison checking if the "Collectable" tag is on the object.
        if (other.gameObject.tag == "Player")
        {
            CurrentTime = Time.deltaTime;
            //getting the players health from another script and then taking way the attack damage from it
            other.gameObject.GetComponent<Movement_Script>().attackDamage += damageBoost;

        }
    }
}
