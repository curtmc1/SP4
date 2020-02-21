﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryLaser : MonoBehaviour
{
    private float lifetime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
            Destroy(this.gameObject);
    }
}
