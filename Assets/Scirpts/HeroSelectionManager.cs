using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroSelectionManager : MonoBehaviour
{
    public GameObject p1_0;
    public GameObject p2_0;
    public GameObject p1_1;
    public GameObject p2_1;
    public GameObject p1_2;
    public GameObject p2_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            CharactorSelectionModel.playerOne = (CharactorSelectionModel.playerOne + 1) % 3;
        } else if(Input.GetKeyDown(KeyCode.A))
        {
            if(CharactorSelectionModel.playerOne == 0)
            {
                CharactorSelectionModel.playerOne = 3;
            } else
            {
                CharactorSelectionModel.playerOne -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharactorSelectionModel.playerTwo = (CharactorSelectionModel.playerTwo + 1) % 3;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CharactorSelectionModel.playerTwo == 0)
            {
                CharactorSelectionModel.playerTwo = 3;
            } else
            {
                CharactorSelectionModel.playerTwo -=1;
            }
        }

        //Update Selection
        switch (CharactorSelectionModel.playerOne)
        {
            case 0:
                p1_0.SetActive(true);
                p1_1.SetActive(false);
                p1_2.SetActive(false);
                break;
            case 1:
                p1_0.SetActive(false);
                p1_1.SetActive(true);
                p1_2.SetActive(false);
                break;
            case 2:
                p1_0.SetActive(false);
                p1_1.SetActive(false);
                p1_2.SetActive(true);
                break;
            default:
                break;
        }

        switch (CharactorSelectionModel.playerTwo)
        {
            case 0:
                p2_0.SetActive(true);
                p2_1.SetActive(false);
                p2_2.SetActive(false);
                break;
            case 1:
                p2_0.SetActive(false);
                p2_1.SetActive(true);
                p2_2.SetActive(false);
                break;
            case 2:
                p2_0.SetActive(false);
                p2_1.SetActive(false);
                p2_2.SetActive(true);
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Board");
        }


    }

}
