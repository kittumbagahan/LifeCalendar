using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	//[SerializeField]
	public enum LEVELNAME {SET, AUGMENT, CLOSE, EVENTLIST};
	public LEVELNAME levelName;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	public void LoadLevel()
	{
		//print (levelName.ToString ());
		Application.LoadLevel (levelName.ToString());
	}
}
