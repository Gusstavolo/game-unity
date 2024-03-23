using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MECBGUN : MonoBehaviour
{
    
    private Rigidbody rb;
    private FallowHand hand;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<FallowHand>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Console.WriteLine("aaaaaaaaaaaaa");
        }
    }
}
