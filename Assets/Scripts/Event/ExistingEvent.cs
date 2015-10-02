using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ExistingEvent : MonoBehaviour {

    public static ExistingEvent existingEventInstance;
    
    [SerializeField] GameObject parent;
    [SerializeField] Toggle toggleAll;

    List<string> eventList;

	// Use this for initialization
	void Start () {
        existingEventInstance = this;
        eventList = new List<string>();
        GetEventList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    string eventString;

    void GetEventList()
    {
        if(!PlayerPrefs.HasKey("event"))
        {
            return;
        }

        eventString = PlayerPrefs.GetString("event");
        eventString = eventString.Remove(eventString.Length - 1);
        eventList.AddRange(eventString.Split('^'));

        for (int i = 0; i < eventList.Count; i++)
        {
            GameObject theEvent;
            theEvent = GameObject.Instantiate(Resources.Load("Prefabs/EventItem") as GameObject);
            theEvent.transform.SetParent(parent.transform);
            theEvent.transform.GetChild(0).GetComponent<Text>().text = eventList[i].Replace("@", "\n");
        }
    }

    public void DeleteEvent()
    {        
        for (int i = 0; i < parent.transform.childCount; i++)// destroy gameobject
        {            
            if (parent.transform.GetChild(i).GetComponent<EventItem>().checkBox.isOn == true)
            {
                Destroy(parent.transform.GetChild(i).gameObject);
            }
        }

        for (int i = parent.transform.childCount - 1; i > -1; i--)// delete in list
        {
            if (parent.transform.GetChild(i).GetComponent<EventItem>().checkBox.isOn == true)
            {
                print(eventList[i]);
                eventList.RemoveAt(i);
            }
        }

        Save();
    }

    void Save()
    {
        string eventString = "";

        for (int i = 0; i < eventList.Count; i++)
        {
            eventString += eventList[i] + "^";
        }

        if (eventString == "")
        {
            eventList.Clear();
            PlayerPrefs.DeleteKey("event");
        }
        else
        {
            PlayerPrefs.SetString("event", eventString);
        }
    }

    public void ToggleAll()
    {
        if(toggleAll.isOn == true)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).GetComponent<EventItem>().checkBox.isOn = true;
            }
        }
        else
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).GetComponent<EventItem>().checkBox.isOn = false;
            }
        }
    }

    public void CheckToggle()
    {
        print(parent.transform.childCount);
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            print(parent.transform.GetChild(i).GetComponent<EventItem>().checkBox.isOn);
            if(parent.transform.GetChild(i).GetComponent<EventItem>().checkBox.isOn == false)
            {
                toggleAll.isOn = false;
                break;
            }                 
        }

        toggleAll.isOn = true;

    }
    //public void FillEventList(List<string> eventList)
    //{
    //    if (eventList.Count == 0)
    //        return;
    
    //    for (int i = 0; i < eventList.Count; i++)
    //    {
    //        GameObject theEvent;
    //        theEvent = GameObject.Instantiate(Resources.Load("Prefabs/EventItem") as GameObject);
    //        theEvent.transform.SetParent(parent.transform);
    //        theEvent.transform.GetChild(0).GetComponent<Text>().text = eventList[i].Replace("@", "\n");            
    //    }
    //}

    //void OnEnable()
    //{        
    //    if (SetEvent.setEventInstance._ExistingEvent().Count == 0)
    //        print("no record!");
    //    else
    //    {
    //        print("exist!");
    //        EventValues.evenValuesInstance.EventListSetActive(true);
    //        FillEventList(SetEvent.setEventInstance._ExistingEvent());
    //    }         
    //}

    //void OnDisable()
    //{
    //    for (int i = 0; i < parent.transform.childCount; i++)
    //    {
    //        DestroyObject(parent.transform.GetChild(i).gameObject);
    //    }
    //    EventValues.evenValuesInstance.ClearTitle();
    //    EventValues.evenValuesInstance.EventListSetActive(false);        
    //}
}
