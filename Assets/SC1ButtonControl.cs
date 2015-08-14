﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO; // for Directory.XXX

public class SC1ButtonControl : MonoBehaviour {

	private const int kFileId = 0; // change this for each scene
	private bool justStarted = true; // set true after coming back from other scenes

	public InputField dirNameInputField; // should be related to Input Field for entering dirname
	
	private void SelectFunc (bool dirSearch) {
		ScrollScript.SelectFunc (dirNameInputField.text, dirSearch, kFileId);
	}

	public void ButtonFileSelectClick() { SelectFunc(/* dirSearch=*/false); }
	public void ButtonDirSelectClick() { SelectFunc(/* dirSearch=*/true); }

	public void ButtonUpper()
	{
		string now = dirNameInputField.text;
		dirNameInputField.text = Directory.GetParent (now).ToString ();
	}

	void UpdateInputField (string dirname) {
		if (dirNameInputField.text.Length > 0) {
			return; // do not write if already input by user or input by this function
		}
		if (dirname.Length == 0) {
			return;
		}
		dirNameInputField.text = dirname;
	}

	public Text myText; // should be related to TextFileName:Text
	void OnGUI() {
		if (justStarted) {
			justStarted = false;
			myText.text = SelectButtonControl.GetSelectedName (kFileId);
			UpdateInputField (SelectButtonControl.GetSelectedName (kFileId));
		}
	}
}