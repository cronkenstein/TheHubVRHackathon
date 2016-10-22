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
    public DraggablePanel panel;
    private bool isMouseDown = false;
    private float startMousePositionY;
    private Vector3 startPosition;
    public bool shouldReturn;

    // Use this for initialization
    void Start()
    {

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

        if (shouldReturn)
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

        if (Math.Abs(target.position.y) >= 440)
        {
            Disable();
        }
    }

    void Disable()
    {
        panel = target.GetComponent<DraggablePanel>();
        panel.Disable();
    }
}
