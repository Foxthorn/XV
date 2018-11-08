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
					var temp = btn.transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale;
					temp.x = 4;
					btn.transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = temp;
					Button b = btn.GetComponent<Button>();
					b.onClick.AddListener(() => CreateObject(obj.transform.name));
				}
			}
		}
	}

	void CreateObject(string name)
	{
		GameObject obj = null;
		foreach (GameObject item in GameManager.gm.placableObjects)
		{
			if (item.transform.name == name)
			{
				obj = item;
				break;
			}	
		}
		if (obj != null)
			Instantiate(obj, Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, 7.2f)), Quaternion.identity);
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
