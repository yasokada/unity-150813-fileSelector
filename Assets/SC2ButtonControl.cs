using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SC2ButtonControl : MonoBehaviour {

	public void SC2ButtonClick()
	{
		SelectButtonControl.callingScene = "Scene2";
		Application.LoadLevel ("FileSelector");
	}

	public Text myText; // should be related to Text in the scene
	void OnGUI() {
		myText.text = SelectButtonControl.filename;
	}
}
