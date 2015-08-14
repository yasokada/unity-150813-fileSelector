using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectButtonControl : MonoBehaviour {
	public static string callingScene;
	public static string filename;

	void Start() {
		DontDestroyOnLoad (this); // to access public static variables from other scenes
	}

	public void ButtonSelector() {
		GameObject work = GameObject.Find (gameObject.name + "Text"); // e.g. Button1Text
		if (work) {
			filename = work.GetComponent<Text>().text;
		} else { // error
			filename = "";
		}
		Application.LoadLevel (callingScene); // back to calling scene
	}
}
