﻿using UnityEngine;
using System.Collections;
using System;

public class GPSCallback :  AndroidJavaProxy {
	
	public Action <double,double>onLocationChange;
	public Action <string>onEnableGPS;
	public Action <double,double>onGetLocationComplete;
	public Action onGetLocationFail;
	
	public GPSCallback() : base("com.gigadrillgames.androidplugin.gps.IGPS") {}
	
	void LocationChange(double latitude,double longitude){
		onLocationChange(latitude,longitude);
	}

	void EnableGPS(string status){
		onEnableGPS(status);
	}

	void GetLocationComplete(double latitude,double longitude){
		onGetLocationComplete(latitude,longitude);
	}

	void GetLocationFail(){

	}
}
