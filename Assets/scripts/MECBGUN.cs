using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINGUN : MonoBehaviour
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
        GameObject objToGrab = GetObjectToGrab(); // Lógica para obter o objeto a ser agarrado
        string itemName = GetItemName(); // Lógica para obter o nome do item
        grabSystem.GrabObject(objToGrab, itemName);
        if (itemName == "taco" && grabSystem.isGrabbingHAND == true)
        {
            UseTacoMechanic();
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
    void UseAMechanic()
{

}
    public void GrabObject(GameObject obj, string itemName)
    {
        grabSystem.grabbedObject = obj;

        MAINGUN mainGun = grabSystem.grabbedObject.GetComponent<MAINGUN>();
        if (mainGun != null)
        {
            mainGun.itemName = itemName;
        }

        // Aqui você pode adicionar qualquer outra lógica relacionada a pegar objetos, como desativar a física do objeto, etc.
    }
}