using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform handAnchor; // Ponto de ancoragem para as m�os do personagem
    private GameObject carriedItem; // Item atualmente carregado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // Verifica se o objeto � um item
        {
            // Exemplo: Detectou um item, pressione a tecla "E" para peg�-lo
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpItem(other.gameObject);
            }
        }
    }

    private void PickUpItem(GameObject item)
    {
        // Desativa a f�sica do item para que ele n�o caia
        item.GetComponent<Rigidbody>().isKinematic = true;

        // Move o item para a posi��o das m�os
        item.transform.position = handAnchor.position;
        item.transform.parent = handAnchor; // Torna o item filho do ponto de ancoragem

        carriedItem = item;
    }

    private void DropItem()
    {
        if (carriedItem != null)
        {
            // Ativa a f�sica do item novamente
            carriedItem.GetComponent<Rigidbody>().isKinematic = false;

            // Remove o item do ponto de ancoragem
            carriedItem.transform.parent = null;

            carriedItem = null;
        }
    }

    private void Update()
    {
        // Exemplo: Pressione a tecla "Q" para largar o item
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
    }
}
