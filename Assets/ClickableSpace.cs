using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableSpace : MonoBehaviour
{
    public GameManager GameManager { get; set; }

    public void SelectSpace()
    {
        GetComponentInChildren<Text>().text = GameManager.CurrentPlayer;

        GameManager.CompleteTurn();
    }
}
