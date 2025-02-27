using UnityEngine;

public class S_GameManager : MonoBehaviour
{

    public static S_GameManager Instance;
    public bool InGame=false;
    public int Lvl=0;
    private float Speedlight=0.05f;
    
    public S_ObjectSpawner KeySpawner;
    [HideInInspector] public GameObject GM_Key;
    public S_Lighting Light;

    public S_Door DoorStart;
    public S_Door DoorExit;

    [Header("List Item LVL")]
    public GameObject[] Niv1;
    public GameObject[] Niv2;
    public GameObject[] Niv3;
    public GameObject[] Niv4;
    public GameObject[] Niv5;
    public GameObject[] Niv6;

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
                
                foreach (GameObject obj in Niv1)
                {
                    obj.SetActive(true);
                }
                DoorStart.Open(1);
                Light.SetAnimationSpeed(0);
                break;

            case 2:
                foreach (GameObject obj in Niv1)
                {
                    obj.SetActive(false);
                }

                foreach (GameObject obj in Niv2)
                {
                    obj.SetActive(true);
                }

                DoorStart.Open(1);
                Light.SetAnimationSpeed(0);
                break;

            case 3:
                foreach (GameObject obj in Niv2)
                {
                    obj.SetActive(false);
                }

                foreach (GameObject obj in Niv3)
                {
                    obj.SetActive(true);
                }

                DoorStart.Open(1);
                Light.SetAnimationSpeed(0);
                break;

            default:
                Speedlight*=1.02f
                Light.SetAnimationSpeed(Mathf.Min(Speedlight, 1.5));
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




