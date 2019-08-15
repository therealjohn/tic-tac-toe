using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
#pragma warning disable CS0649

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] boardSpaces;

    [SerializeField]
    GameObject restartButton;

    Text[] boardSpaceTexts;

    string player1 = "x";
    string player2 = "o";
    int moveCount = 0;
    int maxMoveCount = 9;

    public string CurrentPlayer { get; set; } = "x";

    private void Awake()
    {
        restartButton.SetActive(false);
        boardSpaceTexts = new Text[boardSpaces.Length];

        for (int i = 0; i < boardSpaces.Length; i++)
        {
            boardSpaces[i].GetComponentInChildren<ClickableSpace>().GameManager = this;
            boardSpaceTexts[i] = boardSpaces[i].GetComponentInChildren<Text>();
            boardSpaceTexts[i].text = string.Empty;
        }
    }

    public void CompleteTurn()
    {
        moveCount++;

        if(boardSpaceTexts[0].text == CurrentPlayer && boardSpaceTexts[1].text == CurrentPlayer && boardSpaceTexts[2].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[3].text == CurrentPlayer && boardSpaceTexts[4].text == CurrentPlayer && boardSpaceTexts[5].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[6].text == CurrentPlayer && boardSpaceTexts[7].text == CurrentPlayer && boardSpaceTexts[8].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[0].text == CurrentPlayer && boardSpaceTexts[3].text == CurrentPlayer && boardSpaceTexts[6].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[1].text == CurrentPlayer && boardSpaceTexts[4].text == CurrentPlayer && boardSpaceTexts[7].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[2].text == CurrentPlayer && boardSpaceTexts[5].text == CurrentPlayer && boardSpaceTexts[8].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[0].text == CurrentPlayer && boardSpaceTexts[4].text == CurrentPlayer && boardSpaceTexts[8].text == CurrentPlayer)
        {
            GameOver();
        }
        else if (boardSpaceTexts[2].text == CurrentPlayer && boardSpaceTexts[4].text == CurrentPlayer && boardSpaceTexts[6].text == CurrentPlayer)
        {
            GameOver();
        }
        else if(moveCount >= maxMoveCount)
        {
            Draw();
        }
        else
        {
            if (CurrentPlayer == player1)
                CurrentPlayer = player2;
            else
                CurrentPlayer = player1;
        }
    }

    void Draw()
    {
        Debug.Log($"It's a draw!");        
    }

    void GameOver()
    {
        Debug.Log($"Player {CurrentPlayer} wins!");
        restartButton.SetActive(true);
    }

    public void Restart()
    {
        moveCount = 0;
        restartButton.SetActive(false);

        for (int i = 0; i < boardSpaceTexts.Length; i++)
        {
            boardSpaceTexts[i].text = string.Empty;
        }
    }
}

#pragma warning restore CS0649