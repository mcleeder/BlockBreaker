using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool gameLost = false;
    public TMPro.TextMeshProUGUI pressSpace;
    public TMPro.TextMeshProUGUI levelNumber;
    private GameObject[] blocks; 

    // Update is called once per frame
    void Update()
    {
        blocks = GameObject.FindGameObjectsWithTag("Blocks");
        if (blocks.Length == 0)
        {
            GameOver("You Won!");
        }
        if (gameLost)
        {
            GameOver("You Lost!");
        }
        
    }

    public void GameOver(string text)
    {
        levelNumber.text = text;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Paddle"));
    }
}
