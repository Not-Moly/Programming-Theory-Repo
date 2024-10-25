using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UIElements;

public abstract class Pillar : MonoBehaviour
{
    public Camera GameCamera;
    protected bool isSelected = false;
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
            

            // check if the hit object have a IUIInfoContent to display in the UI
            // if there is none, this will be null, so this will hid the panel if it was displayed
        }
        // end of code cut from GetMouseButtonDown(0) check
    }
    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 0.1f);
        }
    }
    protected abstract void Action();
}
