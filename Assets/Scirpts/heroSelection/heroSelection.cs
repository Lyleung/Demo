using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class heroSelection : MonoBehaviour
{
    private int selectedHeroIndex;
    private Color desiredColor;

    public int playerOne = 3;
    public int playerTwo = 3;

    public int currentPlayer = 1;

    [Header("List of heroes")]
    [SerializeField] private List<HeroSelectObject> heroList = new List<HeroSelectObject>();

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI heroName;
    [SerializeField] private TextMeshProUGUI currentSelecting;
    [SerializeField] private Image heroSplash;
    [SerializeField] private Image backgroundColor;



    private void Start()
    {
        UpdateHeroSelectionUI();
    }

    public void Update()
    {
        if (currentPlayer == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                selectedHeroIndex--;
                if(selectedHeroIndex < 0){
                    selectedHeroIndex = heroList.Count - 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    selectedHeroIndex++;
                        if(selectedHeroIndex > 2){
                            selectedHeroIndex = 0;
                        }
            } 
            else if (Input.GetKeyDown(KeyCode.UpArrow)){
                CharactorSelectionModel.playerOne = selectedHeroIndex;
                selectedHeroIndex = 0;
                currentPlayer++;
            }

            UpdateHeroSelectionUI();
        }
        else if (currentPlayer == 2)
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                selectedHeroIndex--;
                if(selectedHeroIndex < 0){
                    selectedHeroIndex = heroList.Count - 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                    selectedHeroIndex++;
                        if(selectedHeroIndex > 2){
                            selectedHeroIndex = 0;
                        }
            } 
            else if (Input.GetKeyDown(KeyCode.W)){
                CharactorSelectionModel.playerTwo = selectedHeroIndex;
                Time.timeScale = 0.0F;
            }

            UpdateHeroSelectionUI();
        }
    }

    public void LeftArrow(){
        selectedHeroIndex--;
        if(selectedHeroIndex < 0)
            selectedHeroIndex = heroList.Count - 1;

        UpdateHeroSelectionUI();
    }

    public void RightArrow(){
        selectedHeroIndex++;
        if(selectedHeroIndex > 2)
            selectedHeroIndex = 0;

        UpdateHeroSelectionUI();
    }

    private void UpdateHeroSelectionUI()
    {
        heroSplash.sprite = heroList[selectedHeroIndex].splash;
        heroName.text = heroList[selectedHeroIndex].heroName;
        backgroundColor.color = heroList[selectedHeroIndex].heroColor;
        string text = string.Format("Player {0} is selecting", currentPlayer);

        currentSelecting.text = text; 
        
    }

    [System.Serializable]
    public class HeroSelectObject
    {
        public Sprite splash;
        public string heroName;
        public Color heroColor;
    }
}
