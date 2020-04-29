using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridSpace : MonoBehaviour
{

    public Button button;
    public Text buttonText;
    public int id;

    private GameController gameController;

    private void Start()
    {
        if (gameObject.name == "Grid Space")
            id = 0;
        else if (gameObject.name == "Grid Space (1)")
            id = 1;
        else if (gameObject.name == "Grid Space (2)")
            id = 2;
        else if (gameObject.name == "Grid Space (3)")
            id = 3;
        else if (gameObject.name == "Grid Space (4)")
            id = 4;
        else if (gameObject.name == "Grid Space (5)")
            id = 5;
        else if (gameObject.name == "Grid Space (6)")
            id = 6;
        else if (gameObject.name == "Grid Space (7)")
            id = 7;
        else if (gameObject.name == "Grid Space (8)")
            id = 8;
    }

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    private void Update()
    {
        if (BoardModel.games[id] != 0 && button.interactable != false)
        { 
            button.interactable = false;

            if (BoardModel.games[id] == 1)
                buttonText.text = "X";
            else
                buttonText.text = "O";

            gameController.EndTurn(buttonText.text);
        }
    }

    public void SetSpace()
    {
        BoardModel.currentGame = id;

        if (id == 0 || id == 2 || id == 6 || id == 8) {
            SceneManager.LoadScene("BattleLevelTwoScene");
        }
        else if (id == 1 || id == 3 || id == 5 || id == 7)
        {
            SceneManager.LoadScene("BattleLevelOneScene");
        }
        else if (id == 4)
        {
            SceneManager.LoadScene("BattleLevelThreeScene");
        }
    }
}