using UnityEngine;
using System.Collections;



public class texture : MonoBehaviour {
	
	public GameObject yourobject;
	
	// Use this for initialization
	void Start () {
		
		// Create a texture for the Live FaceCam (do this only once, not every frame)
		Texture2D texture = new Texture2D(128, 128, TextureFormat.BGRA32, false);
		texture.wrapMode = TextureWrapMode.Repeat;
		
		// Tell the texture id and size to the Live FaceCam
		Everyplay.SharedInstance.FaceCamSetTargetTextureId(texture.GetNativeTextureID());
		Everyplay.SharedInstance.FaceCamSetTargetTextureWidth(texture.width);
		Everyplay.SharedInstance.FaceCamSetTargetTextureHeight(texture.height);
		
		// Bind the texture to the material
		yourobject.renderer.material.mainTexture = texture;
		
		// Start the session
		Everyplay.SharedInstance.FaceCamStartSession();
		
	}
	
	
}