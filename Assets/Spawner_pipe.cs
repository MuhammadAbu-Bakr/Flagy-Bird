using UnityEngine;

public class Spawner_pipe : MonoBehaviour
{
    public GameObject pipe;
    public float timer = 0;
    public float spawnRate = 2;
    public float heightOffset = 10;
    public float spawnXPosition = 35f;
    public float deadZoneXPosition = -35f;

    void Start()
    {
        Vector3 position = transform.position;
        position.x = spawnXPosition;
        transform.position = position;
        
        spawnPipe();
    }

    
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
        
        
        GameObject newPipe = Instantiate(pipe, new Vector3(spawnXPosition, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        
        
        Parent_Pipe pipeScript = newPipe.GetComponent<Parent_Pipe>();
        if (pipeScript == null)
        {
            pipeScript = newPipe.AddComponent<Parent_Pipe>();
        }
        
        
        pipeScript.enabled = true;
        pipeScript.speed = 10f;
        pipeScript.deadZone = deadZoneXPosition;
        
        Debug.Log("Spawned new pipe at X: " + spawnXPosition + ", DeadZone set to: " + deadZoneXPosition);
    }
    
}
