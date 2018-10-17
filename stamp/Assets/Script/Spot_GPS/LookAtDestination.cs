using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class LookAtDestination : MonoBehaviour
	{

		Location shibuya = new Location(35.658126d, 139.701616d);

		public UnityEngine.UI.Text text;

		void Start()
		{
			Input.location.Start();
		}

		void Update()
		{
			//端末の緯度経度
			LocationInfo locationInfo = Input.location.lastData;
			Location deviceLocation = new Location(locationInfo.latitude, locationInfo.longitude);

			//距離(メートル)
			int distance = (int)NaviMath.LatlngDistance(deviceLocation, shibuya) * 1000;

			//向き
			Vector3 angle = Vector3.up * -Input.compass.trueHeading;
			double direction = NaviMath.LatlngDirection(deviceLocation, shibuya);
			angle.y += (float)direction;

			//更新
			text.text = string.Format("渋谷駅まで{0}mだよ", distance);
			transform.localEulerAngles = angle;
		}
}
