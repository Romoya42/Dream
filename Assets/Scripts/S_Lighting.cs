using UnityEngine;

public class S_Lighting : MonoBehaviour
{
    public Animator animator; 
    
    public S_GameManager gameManager;
    public float speedMultiplier = 1.0f; 
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<S_GameManager>();
        
        animator = GetComponent<Animator>();
        
        
        speedMultiplier=1;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            animator.speed = speedMultiplier; 
        }
    }

    public void SetAnimationSpeed(float newSpeed)
    {
        speedMultiplier = newSpeed;
    }

    public void RestartAnimation()
    {
        animator.Play("Light", 0, 0f);
    }
}
