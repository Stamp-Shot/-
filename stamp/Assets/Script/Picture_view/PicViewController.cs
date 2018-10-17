using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PicViewController : MonoBehaviour {

	public RectTransform piccontent_;
	public GameObject picture;
	private Texture2D[]   picList_;

	private Text targetText;
	private Image thumbnail;
	private Texture2D texture;

	void Start () {
		targetText = transform.parent.Find ("Text").GetComponent<Text> ();//同階層テキストコンボネート取得
		texture = Resources.Load (targetText.text + "/0") as Texture2D;//写真のロード
		thumbnail = this.GetComponent<Image> ();
		thumbnail.sprite = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),Vector2.zero);

		GetPicList ();
		UpdatePicView ();
	}

	private void UpdatePicView() {
		// Contentの子要素にPicViewItemを追加していく.
		foreach (Texture2D picStr in picList_) {
			GameObject pic = GameObject.Instantiate(picture) as GameObject;
			Image image = pic.GetComponent<Image> ();//ImageのComponent取得

			RectTransform itemTransform = (RectTransform)pic.transform;
			image.sprite = Sprite.Create (picStr,new Rect(0,0,picStr.width,picStr.height),Vector2.zero);
			itemTransform.SetParent( piccontent_, false ); // 作成したItemをContentの子要素に設定.
		}
	}

	private void GetPicList(){
		picList_ = Resources.LoadAll<Texture2D> (targetText.text + "/");
	}

	void Update () {
		
	}
}