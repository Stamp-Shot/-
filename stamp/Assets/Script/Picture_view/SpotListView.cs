using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SpotListView : MonoBehaviour {
	public RectTransform content2_;
	public GameObject item_prefab2_;
	public string[]   itemList2_;

	private float itemHight_;
	private Sprite sprite;


	void Awake () {
		SafeCreateDirectory( "Assets/spot_cache" );
		Array.Resize (ref itemList2_, GetFileList ("Assets/spot_cache").Count);

		Debug.Log (GetFileList ("Assets/spot_cache").Count);

		for(int i=0;i<GetFileList ("Assets/spot_cache").Count;i++){
			itemList2_ [i] = GetFileList ("Assets/spot_cache") [i];
		}
		UpdateListView ();
	}


	void Update () {

	}

	private void UpdateListView() {
		// Contentの子要素にListViewItemを追加していく.
		foreach (string itemStr in itemList2_) {
			GameObject item = GameObject.Instantiate(item_prefab2_) as GameObject; // ListViewItem のインスタンス作成.
			Text itemText = item.GetComponentInChildren<Text>(); // Textコンポーネントを取得.
			itemText.text = itemStr;

			RectTransform itemTransform = (RectTransform)item.transform;
			itemTransform.SetParent( content2_, false ); // 作成したItemをContentの子要素に設定.
		}
	}


	//ファイルリスト取得
	public List<string> GetFileList(string filepath)
	{
		List<string> list = new List<string>();

		var files = Directory.GetFiles(filepath);
		foreach (var file in files)
		{
			list.Add(file.Split('\\').Last());
		}

		return list;
	}

	//写真保存するディレクトリがないときは作成する。
	public static DirectoryInfo SafeCreateDirectory( string path )
	{
		if ( Directory.Exists( path ) )
		{
			return null;
		}
		return Directory.CreateDirectory( path );
	}


	private void RemoveAllListViewItem(){
		foreach (Transform child in content2_.transform) {
			GameObject.Destroy (child.gameObject);
		}
	}
}