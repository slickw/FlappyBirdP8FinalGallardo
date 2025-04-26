using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameControl : MonoBehaviour
{
    public static GameControl instance; 
    public GameObject gameOverText;      
    public bool gameOver = false;        
    public float scrollSpeed = -1.5f;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Update is called once per frame 
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown (0)) 
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }

    
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



