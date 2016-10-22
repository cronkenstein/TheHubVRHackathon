using UnityEngine;
using System.Collections;

public class PanelArray : MonoBehaviour {

    public int[] panelArr = new int[6];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    public int addPanel(int num)
    {
        int x = 0;
        if (num % 2 != 0)
        {
            x = 1;
            while (x <= 5)
            {
                if (panelArr[x] == 1)
                {
                    x += 2;
                }
                else
                {
                    return x;
                }
            }
        }
        else
        {
            x = 0;
            while (x <= 4)
            {
                if (panelArr[x] == 1)
                {
                    x += 2;
                }
                else
                {
                    return x;
                }
            }
        }
        return 0;
    }
}
