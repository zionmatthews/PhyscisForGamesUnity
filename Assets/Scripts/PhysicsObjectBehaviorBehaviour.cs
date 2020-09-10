﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObjectBehavior : MonoBehaviour
{
    public Material awakeMaterial = null;
    public Material asleepMaterial = null;

    private Rigidbody _rigidbody = null;
    private Material _material = null;

    private bool wasAsleep = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_rigidbody.IsSleeping() && !wasAsleep && asleepMaterial != null)
        {
            wasAsleep = true;
            _material = asleepMaterial;
        }
        else if (!_rigidbody.IsSleeping() && wasAsleep && awakeMaterial != null)
        {
            wasAsleep = false;
            _material = asleepMaterial;
        }
    }
}