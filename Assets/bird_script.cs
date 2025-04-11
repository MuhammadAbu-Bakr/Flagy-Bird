using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength =10f;
    private Logic_script logic;
    private bool isAlive = true;
    
    private System.Collections.Generic.HashSet<int> scoredPipes = new System.Collections.Generic.HashSet<int>();
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_script>();
  
        if (logic == null)
        {
            Debug.LogWarning("Logic script not found!");
        }
        
        if (GameObject.FindWithTag("Player") == null)
        {
            Debug.LogWarning("Player tag not defined! Please add it in Edit -> Project Settings -> Tags and Layers");
        }
        else
        {
            gameObject.tag = "Player";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
        
        if (isAlive)
        {
            CheckPipeScoring();
        }
    }
    
    void CheckPipeScoring()
    {
        try
        {
            Parent_Pipe[] pipes = FindObjectsOfType<Parent_Pipe>();
            
            foreach (Parent_Pipe pipe in pipes)
            {
                int pipeId = pipe.gameObject.GetInstanceID();
                
                if (scoredPipes.Contains(pipeId))
                    continue;
                    
                if (transform.position.x > pipe.transform.position.x)
                {
                    if (logic != null)
                    {
                        logic.addScore(1);
                        Debug.Log("Score! Current score: " + logic.playerScore);
                    }
                    
                    scoredPipes.Add(pipeId);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error checking pipe scoring: " + e.Message);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        isAlive = false;
    }
}
