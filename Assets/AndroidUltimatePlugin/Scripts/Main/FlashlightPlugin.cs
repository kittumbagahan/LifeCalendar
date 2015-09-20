using UnityEngine;
using System.Collections;
using System;

public class FlashlightPlugin : MonoBehaviour {
	
	private static FlashlightPlugin instance;
	private static GameObject container;
	private const string TAG="[FlashlightPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	
	public static FlashlightPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="FlashlightPlugin";
			instance = container.AddComponent( typeof(FlashlightPlugin) ) as FlashlightPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.flashlight.FlashlightPlugin");
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
	/// Sets the flashlight on.
	/// </summary>
	public void SetFlashlightOn(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("setFlashlightOn");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Sets the flashlight off.
	/// </summary>
	public void SetFlashlightOff(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("setFlashlightOff");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Releases the flashlight so that other application can use it.
	/// </summary>
	public void ReleaseFlashlight(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("releaseFlashlight");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
}