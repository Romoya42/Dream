using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Controller : MonoBehaviour
{
    public float MovementSpeed;
    public float CameraRotateSpeed;
    private float timePassed= 0f;
    private float Constante = 0.1f;
    
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        
        if(Input.GetKey(KeyCode.W))
        {
            rigidbody.position += transform.forward * MovementSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            rigidbody.position -= transform.forward * MovementSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            rigidbody.position -= transform.right * MovementSpeed * Time.deltaTime;
        } 
        if(Input.GetKey(KeyCode.D))
        {
            rigidbody.position += transform.right * MovementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.position += transform.up * MovementSpeed * Time.deltaTime;
        }
        
        float h= CameraRotateSpeed * Input.GetAxis("Mouse X");
        

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + h, transform.eulerAngles.z);
        
        
        timePassed += Time.deltaTime;
        
        
        if(timePassed > 0.05f)
        {
            transform.localScale = new Vector3(transform.localScale.x+0.001f, transform.localScale.y+0.001f, transform.localScale.z+0.001f);
            timePassed = 0f;
        } 
        
        
        
        /*
        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");
        
    
        if (scrollFactor != 0)
        {
            transform.localScale = transform.localScale * (1f - scrollFactor);
        }
        */
        
        
    }
}
