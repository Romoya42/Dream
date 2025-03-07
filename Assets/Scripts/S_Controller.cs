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
    public bool grounded = false;
    private bool grabbing = false;
    

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

    public Camera Cam;


    //Raycast
    public LayerMask layersToHit;
    //private Ray _rayCast;
    public float maxDistance = 5f;

    public S_Magnet s_Magnet;

    private Transform HitedRayCast;





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
        Cursor.visible = false;
    }

    //Le reste
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void Update()
    {
        MovePlayerCam();
        Raycast();
        
    }

    private void MovePlayer() //movement du joueur
    {

        if (Physics.CheckSphere(_groundCheck.position, 0.4f, _maskGround)) grounded = true; else grounded = false;


        Vector3 MoveVector = transform.TransformDirection(_moveInputs.x, 0f, _moveInputs.y) * Speed;
        _rigidbody.linearVelocity = new Vector3(MoveVector.x, _rigidbody.linearVelocity.y, MoveVector.z);


        //saut
        if (Input.GetButtonDown("Jump") && grounded) 
        {
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, 0f, _rigidbody.linearVelocity.z); 
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

        }
    }


    private void MovePlayerCam()
    {
        if (!S_PauseMenu.isPaused)
        {
            xRot -= _lookInputs.y * Sensivity;
            xRot = Mathf.Clamp(xRot, -90, 90);
            transform.Rotate(0f, _lookInputs.x * Sensivity, 0f);
            _playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
    }

    private void Raycast()
    {

        RaycastHit hitinfo;
        Ray _rayCast = Cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        


        Debug.DrawRay(_rayCast.origin, _rayCast.direction * maxDistance, Color.green);

        if (Input.GetKeyUp(KeyCode.E) && grabbing)
        {
            grabbing = false;
            HitedRayCast = null;
            
            s_Magnet.Drop();
            
        }

        if (Physics.Raycast(_rayCast, out hitinfo, maxDistance, layersToHit))
        {
            Debug.DrawRay(_rayCast.origin, _rayCast.direction * maxDistance, Color.red);
           
            if (HitedRayCast == null)
            {
                if (Input.GetKey(KeyCode.E) && !grabbing)
                {
                    grabbing = true;
                    HitedRayCast = hitinfo.transform;
                    s_Magnet.PickUp(HitedRayCast);
                    if (HitedRayCast.GetComponent<S_Key>() != null)
                    {
                        S_SoundManager.instance.Play("Key");
                    }
                }
            }
        }
    }
}
    





