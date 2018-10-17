using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	Location shibuya = new Location(35.658126d, 139.701616d);
	Location hakata = new Location(33.590322d, 130.420675d);

	void Start()
	{
		Debug.Log("渋谷駅と博多駅の距離は" + NaviMath.LatlngDistance(shibuya, hakata) + "kmだよ");
	}
}