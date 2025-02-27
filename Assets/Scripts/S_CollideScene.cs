using UnityEngine;

public class S_CollideScene : MonoBehaviour
{
    public S_GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = FindFirstObjectByType<S_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && !gameManager.InGame)
        {
            gameManager.IncreaseLVl();
            gameManager.InGame=true;
        }

        if (other.CompareTag("End") && gameManager.InGame)
        {
            gameManager.InGame=false;
            
        }
        
    }

}
