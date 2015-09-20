Thank you for Purchasing Android Ultimate Plugin!

Here's something you need to know before you get started, this instructions are seems a lot but if you are in hurry just export the plugin in your project and follow the sample code in each demo inside the Android Ultimate plugin folder just dont forget to put permissions on your Android manifest and you are good to go. you can always come back here and read this guides if you are having
some trouble.

Requirements:

this plugin needs the following inside the Assets/Plugins/Android folder
good thing is this requirements is already in the plugin

1. google-play-services_lib - came from android sdk
2. android-support-v4
3. android-support-v7-appcompat
4. res folder - this folder includes folders for localnotification icons and sound
5. UltimateAndroidPlugin - the actual java lib of android ultimate plugin
6. AndroidManifest - including permissions,recievers and others explain below.


Disclaimer

this required libraries are not mine you can get them on the internet or inside android sdk except Android Ultimate Plugin jar which I made.
Also UGUI that you will find at Extension Folder is not mine i just used it as helper when editing ui



How to test:

1. Look for SampleAndroidManifest folder, inside that there's an Android Manifest if you don't have a Android manifest file just copy it and paste it inside Assets/Plugins/Android

2. change android bundle identifier to your own package example: com.gigadrillgames.androidultimateplugin

3. Browse Assets/AndroidUltimatePlugin/scenes inside this folder you will see a demo scene, try to load it and compile on android device to see the android ultimate plugin in action.

4. in this demo scene you will noticed many canvas each canvas demonstrate on how to used specific task  or features.

5. inside Assets/AndroidUltimatePlugin/Scripts you will an example folder inside that is a lot of example codes this scripts shows on how to use Android Ultimate Plugin.

Important:
you will noticed when testing the plugin on actual android device you will see Toast Message showing everytime when you do some task to remove this toast messages just set the debug to 0
or when you are done testing you should turn the debug to 0 to remove irrelevant toast messages from appearing.

Note:
some of the task that you will do require some permissions without this permission on your manifest there will be 2 scenarios.

1. it will not work.
2. your app might crashed.

The Following Permissions are needed to make Android Ultimate PlugIn work


basic Permissions - I assume that you have this permissions

<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
<uses-permission android:name="android.permission.READ_INTERNAL_STORAGE" />
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />  
<uses-permission android:name="android.permission.GET_TASKS"/>


Flashlightt Permissions

<!--for flash light-->
<uses-permission android:name="android.permission.FLASHLIGHT"/>       
<uses-permission android:name="android.permission.CAMERA"/>
<uses-feature android:name="android.hardware.camera"/>
<uses-feature android:name="android.hardware.camera.autofocus" />
<uses-feature android:name="android.hardware.camera.flash" />    
<!--for flash light-->

Vibration or force feedback permissions

<!--Vibration-->
<uses-permission android:name="android.permission.VIBRATE"/>
<!--Vibration-->


Bluetooth Permissions
<!--BlueTooth-->
<uses-permission android:name="android.permission.BLUETOOTH"/>
<uses-permission android:name="android.permission.BLUETOOTH_ADMIN"/>
<!--BlueTooth-->

read Bluetooth usage text file under Assets/AndroidUltimatePlugin for further instructions


Audio Recorder permissions
Note: Speech Recognizer will not work without internet connection

<!--RecordAudio also used by SpeechRecognizer-->
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
<uses-permission android:name="android.permission.RECORD_AUDIO" />
<!--RecordAudio also used by SpeechRecognizer-->

GPS permission
<!--for GPS-->
<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION"/>
<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION"/>
<!--for GPS-->

Battery Life Event
Does not need any permission

Local notification Receiver add this after <Activity android:name="com.unity3d.player.UnityPlayerNativeActivity" ></Activity>

<!--for local notification  -->
<receiver android:name="com.gigadrillgames.androidplugin.notification.NotificationPublisher" />
<!--for local notification  -->

also add this after <Activity android:name="com.unity3d.player.UnityPlayerNativeActivity" ></Activity>
<meta-data android:name="com.google.android.gms.version" android:value="@integer/google_play_services_version" />
this is use when accessing google services like google play leaderboard, achievement and etc.


Note: if you want to change the icon for local notification and sound just replace the "ic_launcher.png" icon on  Assets/Plugins/Android/res folder and alert.wav in raw folder.
each ic_launcher.png has different sizes per folder ex. ldpi,hdpi,mdpi


For questions,clarifications,concerns,comments and suggestions 
just email us at gigadrillgames@gmail.com

For more informations:
http://www.gigadrillgames.com/android-ultimate-plugin/

For more Tutorials:
http://www.gigadrillgames.com/2015/07/26/list-of-tutorials-for-android-ultimate-plugin/

Frequently asked questions:
http://www.gigadrillgames.com/2015/07/29/faq-android-ultimate-plugin/
