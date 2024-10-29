using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public Camera GameCamera;
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
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.collider.GetComponent<Pillar>());
            if (hit.collider.GetComponentInParent<Pillar>()){
                GameObject pillar = hit.collider.gameObject;
                Pillar pillar_component = hit.collider.gameObject.GetComponent<Pillar>();
                pillar_component.isSelected = true;
                
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
