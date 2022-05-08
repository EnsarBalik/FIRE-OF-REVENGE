using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallx : MonoBehaviour
{
    public Transform farBackground, middleBackground;
    private Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 amountToMove = transform.position - lastPos;
        farBackground.position += new Vector3(amountToMove.x * .9f, amountToMove.y * .9f, 0f);
        middleBackground.position += new Vector3(amountToMove.x * .5f, amountToMove.y * .5f, 0f);

        lastPos = transform.position;
    }
}
