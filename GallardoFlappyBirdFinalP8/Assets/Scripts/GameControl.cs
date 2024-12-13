using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameControl : MonoBehaviour
{
    public static GameControl instance;  // Singleton instance
    public GameObject gameOverText;      // Reference to the Game Over text
    public bool gameOver = false;        // Flag to check if the game is over
    public float scrollSpeed = -1.5f;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Implement singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy this instance if another one exists
        }
    }

    // Update is called once per frame (you can add logic here if necessary)
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown (0)) 
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }

    // This method is called when the bird dies (e.g., in collision detection)
    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    
    
    
    public void BirdDied()
    {
        if (gameOverText != null)
        {
            gameOverText.SetActive(true); // Show the game over text
        }
        gameOver = true;  // Set the game over flag to true
    }
}



