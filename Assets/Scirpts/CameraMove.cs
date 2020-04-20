using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float panSpeed = 20f;

    private int level;

    void Start()
    {
        level = BoardModel.gameLevel[BoardModel.currentGame];
    }

    // Start is called before the first frame update
    void Update()
    {
        Vector3 pos = transform.position;

        if (level == 3)
        {
            pos.y += panSpeed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
