﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasBeenCheck : MonoBehaviour
{
    [Header ("Show in Inspector")]

    bool hasEntered = false;
    GameObject currentSquare;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        hasEntered = true;
    }
}