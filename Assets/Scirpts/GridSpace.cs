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

    public void SetSpace()
    {
        
        if (EventSystem.current.currentSelectedGameObject.name == "Grid Space (1)" ||
            EventSystem.current.currentSelectedGameObject.name == "Grid Space (3)" ||
            EventSystem.current.currentSelectedGameObject.name == "Grid Space (5)" ||
            EventSystem.current.currentSelectedGameObject.name == "Grid Space (7)")
            SceneManager.LoadScene("BattleLevelOneScene");

        if (EventSystem.current.currentSelectedGameObject.name == "Grid Space" ||
            EventSystem.current.currentSelectedGameObject.name == "Grid Space (2)" ||
            EventSystem.current.currentSelectedGameObject.name == "Grid Space (6)" ||
            EventSystem.current.currentSelectedGameObject.name == "Grid Space (8)")
            SceneManager.LoadScene("BattleLevelTwoScene");

        if (EventSystem.current.currentSelectedGameObject.name == "Grid Space (4)")
            SceneManager.LoadScene("BattleLevelThreeScene");
        

        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
}