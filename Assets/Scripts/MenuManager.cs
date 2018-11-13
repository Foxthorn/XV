using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject button;

	public List<GameObject> toggleMenus = new List<GameObject>();

	string[] officeObjects = {"Photocopier", "Printer", "Paper", "Document", "code"};
	string[] shelvingObjects = {"Shelves", "Rack", "Cage", "Cantilever"};
	string[] tables = {"Table", "Desk"};
	bool subMenu = false;
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
					btn.transform.name = obj.name;
					btn.transform.GetChild(0).gameObject.GetComponent<Text>().text = obj.transform.name;
					var temp = btn.transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale;
					temp.x = 4;
					btn.transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = temp;
					Button b = btn.GetComponent<Button>();
					b.onClick.AddListener(() => CreateObject(obj.transform.name));
					btn.SetActive(false);
				}
			}
		}
	}

	public void TableButon()
	{
		foreach(var menu in toggleMenus)
		{
			if (menu.transform.tag == "BuildMenu")
			{
				var menuButton = menu.transform.Find("Other");
				Debug.Log(menuButton);
				foreach(Transform btn in menu.transform)
				{
					foreach(string name in tables)
					{
						if (btn.name.Contains(name))
						{
							if (subMenu && btn.gameObject.active)
								btn.gameObject.SetActive(false);
							else
							{
								btn.SetSiblingIndex(menuButton.GetSiblingIndex() + 1);
								btn.gameObject.SetActive(true);		
							}				
						}
					}
				}
			}
		}
		subMenu = true;
	}

	public void ShelvingButton()
	{
		foreach(var menu in toggleMenus)
		{
			if (menu.transform.tag == "BuildMenu")
			{
				var menuButton = menu.transform.Find("Shelving");
				foreach(Transform btn in menu.transform)
				{
					foreach(string name in shelvingObjects)
					{
						if (btn.name.Contains(name))
						{
							if (subMenu && btn.gameObject.active)
								btn.gameObject.SetActive(false);
							else
							{
								btn.SetSiblingIndex(menuButton.GetSiblingIndex() + 1);
								btn.gameObject.SetActive(true);		
							}				
						}
					}
				}
			}
		}
		subMenu = true;
	}

	public void OfficeButton()
	{
		foreach(var menu in toggleMenus)
		{
			if (menu.transform.tag == "BuildMenu")
			{
				var menuButton = menu.transform.Find("Office Equipment");
				foreach(Transform btn in menu.transform)
				{
					foreach(string name in officeObjects)
					{
						if (btn.name.Contains(name))
						{
							if (subMenu && btn.gameObject.active)
								btn.gameObject.SetActive(false);
							else
							{
								btn.SetSiblingIndex(menuButton.GetSiblingIndex() + 1);
								btn.gameObject.SetActive(true);		
							}				
						}
					}
				}
			}
		}
		subMenu = true;
	}

	public void MachineryButton()
	{
		foreach(var menu in toggleMenus)
		{
			if (menu.transform.tag == "BuildMenu")
			{
				var menuButton = menu.transform.Find("Machinery");
				foreach(Transform btn in menu.transform)
				{
					if (btn.name.Contains("Forklift") || btn.name.Contains("loader"))
					{
						if (subMenu && btn.gameObject.active)
							btn.gameObject.SetActive(false);
						else
						{
							btn.SetSiblingIndex(menuButton.GetSiblingIndex() + 1);
							btn.gameObject.SetActive(true);		
						}				
					}
				}
			}
		}
		subMenu = true;
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
		{
			var instance = Instantiate(obj, Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, 7.2f)), Quaternion.identity);
			var temp = new Vector3(1, 1, 1);
			instance.transform.localScale = temp;
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
