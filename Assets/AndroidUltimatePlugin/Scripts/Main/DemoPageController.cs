using UnityEngine;
using System.Collections;

public class DemoPageController : MonoBehaviour {

	private static GameObject container;
	private static DemoPageController instance;

	private int currentPage = 0;
	private int maxPage = 8;

	private string[] sceneNames = new string[8]{ "Intro","ShareAndExperienceDemo","GoogleIndexingDemo","AudioRecordDemo"
		,"VibrationDemo","FlashlightDemo","GPSDemo","AndroidNativeUIDemo"};

	public static DemoPageController GetInstance(){
		if(instance==null){
			container = new GameObject();
			container.name="DemoPageController";
			instance = container.AddComponent(typeof(DemoPageController)) as DemoPageController;
			DontDestroyOnLoad(instance.gameObject);
		}

		return instance;
	}

	public void nextPage(){
		currentPage++;
		if(currentPage >= maxPage){
			currentPage =maxPage;
		}
		Application.LoadLevel(currentPage);
		//Application.LoadLevel();
	}

	public void prevPage(){
		currentPage--;
		if(currentPage <= 0){
			currentPage = 0;
		}
		Application.LoadLevel(sceneNames[currentPage]);
	}
}
