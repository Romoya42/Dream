using UnityEngine;

public class S_GameManager : MonoBehaviour
{

    public static S_GameManager Instance;
    public bool InGame=false;
    public int Lvl=0;
    
    public S_ObjectSpawner KeySpawner;
    [HideInInspector] public GameObject GM_Key;
    public S_Lighting Light;

    [Header("List Item LVL")]
    public GameObject[] Niv1;
    public GameObject[] Niv2;
    public GameObject[] Niv3;
    public GameObject[] Niv4;

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
        KeySpawner.Spawner();
        Light.RestartAnimation();
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
                Light.SetAnimationSpeed(1.2f);
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
    
    public void RestartGame()
    {

    }
    
    public void Loose()
    {
        print("loose");
    }



}




