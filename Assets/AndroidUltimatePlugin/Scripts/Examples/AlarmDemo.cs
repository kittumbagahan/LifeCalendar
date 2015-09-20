using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AlarmDemo : MonoBehaviour {

	private AlarmPlugin alarmPlugin;

	public InputField hourInput;
	public InputField minuteInput;
	public InputField delayIntervalInput;

	private int hour = 0;
	private int minute = 0;
	private int delayInterval = 0;

	private AndroidUltimatePluginController androidUltimatePluginController;

	// Use this for initialization
	void Start () {
		androidUltimatePluginController = AndroidUltimatePluginController.GetInstance();

		alarmPlugin = AlarmPlugin.GetInstance();
		alarmPlugin.SetDebug(0);
		alarmPlugin.Init();
	}

	private void getHourMinute(){
		if(hourInput!=null){
			if(hourInput.text.Equals("",StringComparison.Ordinal)){
				//default get current hour
				hour = int.Parse(androidUltimatePluginController.GetHour());
				hourInput.text =hour.ToString();
			}else{
				//hour =  int.Parse(hourInput.text);
				if(!int.TryParse(hourInput.text,out hour)){
					//default get current hour
					hour = int.Parse(androidUltimatePluginController.GetHour());
					hourInput.text =hour.ToString();
				}else{
					hourInput.text =hour.ToString();
				}
			}
		}
		
		if(minuteInput!=null){
			if(minuteInput.text.Equals("",StringComparison.Ordinal)){
				//default 5 minutes
				minute = int.Parse(androidUltimatePluginController.GetMinute()) + 1;
				minuteInput.text =minute.ToString();
			}else{
				//minute =  int.Parse(minuteInput.text);
				if(!int.TryParse(minuteInput.text,out minute)){
					//default 5 minutes
					minute = int.Parse(androidUltimatePluginController.GetMinute()) + 1;
					minuteInput.text =minute.ToString();
				}else{
					minuteInput.text =minute.ToString();
				}
			}
		}
	}

	private void getDelayInterval(){
		if(delayIntervalInput!=null){
			if(delayIntervalInput.text.Equals("",StringComparison.Ordinal)){
				//default 10 seconds
				delayInterval = 1000 * 10;
				delayIntervalInput.text = delayInterval.ToString();
			}else{
				//delayInterval =  int.Parse(delayIntervalInput.text);
				if(!int.TryParse(delayIntervalInput.text,out delayInterval)){
					delayInterval = 1000 * 10;
					delayIntervalInput.text = delayInterval.ToString();
				}else{
					delayIntervalInput.text = delayInterval.ToString();
				}
			}
		}
	}
	
	public void SetOneTimeAlarm(){
		//sample
		//3:30 PM
		//alarmPlugin.SetOneTimeAlarm(15,30,"Alarm Title - one time alarm","Alarm Message","Alarm Ticker Message");

		getHourMinute();
		alarmPlugin.SetOneTimeAlarm(hour,minute,"Alarm Title - one time alarm","Alarm Message","Alarm Ticker Message");
	}

	public void SetRepeatingAlarm(){
		//sample
		//4:30 PM
		//alarmPlugin.SetRepeatingAlarm(16,30,"Alarm Title - repeating alarm","Alarm Message","Alarm Ticker Message");

		getHourMinute();
		alarmPlugin.SetRepeatingAlarm(hour,minute,"Alarm Title - repeating alarm","Alarm Message","Alarm Ticker Message");        
	}

	public void SetRepeatingAlarmWithInterval(){
		//sample
		//1 minute
		//int delayInterval = (1000 * 60);
		// 3:45PM
		//alarmPlugin.SetRepeatingAlarmWithInterval(15,45,delayInterval,"Alarm Title - repeating alarm with interval","Alarm Message","Alarm Ticker Message");

		getHourMinute();
		getDelayInterval();
		alarmPlugin.SetRepeatingAlarmWithInterval(hour,minute,delayInterval,"Alarm Title - repeating alarm with interval","Alarm Message","Alarm Ticker Message");
	}

	public void CancelAlarm(){
		alarmPlugin.CancelAlarm();
	}

	public void StopAlarm(){
		alarmPlugin.StopAlarm();
	}

	public void PlayAlarm(){
		alarmPlugin.PlayAlarm();
	}
}
