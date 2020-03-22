using UnityEngine;
using UnityEngine.UI;
public class BattleManager : MonoBehaviour
{
    public Text playerOneScoreText;
    public Text playerTwoScoreText;
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public Text wonPlayerText;
    public Text timerText;
    public AudioSource backgroundMusic;
    public float loadSceneDelay = 3f;
    public GameObject battleEndUI;
    public GameObject coinObject;

    private int level;
    private int time = 15;

    // Start is called before the first frame update
    void Start()
    {
        level = BoardModel.gameLevel[BoardModel.currentGame];
        Debug.Log("current level: " + level);
        // backgroundMusic.Play();

        if (level == 2)
        {
            InvokeRepeating("timer", 0f, 1f);
            InvokeRepeating("generateCoin", 1.0f, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //count coins
        int coinCount = GameObject.FindGameObjectsWithTag("Coin").Length;

        //update score
        playerOneScoreText.text = "Score: " + playerOneScore;
        playerTwoScoreText.text = "Score: " + playerTwoScore;

        if (level == 1)
        {
            //end game
            if (coinCount <= 0)
            {
                battleEnd();
            }
        }
        else if (level == 2)
        {
            if (time <= 0)
            {
                if(playerOneScore != playerTwoScore) battleEnd();
                else
                {
                    timerText.text = "First Take To Win";
                }
            }

        }
        else if (level == 3)
        {

        }

    }

    void battleEnd()
    {
        int wonPlayer = 0;
        if (playerOneScore > playerTwoScore) wonPlayer = 1;
        else wonPlayer = 2;

        wonPlayerText.text = "Player " + wonPlayer;
        BoardModel.games[BoardModel.currentGame] = wonPlayer;

        battleEndUI.SetActive(true); //Animation with load scene
    }

    void generateCoin()
    {
        Vector3 position = new Vector3(Random.Range(-11, 11), Random.Range(-1, 6), 0);
        Instantiate(coinObject, position, Quaternion.identity);
    }

    void timer()
    {
        if (time > 0)
        {
            time -= 1;
            timerText.text = "" + time;
        }
    }
}
