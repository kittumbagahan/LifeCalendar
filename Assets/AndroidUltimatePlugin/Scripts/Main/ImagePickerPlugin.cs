using UnityEngine;
using System.Collections;
using System;

public class ImagePickerPlugin : MonoBehaviour {
	
	private static ImagePickerPlugin instance;
	private static GameObject container;
	private const string TAG="[ImagePickerPlugin]: ";
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	private bool isInit = false;
	
	public static ImagePickerPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="ImagePickerPlugin";
			instance = container.AddComponent( typeof(ImagePickerPlugin) ) as ImagePickerPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.image.ImagePlugin");
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
	/// initialize the Image Picker Plugin
	/// </summary>
	public void Init(){
		if(isInit){
			return;
		}
		
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("init");
			isInit = true;
			Utils.Message(TAG,"init");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	public void SetImagePickerCallbackListener(Action <string>onGetImageComplete,Action onGetImageCancel,Action onGetImageFail){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			ImagePickerCallback imagePickerCallback = new ImagePickerCallback();
			imagePickerCallback.onGetImageComplete = onGetImageComplete;
			imagePickerCallback.onGetImageCancel = onGetImageCancel;
			imagePickerCallback.onGetImageFail = onGetImageFail;
			
			jo.CallStatic("setImagePickerCallbackListener",imagePickerCallback);
			Utils.Message(TAG,"setCameraCallbackListener");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
	
	public void GetImage(){		
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("getImage");
			Utils.Message(TAG,"getImage");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}
}

