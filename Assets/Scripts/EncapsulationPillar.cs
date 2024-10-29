using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncapsulationPillar : Pillar
{
    [SerializeField]
    private GameObject capsule;
    [SerializeField]
    private Color capsule_col;
    private float alpha_var;
    private bool alpha_increasing;
    // Start is called before the first frame update
    void Start()
    {
        capsule_col = capsule.GetComponent<Renderer>().material.color;
        Off();
    }

    protected override void Action()
    {
        capsule.SetActive(isSelected);
        capsule.GetComponent<Renderer>().material.color = new Color(capsule_col.r,capsule_col.g,capsule_col.b,alpha_var);
        //Debug.Log("Accionando");
        if (alpha_increasing)
            alpha_var += 0.5f * Time.deltaTime;
        else
            alpha_var -= 0.5f * Time.deltaTime;
        
        if (alpha_var >= 0.75f)
            alpha_increasing = false;
        if (alpha_var <= 0)
            alpha_increasing = true;
        
    }
    protected override void Off()
    {
        capsule.SetActive(isSelected);
        alpha_increasing = true;
        alpha_var = 0.0f;
        capsule.GetComponent<Renderer>().material.color = new Color(capsule_col.r,capsule_col.g,capsule_col.b,alpha_var);
    }
    // Update is called once per frame
}
