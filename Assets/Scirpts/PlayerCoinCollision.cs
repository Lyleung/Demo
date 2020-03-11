using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinCollision : MonoBehaviour
{
    public static int score = 0;

    public AudioClip coinPicking;
    public Text scoreText;

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
            score += 1;
        }

        AudioSource.PlayClipAtPoint(coinPicking, transform.position);
        scoreText.text = "Score: " + score;

        isColliding = true;
    }
}
