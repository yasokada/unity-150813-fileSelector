using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button1Control : MonoBehaviour {

	private const int kFileId = 0; // change this for each scene

	public void Button1Click() {
		SelectButtonControl.SetCallingScene (Application.loadedLevelName);
		SelectButtonControl.SetFileId (kFileId);
		Application.LoadLevel ("FileSelector");
	}
	
	public Text myText; // should be related to TextFileName:Text
	void OnGUI() {
		myText.text = SelectButtonControl.GetFilename (kFileId);
	}
}