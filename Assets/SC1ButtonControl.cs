﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SC1ButtonControl : MonoBehaviour {

	private const int kFileId = 0; // change this for each scene
	private const bool kDirSearch = true; // false:file selection, true:dir selection

	public InputField dirNameInputField; // should be related to Input Field for entering dirname

	public void Button1Click() {
		ScrollScript.SetDirSearch (kDirSearch);
		bool res = ScrollScript.ReadFromDir (dirNameInputField.text);
		if (res == false) {
			Debug.Log("dir not found");
			return;
		}

		SelectButtonControl.SetCallingScene (Application.loadedLevelName);
		SelectButtonControl.SetFileId (kFileId);
		Application.LoadLevel ("FileSelector");
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
		myText.text = SelectButtonControl.GetSelectedName (kFileId);
		if (kDirSearch) {
			UpdateInputField(SelectButtonControl.GetSelectedName (kFileId));
		}
	}
}