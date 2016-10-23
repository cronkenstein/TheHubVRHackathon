using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RotationIndex3 
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
     
    }

    public void setRotationOne()
    {
        t = canvas.GetComponent<Transform>();
        t.Translate(new Vector3(-1500, t.position.y, -1000));
        t.Rotate(Vector3.up, -90f);
    }

}
