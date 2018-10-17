using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ListViewController : MonoBehaviour {
	public RectTransform content_;
	public GameObject item_prefab_;
	public string[]   itemList_;

	private float itemHight_;
	private Sprite sprite;

	// Use this for initialization
	void Awake () {
		SafeCreateDirectory( "Assets/Resources" );
		Array.Resize (ref itemList_, GetFileList ("Assets/Resources").Count);

		Debug.Log (GetFileList ("Assets/Resources").Count);

		for(int i=0;i<GetFileList ("Assets/Resources").Count;i++){
			itemList_ [i] = GetFileList ("Assets/Resources") [i];
		}
		UpdateListView ();
	}


	void Update () {

	}

	private void UpdateListView() {
		// Contentの子要素にListViewItemを追加していく.
		foreach (string itemStr in itemList_) {
			GameObject item = GameObject.Instantiate(item_prefab_) as GameObject; // ListViewItem のインスタンス作成.
			Text itemText = item.GetComponentInChildren<Text>(); // Textコンポーネントを取得.
			itemText.text = itemStr;

			RectTransform itemTransform = (RectTransform)item.transform;
			itemTransform.SetParent( content_, false ); // 作成したItemをContentの子要素に設定.
		}
	}


	//ディレクトリリスト取得
	public List<string> GetFileList(string filepath)
	{
		List<string> list = new List<string>();
		/*
		var files = Directory.GetFiles(filepath);
		foreach (var file in files)
		{
			list.Add(file);
		}*/

		var directries = Directory.GetDirectories(filepath);
		foreach (var directry in directries)
		{
			list.Add(directry.Split('\\').Last());
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
		foreach (Transform child in content_.transform) {
			GameObject.Destroy (child.gameObject);
		}
	}
}