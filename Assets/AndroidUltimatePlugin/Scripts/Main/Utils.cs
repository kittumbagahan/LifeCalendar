using UnityEngine;
using System.Collections;
using System.IO;

public class Utils{
	public static void Message(string tag, string message){
		Debug.LogWarning(tag + message);
	}

	//take screen shot then share via intent
	public static IEnumerator TakeScreenshot(string screenShotPath){
		yield return new WaitForEndOfFrame();
		
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);

		tex.Apply();
		
		//saving to phone storage
		byte[] screenshot = tex.EncodeToPNG();
		System.IO.File.WriteAllBytes(screenShotPath,screenshot);
	}

	public static IEnumerator SaveTexureOnDevice(string texturePath, Texture2D texture){
		yield return new WaitForEndOfFrame();

		Color32[] pix = texture.GetPixels32();
		//System.Array.Reverse(pix);
		Texture2D destTex = new Texture2D(texture.width, texture.height);
		destTex.SetPixels32(pix);
		destTex.Apply();

		//saving to phone storage
		byte[] existingTexture = destTex.EncodeToPNG();
		System.IO.File.WriteAllBytes(texturePath,existingTexture);
	}

	public static Texture2D LoadTexture(string imagePath){
		Texture2D tex = new Texture2D(1, 1);

		if (System.IO.File.Exists(imagePath)){
			byte[] bytes = System.IO.File.ReadAllBytes(imagePath);
			tex.LoadImage(bytes);
		}

		return tex;
	}
}
