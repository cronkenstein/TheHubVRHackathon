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
    private bool isMouseDown = false;
    private bool isMouseUp = false;
    private bool animationDone = false;
    private float rtX;
    private float startMousePositionX;
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
        startMousePositionX = Input.mousePosition.x;
        rt = button.GetComponent<RectTransform>();
        rtX = rt.rect.width;


    }

    public void OnPointerUp(PointerEventData dt)
    {
        Debug.Log("Draggable mouse up");

        isMouseDown = false;
        

        if (Math.Abs(target.position.x) >= 1100 || Math.Abs(target.position.x)<=300)
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
            
            if (rt.sizeDelta.x < (rtX + 30) && !animationDone)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x + 30, rt.sizeDelta.y);
                if(rt.sizeDelta.x > (rtX + 30))
                {
                    animationDone = true;
                }
               
            }
            else if(rt.sizeDelta.x < -1000)
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

        print("I am reaching this point");
        button.GetComponent<Button>().interactable = false;
        rt.offsetMax.Set(0, 0);
        rt.offsetMin.Set(0, 0);
    }
}
