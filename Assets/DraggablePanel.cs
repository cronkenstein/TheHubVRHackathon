using UnityEngine;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DraggablePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform target;
    public GameObject panel;
    public GameObject button;
    private bool isMouseDown = false;
    private bool isMouseUp = false;
    private float startMousePositionY;
    private Vector3 startPosition;
    public bool shouldReturn;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
       
    }

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;

        Debug.Log("Draggable Mouse Down");

        startPosition = target.position;
        startMousePositionY = Input.mousePosition.y;
    }

    public void OnPointerUp(PointerEventData dt)
    {
        Debug.Log("Draggable mouse up");

        isMouseDown = false;

        
        if (Math.Abs(target.position.y) >= 600)
        {
            isMouseUp = true;
        }
        else if (shouldReturn)
        {
            target.position = startPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            float currentPositionY = Input.mousePosition.y;

            float diff = currentPositionY - startMousePositionY;

            float pos = startPosition.y + diff;

            target.position = new Vector3(startPosition.x, pos);
        }

        if(isMouseUp)
        {
            target.position = new Vector3(startPosition.x, target.position.y + 30);
        }
        if (target.position.y >= 850)
        {
            Disable();
            isMouseUp = false;
        }
        
    }

    void Disable()
    {
        panel.SetActive(false);
        target.position = startPosition;
        button.GetComponent<Button>().interactable = true;
    }
}
