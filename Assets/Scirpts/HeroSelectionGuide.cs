using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionGuide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guide;
    // Start is called before the first frame update

    // IEnumerator RemoveAfterSeconds (int seconds, GameObject obj){
    //     yield return new WaitForSeconds(5.0f);
    //     obj.SetActive(false);
    // }

    IEnumerator Fade()
    {
        Renderer renderer = guide.GetComponent<Renderer>();
        Color newColor = renderer.material.color;      
        for (float f = 3f; f >= 0; f -= 0.1f)
        {  
            newColor.a = f;
            renderer.material.color = newColor;
            yield return new WaitForSeconds(.1f);
        }
    }


    void Start()
    {
        // StartCoroutine(RemoveAfterSeconds(5, guide));
        StartCoroutine(Fade());
    }
}
