using UnityEngine;

public class S_LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    public GameObject[][] levels; 

    void Start()
    {
        
        GameObject firstObjectInLevel1 = levels[0][0];
    }
}
