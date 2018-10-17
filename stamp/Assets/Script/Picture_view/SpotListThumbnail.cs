using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SpotListThumbnail : MonoBehaviour {

	private Text targetText;
	private Image thumbnail;
	private Texture2D texture;

	// Use this for initialization
	void Start () {
		targetText = transform.parent.Find ("Text").GetComponent<Text> ();//同階層テキストコンボネート取得
		//texture = Resources.Load (targetText.text + "/0") as Texture2D;//写真のロード
		thumbnail = this.GetComponent<Image> ();
		thumbnail.sprite = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),Vector2.zero);

	}

}
