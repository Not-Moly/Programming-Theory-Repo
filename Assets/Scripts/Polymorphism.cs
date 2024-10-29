using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polymorphism : Pillar
{
    private float scaleFactor = 1f;
    private int scaleState = 0;

    // POLYMORPHISM
    public override string Description => "Polymorphism describes the ability of something to have or to be displayed in more than one form. The different forms arise because these entities can be assigned different meanings and used in various ways in multiple contexts.";

    // Start is called before the first frame update
    void Start()
    {

    }
    protected override void Action()        // POLYMORPHISM
    {
        switch (scaleState)
        {
            case 0:
                transform.localScale += scaleFactor * Time.deltaTime * Vector3.right;
                if (transform.localScale.x >= 2.0f)
                    scaleState += 1;
                break;
            case 1:
                transform.localScale += scaleFactor * Time.deltaTime * Vector3.left;
                if (transform.localScale.x <= 1.0f)
                    scaleState += 1;
                break;
            case 2:
                transform.localScale += scaleFactor * Time.deltaTime * Vector3.forward;
                if (transform.localScale.z >= 2.0f)
                    scaleState += 1;
                break;
            case 3:
                transform.localScale += scaleFactor * Time.deltaTime * Vector3.back;
                if (transform.localScale.z <= 1.0f)
                    scaleState = 0;
                break;
            default:
                break;

        }
    }
    protected override void Off()       // POLYMORPHISM
    {
        scaleState = 0;
        if (transform.localScale.x > 1.0f)
        {
            transform.localScale += scaleFactor * Time.deltaTime * Vector3.left;
        }
        if (transform.localScale.z > 1.0f)
        {
            transform.localScale += scaleFactor * Time.deltaTime * Vector3.back;
        }
    }
}
