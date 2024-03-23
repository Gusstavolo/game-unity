using UnityEngine;

public class Item : GrabSystem
{
    public string itemName;
    private Rigidbody rb;
    // Outros atributos comuns para todos os itens
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Use()
    {
        // Implemente a lógica para usar o item aqui
        if(grabbedObject != null) { 

                    switch (itemName)
            {
                case "taco":
                    UseTacoMechanic();
                    break;
                case "espada":
                    UseEspadaMechanic();
                    break;
                default:
                    Debug.Log("Não foi implementada uma mecânica para o item: " + itemName);
                    break;
            }
        }
    }

    void UseTacoMechanic()
    {
        // Implemente a mecânica específica para o item "taco" aqui
        Debug.Log("Utilizando a mecânica para o item 'taco'.");
        if(Input.GetMouseButtonDown(0)) { 
        transform.rotation = HANDPOS.rotation * Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
    }

    void UseEspadaMechanic()
    {
        // Implemente a mecânica específica para o item "espada" aqui
        Debug.Log("Utilizando a mecânica para o item 'espada'.");
    }
}
