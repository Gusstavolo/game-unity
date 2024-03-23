using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform handAnchor; // Ponto de ancoragem para as mãos do personagem
    private GameObject carriedItem; // Item atualmente carregado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // Verifica se o objeto é um item
        {
            // Exemplo: Detectou um item, pressione a tecla "E" para pegá-lo
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpItem(other.gameObject);
            }
        }
    }

    private void PickUpItem(GameObject item)
    {
        // Desativa a física do item para que ele não caia
        item.GetComponent<Rigidbody>().isKinematic = true;

        // Move o item para a posição das mãos
        item.transform.position = handAnchor.position;
        item.transform.parent = handAnchor; // Torna o item filho do ponto de ancoragem

        carriedItem = item;
    }

    private void DropItem()
    {
        if (carriedItem != null)
        {
            // Ativa a física do item novamente
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
