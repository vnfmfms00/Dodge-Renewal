﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProperties : MonoBehaviour
{
    public GameObject bullet;
    private float timeToDead;
    void Start()
    {
        timeToDead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDead += Time.deltaTime;
        if(timeToDead >= 1.5)
        {
            Destroy(bullet);
        }
    }
}
