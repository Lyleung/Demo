using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public Text playerOneScoreText;
    public Text playerTwoScoreText;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public AudioSource backgroundMusic;
    public float loadSceneDelay = 3f;
    public GameObject battleEndUI;
    public Text wonPlayerText;

    private int level = BoardModel.gameLevel[BoardModel.currentGame];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("current level: " + level);
        //backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    { 
        //count coins
        int coinCount = GameObject.FindGameObjectsWithTag("Coin").Length;

        //update score
        playerOneScoreText.text = "Score: " + playerOneScore;
        playerTwoScoreText.text = "Score: " + playerTwoScore;

        //end game
        if(coinCount <= 0)
        {
            battleEnd();
        }

    }

    void battleEnd()
    {
        if (playerOneScore > playerTwoScore) wonPlayerText.text = "Player 1";
        else wonPlayerText.text = "Player 2";

        // switch to board scene
        battleEndUI.SetActive(true);
    }

}
