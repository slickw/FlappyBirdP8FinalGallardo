using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5; // Number of columns in the pool
    public GameObject columnPrefab; // Prefab of the column
    public float spawnRate = 4f; // Time between each spawn
    public float columnMin = -1f; // Minimum spawn Y position
    public float columnMax = -3.5f; // Maximum spawn Y position
    private GameObject[] columns; // Array to hold the columns
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f); // Position to hide columns
    private float timeSinceLastSpawned; // Timer to control spawn rate
    private float spawnXPosition = 10f; // X position where the columns spawn
    private int currentColumn = 0; // Index to track the current column to reuse

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        // Instantiate the columns and store them in the array
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Accumulate time since the last spawn
        timeSinceLastSpawned += Time.deltaTime;

        // Check if enough time has passed and the game is not over
        if (GameControl.instance != null && !GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0; // Reset the spawn timer

            // Generate a random Y position within the defined range
            float spawnYPosition = Random.Range(columnMin, columnMax);

            // Set the column's position to spawn at the right side of the screen
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            // Move to the next column in the pool
            currentColumn++;

            // Loop back to the start of the pool if all columns have been used
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
        }
    } 

