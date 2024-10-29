using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserController : MonoBehaviour
{
    public Camera GameCamera;
    public TextMeshProUGUI descriptionUIText;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void HandleSelection()
    {
        // start of code cut from GetMouseButtonDown(0) check
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // the collider could be children of the unit, so we make sure to check in the parent
            //Debug.Log("Hit");
            //Debug.Log(hit.collider.gameObject.name);
            //Debug.Log(hit.collider.GetComponent<Pillar>());
            if (hit.collider.GetComponentInParent<Pillar>())
            {
                Pillar[] pillarsInScene = FindObjectsOfType<Pillar>();
                for (int i = 0; i < pillarsInScene.Length; i++)
                {
                    pillarsInScene[i].isSelected = false;
                }
                GameObject pillar = hit.collider.gameObject;
                Pillar pillar_component = hit.collider.gameObject.GetComponent<Pillar>();
                pillar_component.isSelected = true;
                descriptionUIText.text = pillar_component.Description;
            }

            // check if the hit object have a IUIInfoContent to display in the UI
            // if there is none, this will be null, so this will hid the panel if it was displayed
        }
        // end of code cut from GetMouseButtonDown(0) check
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
            //Debug.Log("click");
        }
    }
}
