using UnityEngine;

public class Parent_Pipe : MonoBehaviour
{
    public float speed = 10f;
    public float deadZone = -35f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        // Set pipe tag

    }

    // Update is called once per frame
    void Update()
    {
        // Moving the pipe left at constant speed
        transform.position += Vector3.left * speed * Time.deltaTime;
        
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe is out of the screen");
            Destroy(gameObject);
        }
    }
}
