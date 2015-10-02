using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEvent : MonoBehaviour {

    public static SetEvent setEventInstance;

	DateTime myDateTime;

	[SerializeField] GameObject myYearButton; 
	[SerializeField] GameObject parent;
	[SerializeField] GameObject MonthsPanel;
	[SerializeField] GameObject ScrollView;
    [SerializeField] GameObject EventPanel;
    [SerializeField] GameObject EventDescription;    
    [SerializeField] Text YearAndMonth;
    [SerializeField] Transform prev;
    [SerializeField] Transform next;
    [SerializeField] Transform month;
    
    public int Year;
    int Month, date;        

	// Use this for initialization
	void Start () 
    {
        setEventInstance = this;
		myDateTime = DateTime.Today;
        Year = DateTime.Now.Year;
        //Month = DateTime.Now.ToString("MMMM");
        Month = DateTime.Now.Month;
        DisplayYear();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	#region METHODS

	void DisplayYear()
	{
        CreateYearButton();
        AddYearToButton();        
        ChangeMonthAndYear();        
        AddDateButton(Month, Year);
	}

	void CreateYearButton()
	{
		// Get 15 years from present to future and show it to the screen
		for (int i = 0; i < 15; i++) 
        {
			Instantiate(myYearButton).transform.SetParent(parent.transform);
		}
	}

    void AddDateButton(int month, int year)
    {
        int daysInMonth = DateTime.DaysInMonth(year, month);
        int childStart = new int(); // holder for the index of first day of the month where it will start        

        switch(new DateTime(year, month, 1).ToString("dddd"))
        {
            case "Sunday":
                childStart = 0;
                break;
            case "Monday":
                childStart = 1;
                break;
            case "Tuesday":
                childStart = 2;
                break;
            case "Wednesday":
                childStart = 3;
                break;
            case "Thursday":
                childStart = 4;
                break;
            case "Friday":
                childStart = 5;
                break;
            case "Saturday":
                childStart = 6;
                break;
        }

        GameObject datePanel = GameObject.Find("DatePanel");

        for (int i = 0; i < datePanel.transform.childCount; i++)// add date in datebuttons
        {
            datePanel.transform.GetChild(i).GetComponentInChildren<Text>().text = ""; // clear text
            datePanel.transform.GetChild(i).GetComponent<Image>().color = new Color32(255, 255, 255, 255); // paint white background
        }

        for (int i = 0; i < daysInMonth; i++)// add date in datebuttons
        {            
            datePanel.transform.GetChild(childStart + i).GetComponentInChildren<Text>().text = (i + 1).ToString();
            datePanel.transform.GetChild(childStart + i).GetComponentInChildren<Text>().color = new Color32(0, 0, 0, 255);

            //Check holiday date
            //Holiday.holidayInstance.SetHoliday(datePanel.transform.GetChild(childStart + i), month, i + 1);
            GetComponent<Holiday>().SetHoliday(datePanel.transform.GetChild(childStart + i), month, i + 1);

            if (month == DateTime.Now.Month && year == DateTime.Now.Year && DateTime.Now.Day == i + 1)
            {                
                datePanel.transform.GetChild(childStart + i).GetComponent<Image>().color = new Color32(150, 150, 150, 255);
            }
        }
    }

	void AddYearToButton()// add year to yearButton
	{
		for (int i = 0; i < 15; i++) 
        {
			parent.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = (myDateTime.Year + i).ToString();            
		}
	}    
    
	public void ToggleYear()// toggle Month and Year Panel
	{
        ScrollView.gameObject.SetActive(!ScrollView.gameObject.activeInHierarchy);
        //MonthsPanel.gameObject.SetActive(!MonthsPanel.gameObject.activeInHierarchy);
        
	}    

    public void ToggleSetEvent()
    {
        print("Toggle Event Panel");
        EventPanel.gameObject.SetActive(!EventPanel.gameObject.activeInHierarchy);
    }

    public void PassYear()
    {        
        //Month = DateTime.Now.ToString("MMMM");   

        if (Year == DateTime.Now.Year)
            Month = DateTime.Now.Month;

        ChangeMonthAndYear();
        AddDateButton(Month, Year);
    }

    void ChangeMonthAndYear()
    {
        month.GetComponentInChildren<Text>().text = new DateTime(Year, Month, 1).ToString("MMMM yyyy");

        if (DateTime.Now.Year == Year)
        {
            if(Month <= DateTime.Now.Month)
            {
                prev.gameObject.SetActive(false);
            }
            else if (Month == 12)
                next.gameObject.SetActive(false);
            else
            {
                prev.gameObject.SetActive(true);
                next.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Month == 1)// disable/enable prev and next button
                prev.gameObject.SetActive(false);
            else if (Month == 12)
                next.gameObject.SetActive(false);
            else
            {
                prev.gameObject.SetActive(true);
                next.gameObject.SetActive(true);
            }
        }
    }    

    public void PrevMonth()
    {
        Month--;
        ChangeMonthAndYear();
        AddDateButton(Month, Year);
    }

    public void NextMonth()
    {
        Month++;
        ChangeMonthAndYear();
        AddDateButton(Month, Year);
    }

    void SetHolidays()
    {

    }
    
    // called when date button is clicked
    public void OpenEvent(Text dateText)
    {
        date = int.Parse(dateText.text);
        //EventValues.evenValuesInstance        
        if(dateText.text != "")
        {         
            YearAndMonth.text = "Set Event on: " + new DateTime(Year, Month, date).ToString("MMMM dd, yyyy");
            EventValues.evenValuesInstance.PassEventData(Year, Month, date);

            //ExistingEvent.existingEventInstance.FillEventList(_ExistingEvent());
            ToggleSetEvent();
        }        
        //if (PlayerPrefs.GetString(Year + "#" + Month + "#" + date) != "")
        //    ExistingEvent.existingEventInstance.FillEventList
    }  
  
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public List<string> _ExistingEvent()
    {
        List<string> existingEventList = new List<string>();        
        string eventList;

        //string field = Year + "#" + Month + "#" + date;
        string field = "event";

        if (PlayerPrefs.HasKey(field))
        {
            eventList = PlayerPrefs.GetString(field);
            eventList = eventList.Remove(eventList.Length - 1);
            existingEventList.AddRange(eventList.Split('^'));
        }        

        EventValues.evenValuesInstance.FillCurrentEventList(existingEventList);            

        return existingEventList;
    }
	#endregion
}
