using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	public bool selected;
	public float moveSpeed = 0.5f;
	public float rotationSpeed = 10f;

	DrawAxis axis;
	Material lineMaterial;
	// Use this for initialization
	void Start () {
		axis = GetComponent<DrawAxis>();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected)
		{
			axis.canDraw = true;
			if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
				RotateObject();
			else if (Input.GetKey(KeyCode.Mouse0))
				TranslateObject();
			if (Input.GetKeyDown(KeyCode.Delete))
				Destroy(gameObject);
		}
		else
		{
			axis.canDraw = false;
		}
	}

	void RotateObject()
	{
		var horizontal = Input.GetAxis("Mouse X");
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + horizontal * rotationSpeed, transform.eulerAngles.z);
	}

	void TranslateObject()
	{
		// var horizontal = Input.GetAxis("Mouse X");
		// var vertical = Input.GetAxis("Mouse Y");
		Vector3 temp = Input.mousePosition;
		temp.z = 7.2f;
		transform.position = Camera.main.ScreenToWorldPoint(temp);
	}

}
