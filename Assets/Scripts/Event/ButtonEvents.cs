using UnityEngine;
using System.Collections;

public class ButtonEvents : MonoBehaviour {

	public static ButtonEvents Instance;

	public delegate void ButtonEvent();
	public event ButtonEvent myButtonEvent;

	// Use this for initialization
	void Start () 
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void LoadLevel()
	{

	}

	void Close()
	{
		Application.Quit ();
	}
}
