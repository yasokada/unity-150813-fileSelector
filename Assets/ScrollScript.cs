using UnityEngine;
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
	
	private string [ ] s_files = Directory.GetFiles("."); 
	
	private void dispFilesOnButtons(string filename, int idx, int shift) {
		int pos = idx - shift;
		GameObject work = GameObject.Find ("Button" + pos.ToString () + "Text");
		if (work) {
			work.GetComponent<Text>().text = filename;
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
				aText.text = "";
			}
		}
	}
	
	private void updateFileList()
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
	
	void Start() {
		updateFileList ();
	}
	
	public void ScrollBarChange() {
		updateFileList ();
	}   
}