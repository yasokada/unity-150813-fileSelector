using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button1Control : MonoBehaviour {
	
	public void Button1Click() {
		SelectButtonControl.callingScene = "Scene1";
		Application.LoadLevel ("FileSelector");
	}
	
	public Text myText; // should be related to TextFileName:Text
	void OnGUI() {
		myText.text = SelectButtonControl.filename;
	}
}