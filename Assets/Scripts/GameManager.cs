using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public Material blueMaterial;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        // create array from all enemies and get their material
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverScreen.activeInHierarchy)
        {
            Debug.Log("Esc pressed");

            if (!pauseScreen.activeInHierarchy)
            {
                Debug.Log("Game paused");
                PauseGame();
            }
            else if (pauseScreen.activeInHierarchy)
            {
                Debug.Log("Game continued");
                ContinueGame();
            }
        }
    }
    
    // if the cube is collected, change material for all enemies
    public void ChangeColor()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<MeshRenderer>().material = blueMaterial;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        //enable the scripts again
    }
}
