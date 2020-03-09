using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinCollision : MonoBehaviour
{
    public static int score = 0;

    public AudioClip coinPicking;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        string tag = obj.gameObject.tag;

        if (tag == "Coin")
        {
            Debug.Log("Collided with coin");
            Destroy(obj.gameObject);
            score += 1;
        }

        Debug.Log(score);

        AudioSource.PlayClipAtPoint(coinPicking, transform.position);
        scoreText.text = "Score: " + score;
    }
}
