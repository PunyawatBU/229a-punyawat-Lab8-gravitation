using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody rb;
    private const float G = 0.0674f;
    public static List<Gravity> gravityObjectList;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectList == null)
        {
            gravityObjectList = new List<Gravity>();
        }
        
        gravityObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in gravityObjectList)
        {
            Attract(obj);
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        if (distance == 0) { return; }

        float forceMagnitude = G * (rb.mass * rbOther.mass)/ Mathf.Pow(distance,2);

        Vector3 force = forceMagnitude * direction.normalized;
        rbOther.AddForce(force);

    }
}
