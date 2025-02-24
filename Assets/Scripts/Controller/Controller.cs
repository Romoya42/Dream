using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public float MovementSpeed;
    private float timePassed= 0f;
    public int jumpHigh;
    public GameObject look;
    private bool isGrounded = true;
 
    
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }
    
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        
        if(Input.GetKey(KeyCode.W))
        {
            rigidbody.position += look.transform.forward * MovementSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            rigidbody.position -= look.transform.forward * MovementSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            rigidbody.position -= look.transform.right * MovementSpeed * Time.deltaTime;
        } 
        if(Input.GetKey(KeyCode.D))
        {
            rigidbody.position += look.transform.right * MovementSpeed * Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(jumpHigh > 0 ? Vector3.up * jumpHigh : Vector3.down * jumpHigh, ForceMode.Impulse);
            isGrounded = false;
        }
        
        timePassed += Time.deltaTime;
        
        /*
        if(timePassed > 0.05f)
        {
            transform.localScale = new Vector3(transform.localScale.x+0.001f, transform.localScale.y+0.001f, transform.localScale.z+0.001f);
            timePassed = 0f;
        }*/
        
        
        
        /*
        
        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");
        
    
        if (scrollFactor != 0)
        {
            transform.localScale = transform.localScale * (1f - scrollFactor);
        }
        */
        
        
    }
}
