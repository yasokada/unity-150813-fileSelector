using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button1Control : MonoBehaviour {
	
	public static string filename; // used from Scene2
	
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	public void Button1Click() {
		Application.LoadLevel ("FileSelector");
	}
	
	public Text myText; // should be related to TextFileName:Text
	void OnGUI() {
		myText.text = filename;
	}
}