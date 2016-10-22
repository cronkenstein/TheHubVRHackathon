using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonOnClick : MonoBehaviour {

	public void OnClick(){

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OpenCanvas);
	}

	void OpenCanvas(){
        GameObject g = new GameObject("Canvas");
        Canvas c = g.AddComponent<Canvas>();
        GameObject panel = new GameObject("Panel");

        panel.transform.SetParent(g.transform, false);
    }
}
