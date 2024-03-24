using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MECBGUN : MonoBehaviour
{
    public Vector3 offsetRotacao = new Vector3(90f, 0f, 0f);

    public GrabSystem grabSystem;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (grabSystem != null && grabSystem.grabbedObject != null)
        {
            switch (itemName)
            {
                case "taco":
                    UseTacoMechanic();
                    break;
               
                default:
                    Debug.Log("Não foi implementada uma mecânica para o item: " + itemName);
                    break;
            }
        }

     
       
    }

    void UseTacoMechanic()
    {
         if (Input.GetMouseButton(0))
                {
            
                    Debug.Log("WORKINGG");
                    transform.rotation = grabSystem.HANDPOS.rotation * Quaternion.Euler(offsetRotacao);

                }
    }
}
