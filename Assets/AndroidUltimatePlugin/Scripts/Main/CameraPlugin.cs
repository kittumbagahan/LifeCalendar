using UnityEngine;
using System.Collections;
using System;

public class CameraPlugin : MonoBehaviour {
	
	private static CameraPlugin instance;
	private static GameObject container;
	private const string TAG="[CameraPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	private bool isInit = false;
	
	public static CameraPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="CameraPlugin";
			instance = container.AddComponent( typeof(CameraPlugin) ) as CameraPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.camera.CameraPlugin");
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
	/// initialize the camera plugin
	/// </summary>
	public void Init(string folderName){
		if(isInit){
			return;
		}
		
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("init",folderName);
			isInit = true;
			Utils.Message(TAG,"init");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	public void SetCameraCallbackListener(Action <string>onCaptureImageComplete,Action onCaptureImageCancel,Action onCaptureImageFail){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			CameraCallback cameraCallback = new CameraCallback();
			cameraCallback.onCaptureImageComplete = onCaptureImageComplete;
			cameraCallback.onCaptureImageCancel = onCaptureImageCancel;
			cameraCallback.onCaptureImageFail = onCaptureImageFail;
			
			jo.CallStatic("setCameraCallbackListener",cameraCallback);
			Utils.Message(TAG,"setCameraCallbackListener");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public void OpenCamera(){		
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("openCamera");
			Utils.Message(TAG,"openCamera");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
}
