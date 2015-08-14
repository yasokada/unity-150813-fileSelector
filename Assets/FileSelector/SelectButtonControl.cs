using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectButtonControl : MonoBehaviour {
	private const int kMaxFiles = 5;
	public static string [] selectedname = new string[kMaxFiles];
	public static string callingScene;
	public static int fileId = 0;

	void Start() {
		DontDestroyOnLoad (this); // to access public static variables from other scenes
	}
	
	public static void SetFileId(int id) { fileId = id; }
	public static void SetCallingScene(string sceneName) { callingScene = sceneName; }

	public static string GetSelectedName(int index)
	{
		if (index < 0 || index > kMaxFiles) {
			return "";
		}
		if (selectedname [0] == null) { // if not yet initialized
			return "";
		}
		return selectedname[index];
	}

	private void selectItemName(string buttonText) {
		if (buttonText.Equals("Cancel")) {
			return; // do nothing
		} 
		if (buttonText.Length == 0) {
			return; // do nothing
		}
		selectedname[fileId] = buttonText;
	}

	public void ButtonSelector() {
		GameObject work = GameObject.Find (gameObject.name + "Text"); // e.g. Button1Text
		if (work) {
			string buttonText = work.GetComponent<Text>().text;
			selectItemName(buttonText);
		}
		Application.LoadLevel (callingScene); // back to calling scene
	}
}
