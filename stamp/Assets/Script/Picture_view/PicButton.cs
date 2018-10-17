using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicButton : MonoBehaviour {
	public GameObject viewPort;
	//public GameObject content;
	private bool PullDown=false;

	public void OnClick() {
		if (PullDown == false) {
			viewPort.GetComponent<RectTransform> ().sizeDelta = new Vector2 (600, 300);
			PullDown = true;
		}else if (PullDown == true) {
			viewPort.GetComponent<RectTransform> ().sizeDelta = new Vector2 (600, 100);
			PullDown = false;
		}
	}
}
