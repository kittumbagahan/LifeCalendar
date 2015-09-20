using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

	public static Singleton Instance;

	// Use this for initialization
	void Start () 
    {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			DestroyObject (this.gameObject);
		}
	}
	// Update is called once per frame
	void Update () 
    {
		
	}
}
