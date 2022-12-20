using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSelector : MonoBehaviour
{
    public Camera camera;
    public float distanceFromCamera = 20;

    List<SelectableObject> selectableObjects = new List<SelectableObject>();
    void FetchSelectableObjects()
    {
        selectableObjects = FindObjectsOfType<SelectableObject>().ToList();
    }
    // Start is called before the first frame update
    void Start()
    {
        FetchSelectableObjects();

    }

    SelectableObject selectedItem = null;
    void DragSelectedItem()
    {
        if(selectedItem != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceFromCamera;
            Vector3 newPosition = camera.ScreenToWorldPoint(mousePos);
            selectedItem.transform.position = newPosition;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start Selection!");
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                SelectableObject selectedObject = hit.collider.gameObject.GetComponentInChildren<SelectableObject>();
                if (selectableObjects.Contains(selectedObject))
                {
                    selectedItem = selectedObject;
                }
            }
        }

        else if (Input.GetMouseButton(0))
        {
            Debug.Log("Dragging...");
            DragSelectedItem();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Stop!");
            selectedItem = null;
        }
    }

}
