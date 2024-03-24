using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    private GrabSystem grabSystem;

    void Start()
    {
        // Obtendo o componente GrabSystem do mesmo GameObject
        grabSystem = GetComponent<GrabSystem>();
        if (grabSystem == null)
        {
            Debug.LogError("GrabSystem n�o encontrado no GameObject pai de: " + gameObject.name);
        }
    }

    public void Use()
    {
        // Verifica se um objeto est� sendo agarrado antes de usar o item
        if (grabSystem != null && grabSystem.grabbedObject != null)
        {
            switch (itemName)
            {
                case "taco":
                    UseTacoMechanic();
                    break;
                case "espada":
                    UseEspadaMechanic();
                    break;
                default:
                    Debug.Log("N�o foi implementada uma mec�nica para o item: " + itemName);
                    break;
            }
        }
    }

    public void UseTacoMechanic()
    {
        // Verifica se o bot�o do mouse est� sendo pressionado
        if (Input.GetMouseButton(0))
        {
            // Rotaciona o objeto agarrado (supondo que este Item seja o pr�prio GameObject deste script)
            grabSystem.grabbedObject.transform.rotation = grabSystem.HANDPOS.rotation * Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
    }

    public void UseEspadaMechanic()
    {
        // Implemente a mec�nica espec�fica para o item "espada" aqui
        Debug.Log("Utilizando a mec�nica para o item 'espada'.");
    }
}
