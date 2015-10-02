using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventValues : MonoBehaviour
{

    #region Fields
    public static EventValues evenValuesInstance;

    AlarmPlugin alarmPlugin;

    // for set event 
    string eventDescription = "";    
    bool isVibOn = true, isAM = true;
    int date, year, month;
    GameObject eventTitle;

    List<string> currentEvenList;

    [SerializeField] GameObject EventDescriptionContainer;
    [SerializeField] GameObject EvenDescription;
    [SerializeField] GameObject EventTitle;
    [SerializeField] GameObject ExistingEventPanel;
    [SerializeField] GameObject Hour;
    [SerializeField] GameObject Min;    
    //
    #endregion

    // Use this for initialization
	void Start () {
        currentEvenList = new List<string>();
        evenValuesInstance = this;
        alarmPlugin = AlarmPlugin.GetInstance();
        alarmPlugin.SetDebug(0);
        alarmPlugin.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    #region Members
    public void EventDescClick()
    {

    }

    public void ClearTitle()
    {
        EventTitle.GetComponent<InputField>().text = "";
    }

    public void CancelEvent()
    {
        this.year = this.month = this.date = 0;
        SetEvent.setEventInstance.ToggleSetEvent();
    }

    public void Title()
    {
        Application.LoadLevel(0);
    }

    public void ToggleEventDescription(string desc = "")
    {                
        print(eventDescription);
        EventDescriptionContainer.gameObject.SetActive(!EventDescriptionContainer.gameObject.activeInHierarchy);        
    }

    public void CloseDescription(string desc)
    {
        eventDescription = desc;
        EvenDescription.transform.GetChild(0).GetComponent<Text>().text = eventDescription;
        EventDescriptionContainer.gameObject.SetActive(!EventDescriptionContainer.gameObject.activeInHierarchy);
    }

    public void ToogleVib(bool val)
    {
        isVibOn = val;
        print(isVibOn);
    }

    public void ToggleAmPm(bool val)
    {
        isAM = val;
        print(isAM);
    }

    public void AddEvent()
    {
        int theHour, theMin;
        theHour = int.Parse(Hour.GetComponent<InputField>().text);
        theMin = int.Parse(Min.GetComponent<InputField>().text);

        string amPm = (isAM) ? "AM" : "PM";
        
        print("INSERT INTO EventListTbl (Year, Month, Date, Description, Title, Time) VALUES ('" + this.year + "', '" + this.month + "', '" + this.date + "', '" + eventDescription + "', '" + EventTitle.GetComponent<InputField>().text +
            "', '" + theHour + ":" + theMin.ToString("00") + amPm + "')");

        currentEvenList.Add(new DateTime(this.year,this.month,this.date).ToString("MMMM d, yyyy") + "@Description: " + eventDescription + "@Title: " + EventTitle.GetComponent<InputField>().text + "@Time: " + theHour + ":" + theMin.ToString("00") + amPm);

        if (!isAM)
            theHour += 12;
        
        print("Hour: " + theHour + ", Min: " + theMin + " " + amPm);        

        //alarmPlugin.SetOneTimeAlarm(theHour, theMin, EventTitle.GetComponent<InputField>().text, eventDescription, EventTitle.GetComponent<InputField>().text);
             
        string eventString = null;
        for (int i = 0; i < currentEvenList.Count; i++)
        {
            eventString += currentEvenList[i] + "^";
        }

        if (!PlayerPrefs.HasKey("event"))
        {
            PlayerPrefs.SetString("event", eventString);
        }
        else
        {
            string existingEventString = PlayerPrefs.GetString("event") + eventString;
            PlayerPrefs.SetString("event", existingEventString);
        }

        //PlayerPrefs.SetString("event", eventString);
        print(eventString);
        currentEvenList.Clear();
        CancelEvent();
    }

    public void PassEventData(int year, int month, int date)
    {
        this.year = year;
        this.month = month;
        this.date = date;
    }

    public void HourEndEdit()
    {
        if(int.Parse(Hour.GetComponent<InputField>().text) < 1)
            Hour.GetComponent<InputField>().text = "1";
        else if(int.Parse(Hour.GetComponent<InputField>().text) > 12)
            Hour.GetComponent<InputField>().text = "12";
    }

    public void MinEndEdit()
    {                
        Min.GetComponent<InputField>().text = string.Format("{0:00}", int.Parse(Min.GetComponent<InputField>().text));        
        if (int.Parse(Min.GetComponent<InputField>().text) > 59)
            Min.GetComponent<InputField>().text = "59";
    }

    public int GetYear()
    {
        return this.year;
    }

    public int GetMonth()
    {
        return this.month;
    }

    public void EventListSetActive(bool val)
    {
        ExistingEventPanel.SetActive(val);
    }

    public void FillCurrentEventList(List<string> theList)
    {
        currentEvenList = theList;
    }
    #endregion
}
