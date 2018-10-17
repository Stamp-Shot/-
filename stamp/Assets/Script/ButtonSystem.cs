using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void BackRouteSelect() {
		SceneManager.LoadScene("Route_select");
	}
	public void BackMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}
	public void GoScene() {
		SceneManager.LoadScene("Scene");
	}
	public void GoAlbum() {
		SceneManager.LoadScene("Album");
	}
}
/* 枚数を少なくする
 * 情報の流れをわかりやすく
 * 色の使い分け
 * もじだらけなのをどうにかする
 * 思い出を長く残すという結論に至るような流れを構成する
 * 地域貢献の要素も語るようにする。*/