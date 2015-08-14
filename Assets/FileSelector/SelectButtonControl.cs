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
		for (int idx=0; idx<kMaxFiles; idx++) {
			selectedname[idx] = "";
		}
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
	
	public void ButtonSelector() {
		GameObject work = GameObject.Find (gameObject.name + "Text"); // e.g. Button1Text
		if (work) {
			selectedname[fileId] = work.GetComponent<Text>().text;
		} else { // error
			selectedname[fileId] = "";
		}
		Application.LoadLevel (callingScene); // back to calling scene
	}
}
