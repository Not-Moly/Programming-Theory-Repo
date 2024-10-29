using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UIElements;

public abstract class Pillar : MonoBehaviour
{
    public bool isSelected = false;
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
    protected abstract void Action();
    protected abstract void Off();
}
