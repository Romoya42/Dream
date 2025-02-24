using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class CameraManager : MonoBehaviour {

    public Transform player;
    


    void Start()
    {

    }
    void Update () 
    {
        var MousePos= Input.mousePosition;
        
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.LookAt(player.position);
    }
}
