using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RotationIndex4 : MonoBehaviour
{

    public Transform t;
    public GameObject panel;
    public GameObject canvas;
    private Vector3 originVector;
    private Vector3 futureVector;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initializePanel(GameObject canvasName)
    {

        canvas = canvasName;
        originVector = canvas.GetComponent<Transform>().position;
        futureVector = new Vector3(0, -30);
    }

    public void setRotationOne()
    {
        t = canvas.GetComponent<Transform>();
        t.Translate(new Vector3(-45, t.position.y));
        t.Rotate(Vector3.up, -2f);
    }

}
