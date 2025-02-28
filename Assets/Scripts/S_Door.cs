using UnityEngine;

public class S_Door : MonoBehaviour
{
    public float direction;
    public bool open=false;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Open()
    {
        S_SoundManager.instance.Play("DoorOpen");
        transform.Rotate(0, 90 * direction, 0);

    }
    public void Close()
    {
        S_SoundManager.instance.Play("DoorSlam");
        transform.Rotate(0, -90 * direction, 0);
        
    }
}
