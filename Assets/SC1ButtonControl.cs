using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO; // for Directory.XXX

public class SC1ButtonControl : MonoBehaviour {
	[Range(0, 5)]
	public int fileId; // set this in inspector

	public InputField dirNameInputField; // should be related to Input Field for entering dirname
	
	private void SelectFunc (bool dirSearch) {
		ScrollScript.SelectFunc (dirNameInputField.text, dirSearch, fileId);
	}

	public void ButtonFileSelectClick() { SelectFunc(/* dirSearch=*/false); }
	public void ButtonDirSelectClick() { SelectFunc(/* dirSearch=*/true); }

	public void ButtonUpper()
	{
		string now = dirNameInputField.text;
		dirNameInputField.text = Directory.GetParent (now).ToString ();
	}

	public Text myText; // should be related to TextFileName:Text

	void Start() {
		myText.text = SelectButtonControl.GetSelectedName (fileId);
		ScrollScript.UpdateInputField(dirNameInputField, fileId);
	}
}