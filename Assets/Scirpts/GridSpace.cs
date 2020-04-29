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

    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    private void Update()
    {
        if (gameObject.name == "Grid Space" && BoardModel.games[0] != 0 ||
            gameObject.name == "Grid Space (1)" && BoardModel.games[1] != 0 ||
            gameObject.name == "Grid Space (2)" && BoardModel.games[2] != 0 ||
            gameObject.name == "Grid Space (3)" && BoardModel.games[3] != 0 ||
            gameObject.name == "Grid Space (4)" && BoardModel.games[4] != 0 ||
            gameObject.name == "Grid Space (5)" && BoardModel.games[5] != 0 ||
            gameObject.name == "Grid Space (6)" && BoardModel.games[6] != 0 ||
            gameObject.name == "Grid Space (7)" && BoardModel.games[7] != 0 ||
            gameObject.name == "Grid Space (8)" && BoardModel.games[8] != 0)
            button.interactable = false;
    }

    public void SetSpace()
    {
        if (gameObject.name == "Grid Space") {
            BoardModel.currentGame = 0;
            SceneManager.LoadScene("BattleLevelTwoScene");
        }
        else if (gameObject.name == "Grid Space (1)")
        {
            BoardModel.currentGame = 1;
            SceneManager.LoadScene("BattleLevelOneScene");
        }
        else if (gameObject.name == "Grid Space (2)")
        {
            BoardModel.currentGame = 2;
            SceneManager.LoadScene("BattleLevelTwoScene");
        }
        else if (gameObject.name == "Grid Space (3)")
        {
            BoardModel.currentGame = 3;
            SceneManager.LoadScene("BattleLevelOneScene");
        }
        else if (gameObject.name == "Grid Space (4)")
        {
            BoardModel.currentGame = 4;
            SceneManager.LoadScene("BattleLevelThreeScene");
        }
        else if (gameObject.name == "Grid Space (5)")
        {
            BoardModel.currentGame = 5;
            SceneManager.LoadScene("BattleLevelOneScene");
        }
        else if (gameObject.name == "Grid Space (6)")
        {
            BoardModel.currentGame = 6;
            SceneManager.LoadScene("BattleLevelTwoScene");
        }
        else if (gameObject.name == "Grid Space (7)")
        {
            BoardModel.currentGame = 7;
            SceneManager.LoadScene("BattleLevelOneScene");
        }
        else if (gameObject.name == "Grid Space (8)")
        {
            BoardModel.currentGame = 8;
            SceneManager.LoadScene("BattleLevelTwoScene");
        }
        

        buttonText.text = gameController.GetPlayerSide();
        gameController.EndTurn();
    }
}