using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Controller : MonoBehaviour
{
    //Private
    private Vector2 _moveInputs;
    private Vector2 _lookInputs;
    private bool _jumpPerformed;
    private bool grounded = false;
    

    [SerializeField] private Transform _playerCamera;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _maskGround;
    private float xRot;
    [Space]

    //Les publics
    [SerializeField] public float Speed;
    [SerializeField] public float Sensivity;
    [SerializeField] public float JumpForce;
    [SerializeField] public float FallSpeed;

    public Camera Cam;


    



    //Les inputs
    public void MovePerformed(InputAction.CallbackContext _ctx) => _moveInputs = _ctx.ReadValue<Vector2>();
    public void JumpPerformed(InputAction.CallbackContext _ctx) => _jumpPerformed = _ctx.performed;
    public void LookPerformed(InputAction.CallbackContext _ctx) => _lookInputs = _ctx.ReadValue<Vector2>();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

    }

    private void OnCollisionStay()
    {
        grounded = true;
    }

    void OnCollisionExit()
    {
        grounded = false;
    }

    //Le reste
    private void Update()
    {
        MovePlayer();
        MovePlayerCam();
        


        //print(Input.mousePosition +"moosepos");
        //print(_lookInputs +"look");

    }






    private void MovePlayer() //movement du joueur
    {

        if (Physics.CheckSphere(_groundCheck.position, 0.1f, _maskGround)) grounded = true; else grounded = false;


        Vector3 MoveVector = transform.TransformDirection(_moveInputs.x, 0f, _moveInputs.y) * Speed;
        _rigidbody.linearVelocity = new Vector3(MoveVector.x, _rigidbody.linearVelocity.y, MoveVector.z);


        //saut
        if (Input.GetButtonDown("Jump") && grounded) ///faut modifier pour utiliser la bool _jumpPerformed
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) /*&& grounded*/) ///faut modifier pour utiliser la bool _jumpPerformed
        {
            _rigidbody.AddForce(Vector3.down * JumpForce*1.1f, ForceMode.Impulse);
        }
        
        if (!grounded)
        {
            _rigidbody.AddForce(Vector3.down * FallSpeed * _rigidbody.mass,ForceMode.Force);
        }

    }
    
    


    private void MovePlayerCam()
    {
        xRot -= _lookInputs.y * Sensivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.Rotate(0f, _lookInputs.x * Sensivity, 0f);
        _playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }

    
}
    





