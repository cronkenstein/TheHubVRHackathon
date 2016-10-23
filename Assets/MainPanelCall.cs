using UnityEngine;
using System.Collections;

public class MainPanelCall : MonoBehaviour {

    public PanelArray panelArray;
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    // Use this for initialization
    void Start () {
        panel.SetActive(true);
        fillPanelArrays();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void fillPanelArrays()
    {
        PanelArray panelArray = new PanelArray();
        panel2.GetComponent<DraggablePanel>().setArray(ref panelArray);
        panel3.GetComponent<DraggablePanel>().setArray(ref panelArray);
        panel4.GetComponent<DraggablePanel>().setArray(ref panelArray);
        button2.GetComponent<DraggableButton>().setArray(ref panelArray);
        button3.GetComponent<DraggableButton>().setArray(ref panelArray);
        button4.GetComponent<DraggableButton>().setArray(ref panelArray);
        button5.GetComponent<DraggableButton>().setArray(ref panelArray);
    }
}
