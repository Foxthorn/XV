using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	public List<GameObject> placableObjects = new List<GameObject>();
	// Use this for initialization
	void Awake () {
		if (gm == null)
			gm = this;

		var objectArray = Resources.LoadAll("", typeof(GameObject));
		foreach (Object item in objectArray)
		{
			placableObjects.Add((GameObject)item);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
