using UnityEngine;
using System.Collections;

public class PlayerPickUp : MonoBehaviour {
    public ItemContainer itemContainer;

    void OnTriggerEnter(Collider dropItem)
    {
        if (dropItem.CompareTag("DropItem"))
        {
            PickUpItem(dropItem.gameObject);
        }
    }

    void PickUpItem(GameObject itemObject)
    {
        ItemData itemData = itemObject.GetComponent<ItemDataComponent>().itemData;

        ItemContainerManager.MoveItem(itemData, null, itemContainer);

        Destroy(itemObject);
    }
}
