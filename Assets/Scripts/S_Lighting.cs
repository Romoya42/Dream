using UnityEngine;

public class S_Lighting : MonoBehaviour
{
    public Animator animator; 
    
    
    public float speedMultiplier = 1.0f; 
    public bool play=false;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        animator = GetComponent<Animator>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (S_GameManager.Instance.GM_Key!=null)
        {
            
            
            transform.position = new Vector3(
                S_GameManager.Instance.GM_Key.transform.position.x,
                transform.position.y, // On conserve la hauteur actuelle
                S_GameManager.Instance.GM_Key.transform.position.z
            );

        }

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
        S_GameManager.Instance.Loose();
    }
}
