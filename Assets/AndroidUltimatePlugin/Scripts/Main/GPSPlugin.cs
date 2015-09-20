using UnityEngine;
using System.Collections;
using System;

public class GPSPlugin : MonoBehaviour {
	
	private static GPSPlugin instance;
	private static GameObject container;
	private const string TAG="[GPSPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	private bool isInit = false;

	public static GPSPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="GPSPlugin";
			instance = container.AddComponent( typeof(GPSPlugin) ) as GPSPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.gps.GPSPlugin");
		}
		#endif
	}

	/// <summary>
	/// Sets the debug.
	/// 0 - false, 1 - true
	/// </summary>
	/// <param name="debug">Debug.</param>
	public void SetDebug(int debug){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("SetDebug",debug);
			Utils.Message(TAG,"SetDebug");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Initialize the GPS.
	/// </summary>
	/// <param name="updateInterval">Update interval.</param>
	/// <param name="minimumMeterChangeForUpdate">Minimum meter change for update.</param>
	public void Init(long updateInterval,long minimumMeterChangeForUpdate){
		if(isInit){
			return;
		}

		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			object[] array = new object[2];
			array[0] = updateInterval;
			array[1] = minimumMeterChangeForUpdate;
			
			//jo.CallStatic("initGPS",new object[] { updateInterval, minimumMeterChangeForUpdate });
			isInit = true;
			jo.CallStatic("initGPS",array);
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public void SetLocationChangeListener(Action<double,double> onLocationChange
	                                      ,Action<string>onEnableGPS
	                                      ,Action<double,double>onGetLocationComplete
	                                      ,Action onGetLocationFail
	                                      ){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			GPSCallback gpsCallback = new GPSCallback();
			gpsCallback.onEnableGPS = onEnableGPS;
			gpsCallback.onLocationChange = onLocationChange;
			gpsCallback.onGetLocationComplete = onGetLocationComplete;
			gpsCallback.onGetLocationFail = onGetLocationFail;
			jo.CallStatic("setLocationChangeListener",gpsCallback);
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Checks the GPS if enable
	/// </summary>
	/// <returns><c>true</c>, if GPS was Enabled, <c>false</c> otherwise.</returns>
	public bool CheckGPS(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<bool>("checkGPS");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return false;
	}
	
	/// <summary>
	/// Shows the GPS alert to ask user to enable GPS
	/// </summary>
	public void ShowGPSAlert(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showGPSAlert");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Stops the GPS Events	 
	/// </summary>
	public void StopGPS(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("stopGPS");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Gets both Latitude and longitude.
	/// </summary>
	/// <returns>The location.</returns>
	public String GetLocation(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getLocation");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif

		return "";
	}

	/// <summary>
	/// Gets the location with callback.
	/// </summary>
	public void GetLocationWithCallback(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("getLocationWithCallback");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Gets the latitude.
	/// </summary>
	/// <returns>The latitude.</returns>
	public double GetLatitude(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<double>("getLatitude");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif

		return 0.0;
	}
	
	/// <summary>
	/// Gets the longitude.
	/// </summary>
	/// <returns>The longitude.</returns>
	public double GetLongitude(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<double>("getLongitude");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return 0.0;
	}
}
