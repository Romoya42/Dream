using UnityEngine;

public class S_Key : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            print("door");
            S_GameManager.Instance.DoorExit.Open();
            Destroy(gameObject);
        }
    }

    
    
}
