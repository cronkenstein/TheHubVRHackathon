using UnityEngine;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DraggableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   

    public Transform target;
    public GameObject button;
    public RectTransform rt;
    public GameObject panel;
    public GameObject canvas;
    private PanelArray panelArr = new PanelArray();
    private RotationIndex1 index1 = new RotationIndex1();
    private bool isMouseDown = false;
    private bool isMouseUp = false;
    private bool animationDone = false;
    private float rtX;
    private float startMousePositionX;
    private Vector3 startPosition;
    private Vector2 startDelta;
    public bool shouldReturn;

    // Use this for initialization
    void Start()
    {
        startDelta = rt.sizeDelta;
    }

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;
        

        Debug.Log("Draggable Mouse Down");

        startPosition = target.position;
        startMousePositionX = Input.mousePosition.x;
        rt = button.GetComponent<RectTransform>();
        rtX = rt.rect.width;


    }

    public void OnPointerUp(PointerEventData dt)
    {
        Debug.Log("Draggable mouse up");

        isMouseDown = false;
        

        if (Math.Abs(target.position.x) > 0 || Math.Abs(target.position.x)<0)
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
            Vector3 currentPosition = Input.mousePosition;

            float diff = currentPosition.x - startMousePositionX;

            float pos = startPosition.x + diff;

            target.position = new Vector3(pos, startPosition.y);
        }
        if (isMouseUp)
        {
            if (target.position.x < 0)
            {
                int x = panelArr.addPanel(3);
                switch (x)
                {
                    case 1 :
                        index1.initializePanel(canvas);
                        index1.setRotationOne();
                        break;
                    case 3:
                        break;
                    case 5:
                        break;
                }
            }
            else
            {

            }
            if (rt.sizeDelta.x < (rtX + 30) && !animationDone)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + 30, rt.sizeDelta.y);
                if(rt.sizeDelta.x > (rtX + 30))
                {
                    animationDone = true;
                }
               
            }
            else if(rt.sizeDelta.x < Math.Abs(300))
            {
                Disable();
                panel.SetActive(true);
                
                
                isMouseUp = false;
                animationDone = false;
            }
            else
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x -30, rt.sizeDelta.y);
            }
        }

    }

    void Disable()
    { 
        button.GetComponent<Button>().interactable = false;
        rt.sizeDelta = startDelta;
        target.position = startPosition;
    }
}
