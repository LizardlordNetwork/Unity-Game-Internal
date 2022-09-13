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

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
