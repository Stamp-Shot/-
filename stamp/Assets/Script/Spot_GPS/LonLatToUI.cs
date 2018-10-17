using UnityEngine;
using UnityEngine.UI;

/// <summary>UI更新クラス</summary>
public class LonLatToUI : MonoBehaviour
{
	/// <summary>テキストテンプレート</summary>
	private const string LonLatInfoTemplate = "緯度: {0}\n経度: {1}";

	/// <summary>表示用テキストUIオブジェクト</summary>
	private Text lonLatInfo;

	/// <summary>経緯度取得オブジェクト</summary>
	private LonLatGetter lonLatGetter;

	/// <summary>初期化</summary>
	private void Start()
	{
		// テキストラベルオブジェクトを保持
		lonLatInfo = GameObject.Find("LonLatInfo").GetComponent<Text>();

		// 経緯度取得オブジェクトオブジェクトを保持
		lonLatGetter = GetComponent<LonLatGetter>();


	}

	/// <summary>経緯度の値をテキストUIに反映</summary>
	private void Update()
	{
		// 経緯度の値を取得できるか判定
		if (lonLatGetter.CanGetLonLat())
		{
			
			lonLatInfo.text = string.Format(LonLatInfoTemplate, lonLatGetter.Latitude.ToString(), lonLatGetter.Longitude.ToString());
		}
		else
		{
			lonLatInfo.text = string.Format(LonLatInfoTemplate, "測定不能", "測定不能", "測定不能");
		}
	}
}
