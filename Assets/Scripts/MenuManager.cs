using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject button;

	public List<GameObject> toggleMenus = new List<GameObject>();
	// Use this for initialization
	void Start () {
		foreach (GameObject menu in toggleMenus)
		{
			menu.SetActive(false);
		}
		SetupBuildMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetupBuildMenu()
	{
		foreach (var menu in toggleMenus)
		{
			if (menu.transform.tag == "BuildMenu")
			{
				foreach(GameObject obj in GameManager.gm.placableObjects)
				{
					var btn = Instantiate(button, menu.transform);
					btn.transform.GetChild(0).gameObject.GetComponent<Text>().text = obj.transform.name;
					btn.transform.GetChild(0).gameObject.GetComponent<Text>().text = obj.transform.name;
				}
			}
		}
	}

	public void ShowBuildMenu()
	{
		foreach (var menu in toggleMenus)
		{
			if (menu.transform.tag == "BuildMenu")
				menu.SetActive(!menu.activeSelf);
		}
	}
}
