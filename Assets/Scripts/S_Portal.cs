using UnityEngine;

public class S_Portal : MonoBehaviour
{
   
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    Camera portalCam;
    public Material cameraMat;
    


    private void Awake()
    {
        portalCam = GetComponentInChildren<Camera>();


    }

    private void Start()
    {
        if (portalCam.targetTexture != null)
        {
            portalCam.targetTexture.Release();
        }
        portalCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat.mainTexture = portalCam.targetTexture;


    }

    // Update is called once per frame
    void Update()
    {
        //Position

        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        playerOffsetFromPortal.y= -playerOffsetFromPortal.y;
        transform.position = portal.position + -playerOffsetFromPortal;


        

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        //Rotation

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * -playerCamera.forward;
        newCameraDirection.y = -newCameraDirection.y;

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
