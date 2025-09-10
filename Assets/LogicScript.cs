using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int PlayerTurn = 1;
    public int[,] gridReference = new int[7,6];
    private int[] playerScores = {0, 0};
    private WinningConditionsScript WinningConditionsScript;
    public bool gamePaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinningConditionsScript = (WinningConditionsScript)GetComponent("WinningConditionsScript");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddTokenToList(int TokenXPosition, int TokenYPosition)
    {

        if (gridReference[TokenXPosition, TokenYPosition] == 0)
        {
            gridReference[TokenXPosition, TokenYPosition] = PlayerTurn;
            
        }

        Print2DArray(gridReference);

        

        if (WinningConditionsScript.CheckWinningConditions(TokenXPosition, TokenYPosition, PlayerTurn, gridReference))
        {
            gamePaused = true;
        }

        if (PlayerTurn == 1)
        {
            PlayerTurn = 2;
        }
        else
        {
            PlayerTurn = 1;
        }

        
    }

    /// <summary>
    /// Prints 2D array in console, for debugging purposes only.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="matrix"></param>
    public static void Print2DArray<T>(T[,] matrix)
    {
        string tmpInnerString = "";
        string fullString = "";

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                tmpInnerString += matrix[j, i].ToString() + ", ";
            }
            fullString = "( " + tmpInnerString + ")\n" + fullString;
            tmpInnerString = "";
        }
        Debug.Log(fullString);
    }

    public int GetPlayerTurn()
    {
        return PlayerTurn;
    }

    /// <summary>
    /// Reset entire game. 
    /// </summary>
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// New game keeping score for players
    /// </summary>
    public void Rematch()
    {
        Debug.Log((GetPlayerTurn() - 1).ToString());


        playerScores[GetPlayerTurn()-1] += 1;

        //for (int i = 0; i < 10; i++)
        //{
        //    Debug.Log(playerScores[i].ToString());
        //}

        Debug.Log("playerScores: " + playerScores[0] + playerScores[1]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gridReference = new int[7, 6];

        
    }

    public bool IsGamePaused()
    {
        return gamePaused;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


