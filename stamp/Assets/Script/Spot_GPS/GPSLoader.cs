﻿using UnityEngine;
using System.Collections;

public class GPSLoader : MonoBehaviour {
	public DrawGoogleMap drawer;

	private float intervalTime = 0.0f;

	IEnumerator Start() {
		return UpdateLocation ();
	}

	void Update(){
		//毎フレーム読んでると処理が重くなるので、3秒毎に更新
		intervalTime += Time.deltaTime;
		if (intervalTime >= 3.0f) {
			StartCoroutine (UpdateLocation());
			intervalTime = 0.0f;
		}
	}

	IEnumerator UpdateLocation(){
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser) {
			yield break;
		}

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1) {
			#if DEBUG
			Debug.Log	("Timed out");
			#endif

			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			#if DEBUG
			Debug.Log("Unable to determine device location");
			#endif

			yield break;

		} else {
			float latitude = Input.location.lastData.latitude;
			float longitude = Input.location.lastData.longitude;

			#if DEBUG
			Debug.Log("Location: " + latitude + " " + longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			#endif

			if (drawer != null) {
				drawer.Geo = new GeoLocation (latitude, longitude);
			}
		}

		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}
}