using UnityEngine;
using System.Collections;

public class weather : MonoBehaviour {
	
	private static AndroidJavaObject _plugins;
	
	public string weatherinfo = "weather";
	public string sensorinfo = "sensor";
	
	
	// Use this for initialization
	void Start () {
		AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		_plugins = jc.GetStatic<AndroidJavaObject> ("currentActivity");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void android_getWeather(string arg)
	{
		weatherinfo = arg;
	}
	
	public void android_getSensor(string arg)
	{
		sensorinfo = arg;
	}
	
	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 210, 600, 100), weatherinfo)) 
		{
			_plugins.Call ("getWeather");
			GUI.Label(new Rect(0,0,1000,100),weatherinfo);
		}
		if (GUI.Button (new Rect (0, 105, 600, 100), sensorinfo)) 
		{
			_plugins.Call ("getSensor");
			GUI.Label(new Rect(150,0,1000,100),sensorinfo);
		}
	}
}
