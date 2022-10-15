using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject Player;
    private SpriteRenderer ArmSpriteRenderer;
    public GameObject Arm;
    public Transform SwingPoint;
    public float SwingSpeed = 0.3f;
    private float StartTime; 

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        ArmSpriteRenderer = Arm.GetComponent<SpriteRenderer>();
    }

    //swordTransform.transform.localPosition = Vector3.Slerp(swordTransform.localPosition, new Vector3(1, 0, 1), 0.01f);



    // Update is called at a fixed rate
    public void FixedUpdate()
    {
        
        float Rotation = FindMouseRotation();
        //rotating  the object by the z roation to face the mouse
        transform.rotation = Quaternion.Euler(0f, 0f, Rotation);

        // If the mouse is on the other side then flip the pivot and arm on the x axis
        if(Rotation < -90 || Rotation > 90)
        {
            transform.localRotation = Quaternion.Euler(180, 0, -Rotation);
            
            // flip the sprite
            //ArmSpriteRenderer.flipX = true;
        }
        else
        {
            ArmSpriteRenderer.flipX = false;
        }
    }

    public float FindMouseRotation()
    {
        //finding the difference between the mouse position and the current position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //normalizing to get rid of decimals
        difference.Normalize();

        //finding the rotation of the mouse using the x and y difference
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        return rotationZ;
    }
}
