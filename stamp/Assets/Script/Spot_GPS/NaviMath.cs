using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class NaviMath
{
	private const double EARTH_RADIUS = 6378.137d; //km

	public static double Deg2Rad { get { return Math.PI / 180.0d; } }

	public static double LatlngDistance(Location a, Location b)
	{
		double dlat1 = a.Latitude * Deg2Rad;
		double dlng1 = a.Longitude * Deg2Rad;
		double dlat2 = b.Latitude * Deg2Rad;
		double dlng2 = b.Longitude * Deg2Rad;

		double d1 = Math.Sin(dlat1) * Math.Sin(dlat2);
		double d2 = Math.Cos(dlat1) * Math.Cos(dlat2) * Math.Cos(dlng2 - dlng1);
		double distance = EARTH_RADIUS * Math.Acos(d1 + d2);
		return distance;
	}

	public static double LatlngDirection(Location from, Location to)
	{
		double dlat1 = to.Latitude * Deg2Rad;
		double dlng1 = to.Longitude * Deg2Rad;
		double dlat2 = from.Latitude * Deg2Rad;
		double dlng2 = from.Longitude * Deg2Rad;

		double x = Math.Cos(dlng1) * Math.Sin(dlng2) - Math.Sin(dlng1) * Math.Cos(dlng2) * Math.Cos(dlat2 - dlat1);
		double y = Math.Cos(dlng2) * Math.Sin(dlat2 - dlat1);
		double dirE0 = 180 * Math.Atan2(y, x) / Math.PI;
		if (dirE0 < 0) dirE0 += 360;

		double dirN0 = (dirE0 - 90) % 360;
		return dirN0;
	}
}