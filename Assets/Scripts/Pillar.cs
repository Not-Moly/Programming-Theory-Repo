using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UIElements;

public abstract class Pillar : MonoBehaviour // INHERITANCE (This class pillar will be inherited from the other four pillars)
{
    public bool isSelected = false;
    public abstract string Description {get;}   // ENCAPSULATION
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            Action();
        }else{
            Off();
        }
    }
    protected abstract void Action();   // POLYMORPHISM
    protected abstract void Off();      // POLYMORPHISM
}
