using UnityEngine;

public class S_Door : MonoBehaviour
{
    public float rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation = transform.rotation.y;
    }

    // Update is called once per frame
    void Open(int direction)
    {
        transform.rotation.y= (90*direction) + transform.rotation.y;
    }
}
