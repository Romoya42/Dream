using UnityEngine;

public class S_Portal2 : MonoBehaviour
{
    [SerializeField] private GameObject portal1;
    [SerializeField] private GameObject portal2;

    private bool _tp1Activated;
    private bool _tp2Activated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal1") && !_tp2Activated)
        {
            Teleport(portal1, portal2);
            _tp1Activated = true;
        }
        else if (other.CompareTag("Portal2") && !_tp1Activated)
        {
            Teleport(portal2, portal1);
            _tp2Activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Portal1")) 
            _tp2Activated = false;
        if (other.CompareTag("Portal2")) 
            _tp1Activated = false;
    }

    private void Teleport(GameObject currentPortal, GameObject destinationPortal)
    {
        Vector3 positionDifference = transform.position - currentPortal.transform.position;
        positionDifference = new Vector3(-positionDifference.x, positionDifference.y, -positionDifference.z);
        float targetYRotation = 180f + transform.eulerAngles.y;

        transform.position = destinationPortal.transform.position + positionDifference;
        transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);
    }
}