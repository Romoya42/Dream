using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class S_Magnet : MonoBehaviour
{
    private Rigidbody rigidbodyHited;
    public Transform HitedRayCast;
    public float lerpSpeed;
    
    public float epsilon= 0;


    void Awake()
    {
        
    }



    public void PickUp(Transform HitedRayCast)
    {
        
        this.HitedRayCast = HitedRayCast;
        rigidbodyHited = HitedRayCast.GetComponent<Rigidbody>();
        
        rigidbodyHited.useGravity = false;

    }


    public void Drop()
    {
        if (rigidbodyHited != null) 
        { 
            
            HitedRayCast =null;
        }
    }

    private void FixedUpdate()
    {


        if (HitedRayCast !=null)
        {

            Vector3 newPosition = transform.position - HitedRayCast.position;
            rigidbodyHited.AddForce(newPosition * lerpSpeed);


           /* if (rigidbody.velocity.magnitude > maxSpeed)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }*/


            if (Vector3.Distance(HitedRayCast.position, transform.position) < epsilon)
            {

                Vector3 Lerpedpos = Vector3.Lerp(transform.position, HitedRayCast.position, Time.deltaTime * 40);
                rigidbodyHited.MovePosition(Lerpedpos);

            }

        }
        


    }
    
}
