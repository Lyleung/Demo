using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionGuide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guide;
    // Start is called before the first frame update

    IEnumerator RemoveAfterSeconds (int seconds, GameObject obj){
        yield return new WaitForSeconds(5.0f);
        obj.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(5, guide));
    }
}
