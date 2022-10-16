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
    public Transform SwingEnd;
    public float TimeCount = 0f;


    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        ArmSpriteRenderer = Arm.GetComponent<SpriteRenderer>();
    }

    



    // Update is called at a fixed rate
    public void FixedUpdate()
    {
        
        float Rotation = FindMouseRotation();

        

        if (Input.GetMouseButtonDown(0))
        {
            /*swordTransform.transform.localPosition = Vector3.Slerp(swordTransform.localPosition, new Vector3(1, 0, 1), 0.01f);
            // The center of the arc
            Vector3 center = (SwingPoint.position + SwingEnd.position) * 0.5F;

            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 1, 0);

            // Interpolate over the arc relative to center
            Vector3 PointRelCenter = SwingPoint.position - center;
            Vector3 EndRelCenter = SwingEnd.position - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.time - TimeCount) / SwingSpeed;

            transform.position = Vector3.Slerp(PointRelCenter, EndRelCenter, fracComplete);
            transform.position += center; 

            Vector3 RotationStart = SwingPoint.position - transform.position;
            float RST = Mathf.Atan2(RotationStart.y, RotationStart.x) * Mathf.Rad2Deg;
            Vector3 RotationEnd = SwingEnd .position- transform.position;
            float RET = Mathf.Atan2(RotationEnd.y, RotationEnd.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(RST.rotation, RET.rotation, TimeCount);
            TimeCount = TimeCount + Time.deltaTime; */
        }
        else
        {
            //rotating  the object by the z roation to face the mouse
            transform.rotation = Quaternion.Euler(0f, 0f, Rotation);
        }
        

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

        //returning rotationZ
        return rotationZ;
    }
}
