using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstraction : Pillar
{
    [SerializeField]
    private Material pillar_material;
    private Color pillar_color;
    private float alpha_var = 1.0f;
    private bool alpha_increasing;
    private float alpha_rate = 0.5f;
    private Renderer[] pillar_parts_renderer;

    // POLYMORPHISM
    public override string Description => "Abstraction involves hiding an object's implementation details and only showing the user the information that is absolutely necessary. This makes it simpler to read and maintain the code";


    // Start is called before the first frame update
    void Start()
    {
        pillar_material = new Material(pillar_material);
        pillar_color = GetComponentInChildren<Renderer>().material.color;
        pillar_parts_renderer = GetComponentsInChildren<Renderer>();
    }
    void SetPillarColor()       // ABSTRACTION
    {
        pillar_parts_renderer = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < pillar_parts_renderer.Length; i++)
        {
            pillar_parts_renderer[i].material.color = new Color(pillar_color.r, pillar_color.g, pillar_color.b, alpha_var);
        }
    }
    protected override void Action()        // POLYMORPHISM
    {
        SetPillarColor();
        //Debug.Log("Accionando");
        if (alpha_increasing)
            alpha_var += alpha_rate * Time.deltaTime;
        else
            alpha_var -= alpha_rate * Time.deltaTime;

        if (alpha_var >= 1f)
            alpha_increasing = false;
        if (alpha_var <= 0)
            alpha_increasing = true;
    }
    protected override void Off()       // POLYMORPHISM
    {
        alpha_increasing = false;
        if (pillar_parts_renderer[0].material.color.a < 1.0f)
        {
            alpha_var += alpha_rate * Time.deltaTime;
            SetPillarColor();
        }
    }
}
