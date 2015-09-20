﻿using UnityEngine;
using System.Collections;
using System;

public class VibratorPlugin : MonoBehaviour {
	
	private static VibratorPlugin instance;
	private static GameObject container;
	private const string TAG="[VibratorPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	
	public static VibratorPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="VibratorPlugin";
			instance = container.AddComponent( typeof(VibratorPlugin) ) as VibratorPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.vibrator.VibratorPlugin");
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
	/// Initialize this vibrator service.
	/// </summary>
	public void Init(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("init");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Vibrate with specified duration.
	/// </summary>
	/// <param name="duration">Duration.</param>
	public void Vibrate(long duration){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("vibrate",duration);
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Vibrate with specified pattern.
	/// </summary>
	/// <param name="pattern">Pattern.</param>
	public void Vibrate(long[] pattern){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("vibrate",pattern);
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	public void StopVibrate(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("stopVibrate");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
}