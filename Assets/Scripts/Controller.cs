using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject player;
    public int speed;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.transform.position += Vector3.forward * speed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.transform.position += Vector3.back * speed;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.transform.position += Vector3.left * speed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.transform.position += Vector3.right * speed;
        }
        
    }
}
