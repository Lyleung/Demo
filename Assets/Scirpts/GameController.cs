using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public GameObject[] buttonImage;
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
   // public Player playerX;
    //public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    public Sprite redTile;
    public Sprite blueTile;

    private string playerSide;
    private int moveCount;

    private int player1tile;

    public SpriteRenderer playerOne;
    public SpriteRenderer playerTwo;
    public Sprite LiuBeiSprite;
    public Sprite CaoCaoSprite;
    public Sprite SunQuanSprite;

    private void Start()
    {
        Debug.Log("CharactorSelectionModel.playerOne: " + CharactorSelectionModel.playerOne);
        switch (CharactorSelectionModel.playerOne)
        {
            case 0:
                playerOne.sprite = LiuBeiSprite;
                break;
            case 1:
                playerOne.sprite = CaoCaoSprite;
                break;
            case 2:
                playerOne.sprite = SunQuanSprite;
                playerOne.transform.position = playerOne.transform.position + new Vector3(0f, 0.6f, 0f);
                break;
        }

        Debug.Log("CharactorSelectionModel.playerTwo: " + CharactorSelectionModel.playerTwo);
        switch (CharactorSelectionModel.playerTwo)
        {
            case 0:
                playerTwo.sprite = LiuBeiSprite;
                break;
            case 1:
                playerTwo.sprite = CaoCaoSprite;
                break;
            case 2:
                playerTwo.sprite = SunQuanSprite;
                playerTwo.transform.position = playerTwo.transform.position + new Vector3(0f, 0.6f, 0f);
                break;
        }
    }

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
        player1tile = 0;
        restartButton.SetActive(false);
        //SetPlayerColors(playerX, playerO);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (BoardModel.games[i] == 1)
                buttonList[i].text = "X";

            if (BoardModel.games[i] == 2)
                buttonList[i].text = "O";

            if (buttonList[i].text == "X") 
                buttonImage[i].GetComponent<Image>().sprite = blueTile;

            if (buttonList[i].text == "O")
                buttonImage[i].GetComponent<Image>().sprite = redTile;
        }
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSides();
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            //SetPlayerColors(playerX, playerO);
        }
        else
        {
           // SetPlayerColors(playerO, playerX);
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            for (int i=0; i < buttonList.Length; i++)
            {
                if (buttonList[i].text == "X")
                    player1tile++;
            }

            if (player1tile>=5)
                SetGameOverText("Player 1 Wins!");
            else
                SetGameOverText("Player 2 Wins!");
        }
        else
        {
            if (winningPlayer == "X")
                SetGameOverText("Player 1 Wins!");
            else
                SetGameOverText("Player 2 Wins!");
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        //SetPlayerColors(playerX, playerO);
        SetBoardInteractable(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }

        SceneManager.LoadScene("Opening");
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}