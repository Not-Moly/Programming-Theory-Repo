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
    private float alpha_rate = 0.5f;

    // POLYMORPHISM
    public override string Description => "Encapsulation is the practice of bundling related data into a structured unit, along with the methods used to work with that data. Most OOP languages implement encapsulation primarily through classes and the objects instantiated through those classes.";

    // Start is called before the first frame update
    void Start()
    {
        capsule_col = capsule.GetComponent<Renderer>().material.color;
        Off();
    }

    protected override void Action()        // POLYMORPHISM
    {
        capsule.SetActive(isSelected);
        capsule.GetComponent<Renderer>().material.color = new Color(capsule_col.r, capsule_col.g, capsule_col.b, alpha_var);
        //Debug.Log("Accionando");
        if (alpha_increasing)
            alpha_var += alpha_rate * Time.deltaTime;
        else
            alpha_var -= alpha_rate * Time.deltaTime;

        if (alpha_var >= 0.75f)
            alpha_increasing = false;
        if (alpha_var <= 0)
            alpha_increasing = true;

    }
    protected override void Off()       // POLYMORPHISM
    {
        capsule_col = capsule.GetComponent<Renderer>().material.color;
        alpha_increasing = true;
        alpha_var = 0.0f;
        if (capsule_col.a > 0.0f)
        {
            capsule.GetComponent<Renderer>().material.color = new Color(capsule_col.r, capsule_col.g, capsule_col.b, capsule_col.a - alpha_rate * Time.deltaTime);
        }
        else
        {
            capsule_col = new Color(capsule_col.r, capsule_col.g, capsule_col.b, 0.0f);
            capsule.SetActive(isSelected);
        }
    }
    // Update is called once per frame
}
