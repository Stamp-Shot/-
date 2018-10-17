using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System;
using UnityEngine;


[Serializable]
public class Item
{
	public string name;
	public float GPS_X;
	public float GPS_Y;
}
  public class SpotInfo : MonoBehaviour {
	
	private double[] SpotNow_;
	private string path = "https://sss-api3.herokuapp.com/cources/1";

	// Use this for initialization
	IEnumerator Start () {

		using(WWW www = new WWW(path)){

			yield return www;

			if(!string.IsNullOrEmpty(www.error)){

				Debug.LogError("www Error:" + www.error);
				yield break;

			}

			Debug.Log(www.text);

			Item item = JsonUtility.FromJson<Item>(www.text);
			Debug.Log("item name " + item.name);
			//var jsonDict = Json.Deserialize(www.text) as Dictionary<string,string>;

			//Debug.Log((string)jsonDict["name"]);

		}


	}
}