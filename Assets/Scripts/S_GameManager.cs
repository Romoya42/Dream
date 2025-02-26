using UnityEngine;

public class S_GameManager : MonoBehaviour
{

    public static S_GameManager Instance;

    public int Lvl;
    public float LimitTimer;
    public float speedMultiplier = 1.0f; 
    
    
    public S_Lighting Light;
    

    void Awake()
    {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else Destroy(gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLVl()
    {
        Lvl++;
        Debug.Log("Tu es niveau" + Lvl);
        switch (Lvl)
        {
            case 1:
                Light.SetAnimationSpeed(0);
                break;

            case 2:
                Light.SetAnimationSpeed(0);
                break;

            case 3:
                Light.SetAnimationSpeed(0.2f);
                break;
            default:
                Light.SetAnimationSpeed(speedMultiplier*1.2f);
                break;
        }
    }


    public void StopScene()
    {
        Light.SetAnimationSpeed(0);
    }

    public void RestartScene()
    {
        Light.RestartAnimation();
    }

    

    




}




