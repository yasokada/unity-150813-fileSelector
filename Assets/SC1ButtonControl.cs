using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SC1ButtonControl : MonoBehaviour {

	private const int kFileId = 0; // change this for each scene

	public void Button1Click() {
		ScrollScript.ReadFromDir (".");
		SelectButtonControl.SetCallingScene (Application.loadedLevelName);
		SelectButtonControl.SetFileId (kFileId);
		Application.LoadLevel ("FileSelector");
	}
	
	public Text myText; // should be related to TextFileName:Text
	void OnGUI() {
		myText.text = SelectButtonControl.GetFilename (kFileId);
	}
}