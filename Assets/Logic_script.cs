using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Logic_script : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Button restartButton;
    public GameObject gameOverScreen;


    void Start()
    {
        // If you assigned the button in the inspector
        if (restartButton != null)
        {
            // Add a listener to the button click event
            restartButton.onClick.AddListener(RestartButtonClicked);
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    
    // This is the function that should appear in the button's OnClick menu
    public void RestartButtonClicked()
    {
        Debug.Log("Restart button clicked!");
        restartGame();
    }
    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);

    }

}
