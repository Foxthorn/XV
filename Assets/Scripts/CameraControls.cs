using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

	public float rotationSpeed = 0.1f;

	float zoomDistance;
	GameObject selectedObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse1))
			CheckRayCollision();
		if (Input.GetKey(KeyCode.Mouse1) && selectedObject != null)
			RotateCamera();
		var scroll = Input.GetAxis("Mouse ScrollWheel");
		zoomDistance += scroll;
		if (scroll != 0)
			transform.Translate(Vector3.forward * scroll);
	}

	void CheckRayCollision()
	{
   		RaycastHit hit;
   		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
   		if ( Physics.Raycast(ray, out hit, 1000.0f)) 
		{
			if (hit.transform.tag == "Object")
			{
				selectedObject = hit.transform.gameObject;
				transform.LookAt(selectedObject.transform.position);
				while (Vector3.Distance(transform.position, hit.transform.position) > 10f)
					transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, 0.1f);
				ChangeMovement(true);
			}
		}
		else if (selectedObject != null)
		{
			ChangeMovement(false);
			selectedObject = null;			
		}
	}

	void ChangeMovement(bool change)
	{
		var parent = selectedObject.transform.parent;
		while(parent.transform.parent != null)
		{
			parent = parent.transform.parent;
		}
		var script = parent.GetComponent<ObjectManager>();
		script.selected = change;
	}

	void RotateCamera()
	{
		transform.LookAt(selectedObject.transform.position);
		var horizontal = Input.GetAxis("Mouse X");
		transform.RotateAround(selectedObject.transform.position, Vector3.up, 45 * horizontal * Time.deltaTime);
	}
}