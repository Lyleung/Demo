using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollision : MonoBehaviour
{
    public static int score = 0;
    public AudioClip coinPicking;

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
            Debug.Log("collided with coin");
            Destroy(obj.gameObject);
            score += 1;
        }

        AudioSource.PlayClipAtPoint(coinPicking, transform.position);
    }
}
