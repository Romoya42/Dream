using UnityEngine;

public class S_GameManager : MonoBehaviour
{

    public static S_GameManager Instance;
    public bool InGame=false;
    public int Lvl=-1;
    private float Speedlight=0.05f;
    
    public S_ObjectSpawner GM_Spawner;
    /*[HideInInspector]*/ public GameObject GM_Key;
    public S_Lighting Light;

    public S_Door DoorStart;
    public S_Door DoorExit;
    private int PreviousLvl=0;
    
    [Header("List Item LVL")]
    


    //Levels[Niveau][Composition][Objet]
    [SerializeField] public GameObject[] Niv1;
    [SerializeField] public GameObject[] Niv2;
    [SerializeField] public GameObject[] Niv3;
    [SerializeField] public GameObject[] Niv4;
    [SerializeField] public GameObject[] Niv5;
    [SerializeField] public GameObject[] Niv9;
    [SerializeField] public GameObject[] Niv10;
    
    [SerializeField] public GameObject[] Chaos;


    
    

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
        
        int randomvalue = Random.Range(0,2);
        
        Light.RestartAnimation();
        Debug.Log("Tu es niveau" + Lvl);
        switch (Lvl)
        {
            case 1:
                GM_Spawner.randomKey=false;
                Niv1[0].SetActive(true);
                GM_Spawner.spawnCount=(0);
                Speedlight=0.2f;
                
                break;

            case 2:
                GM_Spawner.randomKey=false;
                GM_Spawner.spawnCount=(0);
                Niv1[0].SetActive(false);
                Niv2[0].SetActive(true);
                
                Speedlight=0;
                
                break;

            case 3:
                GM_Spawner.randomKey=false;
                GM_Spawner.spawnCount=(0);
                Niv2[0].SetActive(false);
                Niv3[0].SetActive(true);
                Speedlight=0.2f;
                        
                break;


            case 4:
                GM_Spawner.randomKey=true;
                GM_Spawner.spawnCount=(0);
                Niv3[0].SetActive(false);
                Niv4[0].SetActive(true);
                Speedlight=0.4f;      
                break;    


            case >4 and <9:
                GM_Spawner.randomKey=true;
                Niv4[PreviousLvl].SetActive(false);
                Niv5[randomvalue].SetActive(true);
                GM_Spawner.spawnCount=(int)(Lvl * 1.5f);
                Speedlight*=1.02f;                
                break;    

            case 9:
                GM_Spawner.randomKey=false;
                Niv4[PreviousLvl].SetActive(false);
                Niv9[0].SetActive(true);
                GM_Spawner.spawnCount=(int)(Lvl * 1.5f);
                Speedlight*=1.02f;                
                break;   
                  
            case >10 and <=16:
                GM_Spawner.randomKey=true;
                Niv9[PreviousLvl].SetActive(false);
                Niv10[randomvalue].SetActive(true);
                GM_Spawner.spawnCount=(int)(Lvl * 1.5f);
                Speedlight*=1.02f;                
                break;   

            case 17:
                GM_Spawner.randomKey=true;
                Niv10[PreviousLvl].SetActive(false);
                Chaos[0].SetActive(true);
                GM_Spawner.spawnCount=(int)(Lvl * 1.5f);
                Speedlight*=1.02f;                
                break;        

            default:
                GM_Spawner.randomKey=true;
                Chaos[PreviousLvl].SetActive(false);
                Chaos[randomvalue].SetActive(true);
                GM_Spawner.spawnCount=(int)(Lvl * 1.5f);
                Speedlight*=1.02f;                             
                break;

              
        }
        GM_Key = GameObject.Find("Key");
        PreviousLvl=randomvalue;
        GM_Spawner.Spawner();
        GM_Spawner.DestroyAllSpawnedObjects();
        Light.SetAnimationSpeed(Mathf.Min(Speedlight, 1.5f));
        DoorStart.Open();
        DoorStart.open=true;
        GM_Spawner.Spawner();  
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




