using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inheritance : Pillar
{
    [SerializeField]
    private List<GameObject> inheritPillars = new();
    private float pillarMovementSpeed = 1.0f;
    private bool pillarMovementDirection;
    private Vector3 initialInheritPillarsPosition;
    float distanceFromMainPillar;
    // Start is called before the first frame update
    void Start()
    {
        initialInheritPillarsPosition = inheritPillars[0].transform.position;
        distanceFromMainPillar = Vector3.Distance(transform.position, inheritPillars[0].transform.position);
    }
    void SetPillarsActive(bool value)
    {
        for (int i = 0; i < inheritPillars.Count; i++)
        {
            inheritPillars[i].SetActive(value);
        }
    }
    void MovePillars(bool direction)
    {
        int varDirection = direction ? 1 : -1;

        inheritPillars[0].transform.Translate(pillarMovementSpeed * Time.deltaTime * varDirection * (Vector3.forward + Vector3.right));
        inheritPillars[1].transform.Translate(pillarMovementSpeed * Time.deltaTime * varDirection * (-Vector3.forward + Vector3.right));
        inheritPillars[2].transform.Translate(pillarMovementSpeed * Time.deltaTime * varDirection * (Vector3.forward + -Vector3.right));
        inheritPillars[3].transform.Translate(pillarMovementSpeed * Time.deltaTime * varDirection * (-Vector3.forward + -Vector3.right));
    }
    protected override void Action()
    {
        SetPillarsActive(true);
        float distanceFromMainPillar = Vector3.Distance(transform.position, inheritPillars[0].transform.position);
        
        if (distanceFromMainPillar >= 2.75f)
        {
            pillarMovementDirection = false;
        }
        if (distanceFromMainPillar <= 1.6f)
        {
            pillarMovementDirection = true;
        }
        MovePillars(pillarMovementDirection);
    }
    protected override void Off()
    {
        float distanceFromMainPillar = Vector3.Distance(transform.position, inheritPillars[0].transform.position);
        
        if (distanceFromMainPillar >= 1.501f)
        {
            MovePillars(false);
        }
        else
        {
            SetPillarsActive(false);
        }
    }
}
