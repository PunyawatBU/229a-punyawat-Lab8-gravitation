using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody rb;
    private const float G = 0.00674f;
    public static List<Gravity> GravityObjectList;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (GravityObjectList == null)
        {
            GravityObjectList = new List<Gravity>();
        }
        
        GravityObjectList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (var obj in GravityObjectList)
        {
            Attract(obj);
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody rbOther = GetComponent<Rigidbody>();

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        if (distance == 0) { return; }

        float forceMagnitude = G * (rb.mass * rbOther.mass)/ Mathf.Pow(distance,2);

        Vector3 force = forceMagnitude * direction.normalized;

    }
}
