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
    public GameObject description;
    public GameObject liuBeiText;
    public GameObject caoCaoText;
    public GameObject sunQuanText;

    public AudioSource selectSFX;

    public int descriptionStatus = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        description.SetActive(false);
        liuBeiText.SetActive(false);
        caoCaoText.SetActive(false);
        sunQuanText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (descriptionStatus == 0)
        {
        
            if(Input.GetKeyDown(KeyCode.D))
            {
                CharactorSelectionModel.playerOne = (CharactorSelectionModel.playerOne + 1) % 3;
                selectSFX.Play();
            } else if(Input.GetKeyDown(KeyCode.A))
            {
                if(CharactorSelectionModel.playerOne == 0)
                {
                    CharactorSelectionModel.playerOne = 3;
                } else
                {
                    CharactorSelectionModel.playerOne -= 1;
                }
                selectSFX.Play();
            } else if (Input.GetKeyDown(KeyCode.W))
            {
                description.SetActive(true);
                descriptionStatus = 1;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CharactorSelectionModel.playerTwo = (CharactorSelectionModel.playerTwo + 1) % 3;
                selectSFX.Play();
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
                selectSFX.Play();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                description.SetActive(true);
                descriptionStatus = 2;
            }

        } else if (descriptionStatus == 1){
            if (Input.GetKeyDown(KeyCode.W))
            {
                description.SetActive(false);
                descriptionStatus = 0;
            }
        }

        else if (descriptionStatus == 2){
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                description.SetActive(false);
                descriptionStatus = 0;
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

        if (descriptionStatus == 0)
        {
            liuBeiText.SetActive(false);
            caoCaoText.SetActive(false);
            sunQuanText.SetActive(false);

        } else if (descriptionStatus == 1){
            switch (CharactorSelectionModel.playerOne)
            {
                case 0:
                    liuBeiText.SetActive(true);
                    caoCaoText.SetActive(false);
                    sunQuanText.SetActive(false);
                    break;
                case 1:
                    liuBeiText.SetActive(false);
                    caoCaoText.SetActive(true);
                    sunQuanText.SetActive(false);
                    break;
                case 2:
                    liuBeiText.SetActive(false);
                    caoCaoText.SetActive(false);
                    sunQuanText.SetActive(true);
                    break;
                default:
                    break;
            }
        } else if (descriptionStatus == 2){
            switch (CharactorSelectionModel.playerTwo)
            {
                case 0:
                    liuBeiText.SetActive(true);
                    caoCaoText.SetActive(false);
                    sunQuanText.SetActive(false);
                    break;
                case 1:
                    liuBeiText.SetActive(false);
                    caoCaoText.SetActive(true);
                    sunQuanText.SetActive(false);
                    break;
                case 2:
                    liuBeiText.SetActive(false);
                    caoCaoText.SetActive(false);
                    sunQuanText.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Board");
        }


    }

}
