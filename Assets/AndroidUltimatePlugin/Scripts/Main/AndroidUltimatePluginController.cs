using UnityEngine;
using System.Collections;
using System;

public class AndroidUltimatePluginController : MonoBehaviour {
	
	private static AndroidUltimatePluginController instance;
	private static GameObject container;
	
	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	
	public static AndroidUltimatePluginController GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="AndroidUltimatePluginController";
			instance = container.AddComponent( typeof(AndroidUltimatePluginController) ) as AndroidUltimatePluginController;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.main.AndroidUltimatePlugin");
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
			Message("warning: must run in actual android device");
		}
		#endif
	}

		


	//----------------------------------------------[Google Indexing]-----------------------------------------------------
	/// <summary>
	/// Initialize the google indexing.
	/// Note: calls this on start once
	/// </summary>
	/// <param name="appName">App name.</param>
	/// <param name="appUrlLink">appUrlLink should follow this format android-app://{package_name}/{scheme}/{host_path} </param>
	/// <param name="appWebUrl">App web URL.</param>
	public void InitGoogleIndexing(string appName,string appUrlLink, string appWebUrl){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("initGoogleIndexing",appName,appUrlLink,appWebUrl);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Starts the google indexing.
	/// Note: call this on start once
	/// </summary>
	public void StartGoogleIndexing(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("startGoogleIndexing");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}


	/// <summary>
	/// Stops the google indexing.
	/// call this on destoy
	/// </summary>
	public void StopGoogleIndexing(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("stopGoogleIndexing");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	//----------------------------------------------[Google Indexing]-----------------------------------------------------


	//----------------------------------------------[Share Intent]-----------------------------------------------------
	//share intent
	/// <summary>
	/// Shares the image.
	/// </summary>
	/// <param name="subject">Subject.</param>
	/// <param name="subjectContent">Subject content.</param>
	/// <param name="imagepath">Imagepath.</param>
	public void ShareImage(string subject,string subjectContent, string imagepath){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("shareImage",subject,subjectContent,imagepath);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Shares the URL.
	/// </summary>
	/// <param name="subject">Subject.</param>
	/// <param name="subjectContent">Subject content.</param>
	/// <param name="url">URL.</param>
	public void ShareUrl(string subject,string subjectContent, string url){		
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("shareUrl",subject,subjectContent,url);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	//----------------------------------------------[Share Intent]-----------------------------------------------------

	//----------------------------------------------[Local Notification]-----------------------------------------------------

	//note: local notification will not show if the application is currently running

	/// <summary>
	/// Schedules the notification.
	/// </summary>
	/// <param name="notificationTitle">Notification title.</param>
	/// <param name="notificationMessage">Notification message.</param>
	/// <param name="notificationTickerMessage">Notification ticker message.</param>
	/// <param name="delay">Delay.</param>
	/// <param name="enableVibrate">If set to <c>true</c> enable vibrate.</param>
	/// <param name="enableSound">If set to <c>true</c> enable sound.</param>
	public void ScheduleNotification(string notificationTitle,string notificationMessage,string notificationTickerMessage, int delay,bool enableVibrate,bool enableSound ){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("scheduleNotification",notificationTitle,notificationMessage,notificationTickerMessage,delay,enableVibrate,enableSound);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	
	public void ShowScheduleSimpleNotification(string notificationTitle,string notificationMessage,string notificationTickerMessage,bool enableVibrate,bool enableSound){		
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showSimpleNotification",notificationTitle,notificationMessage,notificationTickerMessage,enableVibrate,enableSound);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	
	/// <summary>
	/// Determines whether this instance is open using notification.
	/// </summary>
	/// <returns><c>true</c> if this instance is open using notification; otherwise, <c>false</c>.</returns>
	public int IsOpenUsingNotification(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<int>("isOpenUsingNotification");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif

		return 0;
	}

	//----------------------------------------------[Local Notification]-----------------------------------------------------


	//----------------------------------------------[Immersive]-------------------------------------------------------------
	//immersive
	//only support kitkat and above version
	/// <summary>
	/// set immersive mode on
	/// , note:only support kitkat and above android version 4.4 api 19
	/// </summary>
	/// <param name="delay">Delay.</param>
	public void ImmersiveOn(int delay){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("immersiveOn",delay);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Immersives the off.
	/// </summary>
	public void ImmersiveOff(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("immersiveOff");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	//----------------------------------------------[Immersive]-------------------------------------------------------------


	//----------------------------------------------[Android Native UI]-------------------------------------------------------------
	/// <summary>
	/// Shows the toast message.
	/// </summary>
	/// <param name="message">Message.</param>
	public void ShowToastMessage(String message){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showToastMessage",message);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}


	//native popup
	//rate us
	/// <summary>
	/// Shows the  native rate popup.
	/// </summary>
	/// <param name="title">Title.</param>
	/// <param name="message">Message.</param>
	/// <param name="url">URL.</param>
	public void ShowRatePopup(String title,String message,String url){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showRatePopup",title,message,url);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Shows the native alert popup.
	/// </summary>
	/// <param name="title">Title.</param>
	/// <param name="message">Message.</param>
	public void ShowAlertPopup(String title,String message){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showNativePopup",title,message);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	//native popup

	//native loading
	/// <summary>
	/// Shows the native loading.
	/// </summary>
	/// <param name="message">Message.</param>
	/// <param name="isCancelable">If set to <c>true</c> is cancelable.</param>
	public void ShowNativeLoading(String message,bool isCancelable){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("showNativeLoading",message,isCancelable);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Hides the native loading.
	/// </summary>
	public void HideNativeLoading(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("hideNativeLoading");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	//----------------------------------------------[Android Native UI]-------------------------------------------------------------


	//----------------------------------------------[Android Information]-------------------------------------------------------------
	/// <summary>
	/// Gets the package identifier.
	/// </summary>
	/// <returns>The package identifier.</returns>
	public String GetPackageId(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getPackageId");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	/// <summary>
	/// Gets the android version.
	/// </summary>
	/// <returns>The android version.</returns>
	public String GetAndroidVersion(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getAndroidVersion");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return "";
	}
	//----------------------------------------------[Android Information]-------------------------------------------------------------


	//----------------------------------------------[Internet Connectivity]-------------------------------------------------------------
	/// <summary>
	/// Checks if connected to the internet.
	/// </summary>
	/// <returns><c>true</c>, if internet was checked, <c>false</c> otherwise.</returns>
	public bool CheckInternet(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<bool>("checkInternet");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return false;
	}
	//----------------------------------------------[Internet Connectivity]-------------------------------------------------------------


	//----------------------------------------------[Time]-------------------------------------------------------------
	/// <summary>
	/// Gets the time.
	/// </summary>
	/// <returns>The time.</returns>
	public String GetTime(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getTime");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetHour(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getHour");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetMinute(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getMinute");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetSecond(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<String>("getSecond");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return "";
	}
	//----------------------------------------------[Time]-------------------------------------------------------------


	//----------------------------------------------[Power]-------------------------------------------------------------
	public void setBatteryLifeChangeListener(Action<float> onBatteryChange){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			BatteryCallback batteryCallback = new BatteryCallback();
			batteryCallback.onBatteryLifeChange = onBatteryChange;
			jo.CallStatic("setBatteryLifeChangeListener",batteryCallback);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Gets the battery life.
	/// </summary>
	/// <returns>The battery life.</returns>
	public float GetBatteryLife(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			return jo.CallStatic<float>("getBatteryLife");
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
		
		return 0.0f;
	}
	//----------------------------------------------[Power]-------------------------------------------------------------


	public void ShowMessage(string message){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.Call("ShowMessage", message);
		}else{
			Message("warning: must run in actual android device");
		}
		#endif
	}
	
	private void Message(string message){
		if(isDebug){
			Debug.LogWarning(message);
		}
	}
}
