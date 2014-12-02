using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPickUp : MonoBehaviour {

    public ItemContainer itemContainer;

    PlayerExperience playerExp;

    void Start()
    {
        playerExp = GetComponent<PlayerExperience>();
    }

    void OnTriggerEnter(Collider dropItem)
    {
        switch (dropItem.tag)
        {
            case "DropItem":
                PickUpItem(dropItem.gameObject);
                break;
            case "XpDrop":
                PickUpExperience(dropItem.gameObject);
                break;
            default:
                break;
        }
    }

    void PickUpItem(GameObject itemObject)
    {
        ItemData itemData = itemObject.GetComponent<ItemDataComponent>().itemData;

        ItemContainerManager.MoveItem(itemData, null, itemContainer);

        Destroy(itemObject);
    }

    void PickUpExperience(GameObject xpObject)
    {
        playerExp.AddExperience();

        xpObject.GetComponent<DroppedExperience>().ReceivedExperience();
    }
}
