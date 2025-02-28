using UnityEngine;

public class S_Key : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            S_GameManager.Instance.Fade.transitionTime=2;
            S_GameManager.Instance.Fade.StartCrossfade();
            S_SoundManager.instance.Play("DoorUnlock");
            S_GameManager.Instance.DoorExit.Open();
            Destroy(gameObject);
        }
    }

    
    
}
