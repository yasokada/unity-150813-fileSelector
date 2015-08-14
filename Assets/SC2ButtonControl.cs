﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SC2ButtonControl : MonoBehaviour {

	private const int kFileId = 1; // change this for each scene
	
	public void SC2ButtonClick() {
		SelectButtonControl.SetCallingScene (Application.loadedLevelName);
		SelectButtonControl.SetFileId (kFileId);
		Application.LoadLevel ("FileSelector");
	}
	
	public Text myText; // should be related to TextFileName:Text
	void OnGUI() {
		myText.text = SelectButtonControl.GetFilename (kFileId);
	}
}