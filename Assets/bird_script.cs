using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength =10f;
    private Logic_script logic;
    private bool isAlive = true;
    
    // Store pipes we've already scored from
    private System.Collections.Generic.HashSet<int> scoredPipes = new System.Collections.Generic.HashSet<int>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
        // Find the Logic_script in the scene
        // logic = FindObjectOfType<Logic_script>();
        if (logic == null)
        {
            Debug.LogWarning("Logic script not found!");
        }
        
        // Set the player tag
        if (GameObject.FindWithTag("Player") == null)
        {
            Debug.LogWarning("Player tag not defined! Please add it in Edit -> Project Settings -> Tags and Layers");
        }
        else
        {
            gameObject.tag = "Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only allow flapping if the bird is alive
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
        
        // Score when passing pipes
        if (isAlive)
        {
            CheckPipeScoring();
        }
    }
    
    void CheckPipeScoring()
    {
        try
        {
            // Find all pipes using component lookup instead of tags
            Parent_Pipe[] pipes = FindObjectsOfType<Parent_Pipe>();
            
            foreach (Parent_Pipe pipe in pipes)
            {
                // Get a unique ID for this pipe
                int pipeId = pipe.gameObject.GetInstanceID();
                
                // If we've already scored from this pipe, skip it
                if (scoredPipes.Contains(pipeId))
                    continue;
                    
                // Check if bird has passed this pipe
                if (transform.position.x > pipe.transform.position.x)
                {
                    // Score a point
                    if (logic != null)
                    {
                        logic.addScore(1);
                        Debug.Log("Score! Current score: " + logic.playerScore);
                    }
                    
                    // Mark this pipe as scored
                    scoredPipes.Add(pipeId);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error checking pipe scoring: " + e.Message);
        }
    }
    
    // Called when the bird collides with something
    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        isAlive = false;

    }
}
