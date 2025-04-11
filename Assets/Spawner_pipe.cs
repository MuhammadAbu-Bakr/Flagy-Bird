using UnityEngine;

public class Spawner_pipe : MonoBehaviour
{
    public GameObject pipe;
    public float timer = 0;
    public float spawnRate = 2;
    public float heightOffset = 10;
    public float spawnXPosition = 35f;
    public float deadZoneXPosition = -35f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the spawner position to the spawnXPosition
        Vector3 position = transform.position;
        position.x = spawnXPosition;
        transform.position = position;
        
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        
        // Instantiate the pipe and store a reference to it
        GameObject newPipe = Instantiate(pipe, new Vector3(spawnXPosition, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        
        // Ensure the Parent_Pipe component is attached and enabled
        Parent_Pipe pipeScript = newPipe.GetComponent<Parent_Pipe>();
        if (pipeScript == null)
        {
            pipeScript = newPipe.AddComponent<Parent_Pipe>();
        }
        
        // Make sure it's enabled and has the correct values
        pipeScript.enabled = true;
        pipeScript.speed = 10f;
        pipeScript.deadZone = deadZoneXPosition;
        
        Debug.Log("Spawned new pipe at X: " + spawnXPosition + ", DeadZone set to: " + deadZoneXPosition);
    }
    
}
