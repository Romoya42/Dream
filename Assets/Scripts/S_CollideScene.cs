using UnityEngine;

public class S_CollideScene : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && !S_GameManager.Instance.InGame)
        {
            S_GameManager.Instance.IncreaseLVl();
            S_GameManager.Instance.InGame=true;
        }

        if (other.CompareTag("End") && S_GameManager.Instance.InGame)
        {
            S_GameManager.Instance.InGame=false;

        }
        
    }

}
