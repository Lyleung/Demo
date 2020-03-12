using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public int level = 1;
    public Text playerOneScoreText;
    public Text playerTwoScoreText;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;

    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
