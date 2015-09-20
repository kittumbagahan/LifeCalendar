using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ExistingEvent : MonoBehaviour {

    public static ExistingEvent existingEventInstance;
    
    [SerializeField] GameObject parent;

	// Use this for initialization
	void Start () {
        existingEventInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FillEventList(List<string> eventList)
    {
        if (eventList.Count == 0)
            return;
    
        for (int i = 0; i < eventList.Count; i++)
        {
            GameObject theEvent;
            theEvent = GameObject.Instantiate(Resources.Load("Prefabs/EventItem") as GameObject);
            theEvent.transform.SetParent(parent.transform);
            theEvent.transform.GetChild(0).GetComponent<Text>().text = eventList[i].Replace("@", "\n");            
        }
    }

    void OnEnable()
    {        
        if (SetEvent.setEventInstance._ExistingEvent().Count == 0)
            print("no record!");
        else
        {
            print("exist!");
            EventValues.evenValuesInstance.EventListSetActive(true);
            FillEventList(SetEvent.setEventInstance._ExistingEvent());
        }         
    }

    void OnDisable()
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            DestroyObject(parent.transform.GetChild(i).gameObject);
        }
        EventValues.evenValuesInstance.ClearTitle();
        EventValues.evenValuesInstance.EventListSetActive(false);        
    }
}
