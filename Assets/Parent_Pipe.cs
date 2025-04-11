using UnityEngine;

public class Parent_Pipe : MonoBehaviour
{
    public float speed = 10f;
    public float deadZone = -35f;
    
    void Start()
    {
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe is out of the screen");
            Destroy(gameObject);
        }
    }
}
