﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI; // for Text
using System.IO; // for Directory()

// Button1
// - Button1Text
// Button2
// - Button2Text
// Button3
// - Button3Text
// Button4
// - Button4Text
// ScrollbarFile
// EventSystem

public class ScrollScript : MonoBehaviour {
	public Text dirNameText;
	public static bool dirSearch = false; // true:dir selection, false: file selection
	private static string s_DirName;
	private static string[ ] s_files;
	
	void Start() {
		updateFileListOnButtons ();
	}

	public static void SetDirSearch(bool bf)
	{
		dirSearch = bf;
	}
	public static bool ReadFromDir(string dirname) {
		if (Directory.Exists (dirname) == false) {
			return false;
		}
		s_DirName = dirname;

		if (dirSearch == false) {
			s_files = Directory.GetFiles (dirname);
		} else {
			s_files = Directory.GetDirectories(dirname);
		}

		if (s_files.Length == 0) {
			return false;
		}
		return true;
	}

	public static void SelectFunc(string baseDir, bool dirSearch, int fileid)
	{
		ScrollScript.SetDirSearch (dirSearch);
		bool res = ScrollScript.ReadFromDir (baseDir);
		if (res == false) {
			Debug.Log("dir not found");
			return;
		}
		
		SelectButtonControl.SetCallingScene (Application.loadedLevelName);
		SelectButtonControl.SetFileId (fileid);
		Application.LoadLevel ("FileSelector");
	}

	public static void UpdateInputField (InputField inputField, int fileId) {
		if (inputField.text.Length > 0) {
			return; // do not write if already input by user or input by this function
		}
		string dirname = SelectButtonControl.GetSelectedName (fileId);
		if (dirname.Length == 0) {
			return;
		}
		inputField.text = dirname;
	}

	private void dispFilesOnButtons(string filename, int idx, int shift) {
		int pos = idx - shift;
		GameObject work = GameObject.Find ("Button" + pos.ToString () + "Text");
		if (work) {
			work.GetComponent<Text>().text = filename;
		}
	}

	private void changeScrollBarValue(string scrollBarName, bool isUp) {
		GameObject work = GameObject.Find (scrollBarName);
		if (work) {
			float aRatio = (float)work.GetComponent<Scrollbar>().value;
			if (isUp) {
				aRatio -= 0.05f; // for from top to bottom direction
			} else {
				aRatio += 0.05f; // for from top to bottom direction
			}
			work.GetComponent<Scrollbar>().value = aRatio;
		}
	}

	private int getShiftValue(string scrollBarName, int maxFileNum) {
		GameObject work = GameObject.Find (scrollBarName);
		if (work) {
			float aRatio = (float)work.GetComponent<Scrollbar>().value;
			return (int)(maxFileNum * aRatio);
		}
		return 0;
	}
	
	private void clearButtonsText()
	{
		foreach (Text aText in Text.FindObjectsOfType<Text> ()) {
			if (aText.name.Contains("Button")) { // e.g. Button2Text
				if (aText.name.Contains("Cancel") == false) {
					aText.text = "";
				}
			}
		}
	}
	
	private void updateFileListOnButtons()
	{
		int shift = getShiftValue ("ScrollbarFile", s_files.Length);
		
		clearButtonsText ();
		int count = 1;
		foreach (string aFile in s_files) {
			dispFilesOnButtons(aFile, count, shift);
			count++;
			Debug.Log(aFile);
		}
	}

	public void ScrollBarChange() {
		updateFileListOnButtons ();
	}   

	void OnGUI() {
		dirNameText.text = s_DirName;

		float val = Input.GetAxis ("Mouse ScrollWheel");
		if (val > 0.0f) {
			changeScrollBarValue("ScrollbarFile", /* isUp=*/true);
			Debug.Log ("up");
		} else if (val < 0.0f) {
			changeScrollBarValue("ScrollbarFile", /* isUp=*/false);
			Debug.Log ("down");
		} else {
			// do nothing
		}
	}

}