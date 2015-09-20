using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YearButton : MonoBehaviour
{

    #region Variables
    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {

    }
       
    #endregion

    #region Methods
    public void Year()
    {
        //print(this.gameObject.GetComponentInChildren<Text>().text);        
        GameObject.Find("EventSystem").GetComponent<SetEvent>().Year = int.Parse(this.gameObject.GetComponentInChildren<Text>().text);
        GameObject.Find("EventSystem").GetComponent<SetEvent>().ToggleYear();
        GameObject.Find("EventSystem").GetComponent<SetEvent>().PassYear();
    }
    #endregion
}
