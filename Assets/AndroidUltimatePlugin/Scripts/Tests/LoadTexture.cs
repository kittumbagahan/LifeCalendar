using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadTexture : MonoBehaviour {

	public RawImage rawImage;

	//private string filename = "unity3d_logo.png";
	private string filename = "apple_logo.jpg";

	// Use this for initialization
	void Start () {
		LoadExternalTestImage();
	}

	private void LoadInternalTestImage(){		
		string imagePath = Application.dataPath + "/AndroidUltimatePlugin/RawAssets/Textures/"+filename;
		rawImage.texture = Utils.LoadTexture(imagePath);
	}

	private void LoadExternalTestImage(){		
		//string path = Application.persistentDataPath + "/" + filename;
		//string path = "/storage/emulated/0/Pictures/MyCameraApp/" + filename;
		string path = "storage/emulated/0/Pictures/MyCameraApp/IMG_20150731_153203.jpg";
		
		Debug.Log("device imagepath " + path);
		
		rawImage.texture = Utils.LoadTexture(path);
	}
}
