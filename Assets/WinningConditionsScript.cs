using UnityEngine;

public class WinningConditionsScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    void Start()
    {
    }

    public bool CheckWinningConditions(int TokenXPosition, int TokenYPosition, int PlayerTurn, int[,] gridReference)

    {
        if (CheckVerticalWinConditions(TokenXPosition, TokenYPosition, PlayerTurn, gridReference) == true ||
        CheckHorizontalWinConditions(TokenXPosition, TokenYPosition, PlayerTurn, gridReference) == true ||
        CheckDiagonalWinConditions(TokenXPosition, TokenYPosition, PlayerTurn, gridReference) == true)
        {
            gameOverScreen.SetActive(true);
            return true;
        }

        return false;

    }

    private bool CheckVerticalWinConditions(int TokenXPosition, int TokenYPosition, int PlayerTurn, int[,] gridReference)
    {
        int TokensAbove = 0;
        int TokensBelow = 0;
        bool TokenSequenceAboveInturrupted = false;
        bool TokenSequenceBelowInturrupted = false;


        for (int i = 1; i < 7; i++)
        {
            if (TokenYPosition + i < 6 && gridReference[TokenXPosition, TokenYPosition + i] == PlayerTurn && !TokenSequenceAboveInturrupted)
            {
                TokensAbove += 1;
            } else
            {
                TokenSequenceAboveInturrupted = true;
            }


            if (TokenYPosition - i >= 0 && gridReference[TokenXPosition, TokenYPosition - i] == PlayerTurn && !TokenSequenceBelowInturrupted)
            {
                TokensBelow += 1;
            }
            else
            {
                TokenSequenceBelowInturrupted = true;
            }
        }
        return (TokensAbove + TokensBelow >= 3);
    }

    private bool CheckHorizontalWinConditions(int TokenXPosition, int TokenYPosition, int PlayerTurn, int[,] gridReference)
    {
        int tokensLeft = 0;
        int tokensRight = 0;
        bool TokenSequenceLeftInturrupted = false;
        bool TokenSequenceRightInturrupted = false;

        for (int i = 1; i < 8; i++)
        {
            if (TokenXPosition + i < 7 && gridReference[TokenXPosition + i, TokenYPosition] == PlayerTurn && !TokenSequenceLeftInturrupted)
            {
                tokensLeft += 1;
            }
            else
            {
                TokenSequenceLeftInturrupted = true;
            }

            if (TokenXPosition - i >= 0 && gridReference[TokenXPosition - i, TokenYPosition] == PlayerTurn && !TokenSequenceRightInturrupted)
            {
                tokensRight += 1;
            }
            else
            {
                TokenSequenceRightInturrupted = true;
            }
        }
        return (tokensLeft + tokensRight >= 3);
    }

    private bool CheckDiagonalWinConditions(int TokenXPosition, int TokenYPosition, int PlayerTurn, int[,] gridReference)
    {
        bool resultIncreasing = CheckDiagonalIncreasingi(TokenXPosition, TokenYPosition, PlayerTurn, gridReference);
        bool resultDecreasing = CheckDiagonalDecreasingi(TokenXPosition, TokenYPosition, PlayerTurn, gridReference);
        return (resultIncreasing || resultDecreasing);
    }

    private bool CheckDiagonalIncreasingi(int TokenXPosition, int TokenYPosition, int PlayerTurn, int[,] gridReference)
    {
        int tokensUpRight = 0;
        int tokensDownLeft = 0;
        bool TokenSequenceAboveInturrupted = false;
        bool TokenSequenceBelowInturrupted = false;

        for (int i = 1; i < 8; i++)
        {
            if (TokenXPosition + i < 7 && TokenYPosition + i < 6
                && gridReference[TokenXPosition + i, TokenYPosition + i] == PlayerTurn && !TokenSequenceAboveInturrupted)
            {
                tokensUpRight += 1;
            }
            else
            {
                TokenSequenceAboveInturrupted = true;
            }

            if (TokenXPosition - i >= 0 && TokenYPosition - i >= 0
                && gridReference[TokenXPosition - i, TokenYPosition - i] == PlayerTurn && !TokenSequenceBelowInturrupted)
            {
                tokensDownLeft += 1;
            }
            else
            {
                TokenSequenceBelowInturrupted = true;
            }
        }
        return (tokensDownLeft + tokensUpRight >= 3);
    }

    private bool CheckDiagonalDecreasingi(int TokenXPosition, int TokenYPosition, int PlayerTurn, int[,] gridReference)
    {
        int tokensDownRight = 0;
        int tokensUpLeft = 0;
        bool TokenSequenceAboveInturrupted = false;
        bool TokenSequenceBelowInturrupted = false;

        for (int i = 1; i < 8; i++)
        {
            if (TokenXPosition + i < 7 && TokenYPosition - i >= 0
                && gridReference[TokenXPosition + i, TokenYPosition - i] == PlayerTurn && !TokenSequenceAboveInturrupted)
            {
                tokensDownRight += 1;
            }
            else TokenSequenceAboveInturrupted = true;

            if (TokenXPosition - i >= 0 && TokenYPosition + i < 6
                && gridReference[TokenXPosition - i, TokenYPosition + i] == PlayerTurn && !TokenSequenceBelowInturrupted)
            {
                tokensUpLeft += 1;
            }
            else
            {
                TokenSequenceBelowInturrupted = true;
            }
        }
        return (tokensDownRight + tokensUpLeft >= 3);
    }

}
