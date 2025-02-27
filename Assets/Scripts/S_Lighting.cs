using UnityEngine;

public class S_Lighting : MonoBehaviour
{
    public Animator animator; 
    
    public S_GameManager gameManager;
    public float speedMultiplier = 1.0f; 
    public bool play=false;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<S_GameManager>();
        
        animator = GetComponent<Animator>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            animator.speed = speedMultiplier*0.1f; 
        }
        if (play){
            RestartAnimation();
        }
    }

    public void SetAnimationSpeed(float newSpeed)
    {
        speedMultiplier = newSpeed;
    }

    public void RestartAnimation()
    {
        animator.Play("Light", 0, 0f);
        play=false;
    }

    public void Loose()
    {
        
    }
}
