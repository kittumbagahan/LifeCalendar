﻿using UnityEngine;
using System.Collections;
using System;

public class BlueToothPlugin : MonoBehaviour {
	
	private static BlueToothPlugin instance;
	private static GameObject container;
	private const string TAG="[BlueToothController]: ";

	#if UNITY_ANDROID
	private static AndroidJavaObject jo;
	#endif	
	
	public bool isDebug =true;
	private bool isInit = false;

	/*private Action <string>RecievedData;
	public event Action <string>OnRecievedData{
		add{RecievedData+=value;}
		remove{RecievedData-=value;}
	}

	private Action <string>SentData;
	public event Action <string>OnSentData{
		add{SentData+=value;}
		remove{SentData-=value;}
	}

	private Action <string>LogMessage;
	public event Action <string>OnLogMessage{
		add{LogMessage+=value;}
		remove{LogMessage-=value;}
	}*/
	
	public static BlueToothPlugin GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="BlueToothPlugin";
			instance = container.AddComponent( typeof(BlueToothPlugin) ) as BlueToothPlugin;
			DontDestroyOnLoad(instance.gameObject);
		}
		
		return instance;
	}
	
	private void Awake(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.bluetooth.BlueToothPlugin");
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
	/// initialize the bluetooth plugin
	/// </summary>
	public void Init(){
		if(isInit){
			return;
		}

		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("initBlueTooth");
			isInit = true;
			Utils.Message(TAG,"initBlueTooth");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public void SetDataCallbackListener(Action <string>onRecieved,Action <string>onSentData,Action <string>onLogMessage){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			BluetoothDataCallback bluetoothDataCallback = new BluetoothDataCallback();
			bluetoothDataCallback.onRecieved = onRecieved;
			bluetoothDataCallback.onDataSent = onSentData;
			bluetoothDataCallback.onLogMessage = onLogMessage;
			
			jo.CallStatic("setDataCallbackListener",bluetoothDataCallback);
			Utils.Message(TAG,"setDataCallbackListener");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public void SetConnectionCallbackListener( 
	            Action <string>OnConnected
	            ,Action <string>OnConnecting
	            ,Action <string>OnNotConnected
	            ,Action <string>OnConnectionFailed
	            ,Action <string>OnConnectionLost
	            ,Action <string>OnConnectToDevice
	     ){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			BluetoothConnectionCallback bluetoothConnectionCallback = new BluetoothConnectionCallback();
			bluetoothConnectionCallback.onConnected = OnConnected;
			bluetoothConnectionCallback.onConnecting = OnConnecting;
			bluetoothConnectionCallback.onNotConnected = OnNotConnected;
			bluetoothConnectionCallback.onConnectionFailed = OnConnectionFailed;
			bluetoothConnectionCallback.onConnectionLost = OnConnectionLost;
			bluetoothConnectionCallback.onConnectToDevice = OnConnectToDevice;
			
			jo.CallStatic("setConnectionCallbackListener",bluetoothConnectionCallback);
			Utils.Message(TAG,"setDataCallbackListener");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// makes sure that your phone will be seen when other user scan the blue tooth connection
	/// </summary>
	public void EnsureDiscoverable(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("ensureDiscoverable");
			Utils.Message(TAG,"EnsureDiscoverable");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}	

	/// <summary>
	/// Checks if the blue tooth is enable or disable
	/// </summary>
	/// <returns><c>true</c>, if blue tooth was checked, <c>false</c> otherwise.</returns>
	public bool CheckBlueTooth(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			Utils.Message(TAG,"CheckBlueTooth");
			return jo.CallStatic<bool>("checkBlueTooth");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return false;
	}

	/// <summary>
	/// ask user to enable bluetooth on settings
	/// </summary>
	public void NotifyUserToEnableBlueTooth(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("notifyUserToEnableBlueTooth");
			Utils.Message(TAG,"NotifyUserToEnableBlueTooth");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Starts the server
	/// </summary>
	public void InitServer(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("initServer");
			Utils.Message(TAG,"InitServer");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}


	/// <summary>
	/// Gets the paired devices
	/// this is where you will get the device names and mac address
	/// that is require when connecting to other device
	/// </summary>
	/// <returns>The paired devices.</returns>
	public String GetPairedDevices(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			Utils.Message(TAG,"getPairedDevices");
			return jo.CallStatic<String>("getPairedDevices");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	/// <summary>
	/// Connect the device to specified macAddress
	/// isSecure tells if you want a secure connection or not
	/// </summary>
	/// <param name="macAddress">Mac address.</param>
	/// <param name="isSecure">If set to <c>true</c> is secure.</param>
	public void Connect(String macAddress,bool isSecure){
		if(macAddress.Equals("",StringComparison.Ordinal)){
			Utils.Message(TAG,"can't connect empty mac address");
			return;
		}

		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("connectDevice",macAddress,isSecure);
			Utils.Message(TAG,"ConnectDevice");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public void DisConnect(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("disConnect");
			Utils.Message(TAG,"disConnect");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// where you send the message to the other device
	/// </summary>
	/// <param name="message">Message.</param>
	public void SendData(String message){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("sendMessage",message);
			Utils.Message(TAG,"SendMessage");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	/// <summary>
	/// Stops the server.
	/// </summary>
	public void StopServer(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			jo.CallStatic("stopServer");
			Utils.Message(TAG,"StopServer");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
	}

	public String GetDeviceName(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			Utils.Message(TAG,"getDeviceName");
			return jo.CallStatic<String>("getDeviceName");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}

	public String GetDeviceAddress(){
		#if UNITY_ANDROID
		if(Application.platform == RuntimePlatform.Android){
			Utils.Message(TAG,"getDeviceAddress");
			return jo.CallStatic<String>("getDeviceAddress");
		}else{
			Utils.Message(TAG,"warning: must run in actual android device");
		}
		#endif
		
		return "";
	}
}
