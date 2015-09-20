using UnityEngine;
using System.Collections;
using System;

public class DeviceInfoPlugin : MonoBehaviour {
	
	private static DeviceInfoPlugin instance;
	private static GameObject container;
	private const string TAG="[DeviceInfoPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	
	public static DeviceInfoPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="DeviceInfoPlugin";
			instance = container.AddComponent( typeof(DeviceInfoPlugin) ) as DeviceInfoPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.deviceinfo.DeviceInfoPlugin");
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
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}	
	

	public void Init(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("init");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}	

	public void SetDeviceInfoCallbackListener(Action <String>onGetAdvertisingIdComplete,Action <String>onGetAdvertisingIdFail){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			DeviceInfoCallback deviceInfoCallback = new DeviceInfoCallback();
			deviceInfoCallback.onGetAdvertisingIdComplete = onGetAdvertisingIdComplete;
			deviceInfoCallback.onGetAdvertisingIdFail = onGetAdvertisingIdFail;
			jo.CallStatic("setDeviceInfoCallbackListener",deviceInfoCallback);
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}


	public String GetAndroidId(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getAndroidId");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetTelephonyDeviceId(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getTelephonyDeviceId");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetTelephonySimSerialNumber(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getTelephonySimSerialNumber");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public void GetAdvertisingId(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("getAdvertisingId");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public String GenerateUniqueId(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("generateUniqueId");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public bool CheckSim(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<bool>("checkSim");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return false;
	}
}