using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Common;

public class SelectButtonControl : MonoBehaviour {
	public void ButtonSelector() {
		GameObject work = GameObject.Find (gameObject.name + "Text"); // e.g. Button1Text
		if (work) {
			Button1Control.filename = work.GetComponent<Text>().text;
		} else {
			Button1Control.filename = gameObject.name;
		}
//		Application.LoadLevel ("Scene1");
		Application.LoadLevel (Define.callingScene);
	}
}
