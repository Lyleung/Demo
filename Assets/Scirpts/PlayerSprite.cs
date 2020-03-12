using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public SpriteRenderer playerSpriteRender;
    public Animator playerAnimator;
    public Sprite liuBeiSprite;
    public Sprite caoCaoSprite;
    public RuntimeAnimatorController liuBeiAnimator;
    public RuntimeAnimatorController caoCaoAnimator;
    public int player = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(player == 1)
        {
            switch (CharactorSelectionModel.playerOne)
            {
                case 0:
                    Debug.Log("LiuBei");
                    playerSpriteRender.sprite = liuBeiSprite;
                    playerAnimator.runtimeAnimatorController = liuBeiAnimator;
                    break;
                case 1:
                    Debug.Log("CaoCao");
                    playerSpriteRender.sprite = caoCaoSprite;
                    playerAnimator.runtimeAnimatorController = caoCaoAnimator;
                    break;
                case 2:
                    Debug.Log("SunQuan");
                    break;
                default:
                    Debug.Log("default");
                    break;

            }
        } else if(player == 2)
        {
            switch (CharactorSelectionModel.playerTwo)
            {
                case 0:
                    Debug.Log("LiuBei");
                    playerSpriteRender.sprite = liuBeiSprite;
                    playerAnimator.runtimeAnimatorController = liuBeiAnimator;
                    break;
                case 1:
                    Debug.Log("CaoCao");
                    playerSpriteRender.sprite = caoCaoSprite;
                    playerAnimator.runtimeAnimatorController = caoCaoAnimator;
                    break;
                case 2:
                    Debug.Log("SunQuan");
                    break;
                default:
                    Debug.Log("default");
                    break;

            }
        }
    }
}
