using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Holiday : MonoBehaviour {

    public static Holiday holidayInstance;

    //List<>

	// Use this for initialization
	void Start () {
        holidayInstance = this;
	}
	
	// Update is called once per frame
	void Update () {

    }

    #region MEMBERS
    public void SetHoliday(Transform dateButton, int month, int date)
    {
        switch(month)
        {
            case 1://Jan
                switch(date)
                {
                    case 1:                        
                        Red(dateButton);                        
                        break;
                }
                break;
            case 2://Feb
                switch(date)
                {
                    case 14:
                        Red(dateButton);
                        break;
                    case 25:
                        Yellow(dateButton);
                        break;
                }
                break;
            case 5://May
                switch(date)
                {
                    case 1:
                        Orange(dateButton);
                        break;
                }
                break;
            case 6://Jun
                switch(date)
                {
                    case 12:
                        Yellow(dateButton);
                        break;
                    case 24:
                        Red(dateButton);
                        break;
                }
                break;
            case 8://Aug
                switch (date)
                {
                    case 21:
                        Yellow(dateButton);
                        break;
                    case 30:
                        Red(dateButton);
                        break;
                }
                break;
            case 11://Nov
                switch (date)
                {
                    case 1:
                        Black(dateButton);
                        break;
                    case 30:
                        Red(dateButton);
                        break;
                }
                break;
            case 12://Dec
                switch (date)
                {
                    case 25:
                        Green(dateButton);
                        break;
                    case 30:
                        Black(dateButton);
                        break;
                }
                break;
        }
    }

    void Red(Transform dateButton)
    {
        dateButton.transform.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
        dateButton.transform.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }

    void Yellow(Transform dateButton)
    {
        dateButton.transform.GetComponent<Image>().color = new Color32(239, 251, 20, 255);
    }

    void Orange(Transform dateButton)
    {
        dateButton.transform.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
        dateButton.transform.GetComponent<Image>().color = new Color32(249, 88, 0, 255);        
    }

    void Green(Transform dateButton)
    {
        dateButton.transform.GetComponent<Image>().color = new Color32(0, 249, 12, 255);
    }

    void Black(Transform dateButton)
    {
        dateButton.transform.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        dateButton.transform.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
    }
    #endregion
}
