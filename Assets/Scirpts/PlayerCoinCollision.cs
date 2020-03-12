using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinCollision : MonoBehaviour
{
    public AudioClip coinPicking;
    public BattleManager battleManager;

    public int player = 1;
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (isColliding) return;

        string tag = obj.gameObject.tag;

        if (tag == "Coin")
        {
            Debug.Log("Collided with coin");
            obj.gameObject.SetActive(false);
            Destroy(obj.gameObject);

            if (player == 1) battleManager.playerOneScore += 1;
            if (player == 2) battleManager.playerTwoScore += 1;
        }

        AudioSource.PlayClipAtPoint(coinPicking, transform.position, 1.0f);
        
        isColliding = true;
    }
}
