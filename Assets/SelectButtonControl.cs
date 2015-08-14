using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectButtonControl : MonoBehaviour {
	private const int kMaxFiles = 5;
	public static string callingScene;
	public static int fileId = 0;
	public static string [] filename = new string[kMaxFiles];

	void Start() {
		DontDestroyOnLoad (this); // to access public static variables from other scenes
	}
	
	public static void SetFileId(int id) { fileId = id; }
	public static void SetCallingScene(string sceneName) { callingScene = sceneName; }

	public static string GetFilename(int index)
	{
		if (index < 0 || index > kMaxFiles) {
			return "";
		}
		return filename[index];
	}
	
	public void ButtonSelector() {
		GameObject work = GameObject.Find (gameObject.name + "Text"); // e.g. Button1Text
		if (work) {
			filename[fileId] = work.GetComponent<Text>().text;
		} else { // error
			filename[fileId] = "";
		}
		Application.LoadLevel (callingScene); // back to calling scene
	}
}
