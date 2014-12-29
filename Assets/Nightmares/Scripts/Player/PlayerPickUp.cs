using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerPickUp : MonoBehaviour
{

    public ItemContainer itemContainer;

    PlayerExperience playerExp;
    PlayerEffects playerFX;

    void Start()
    {
        playerExp = GetComponent<PlayerExperience>();
        playerFX = GetComponent<PlayerEffects>();
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
        ItemDataComponent item = itemObject.GetComponent<ItemDataComponent>();

        Debug.Log("itemData class ID: " + item.itemData.classID);
        if (item.itemData.classID == 4321)
        {
            ApplyInstantUse(item.itemData, itemObject);
        }
        else
        {
            ItemContainerManager.MoveItem(item.itemData, null, itemContainer);

            Destroy(itemObject);
        }
    }

    void ApplyInstantUse(ItemData itemData, GameObject itemObject)
    {
        switch (itemData.itemName.ToLower())
        {
            case "life up":
                if (!playerFX.canPlayerBeHealed()) break;

                float lifeUpPower = GetItemDataStatValue(itemData.stats, "Power");

                playerFX.HealPlayer(Mathf.RoundToInt(lifeUpPower / 2));

                Destroy(itemObject);
                break;
            case "speed up":
                if (!playerFX.canPlayerGetSpeedUp()) break;

                float speedPower = GetItemDataStatValue(itemData.stats, "Power");

                playerFX.SetPlayerSpeed(speedPower / 6);

                Destroy(itemObject);
                break;
        }
    }

    float GetItemDataStatValue(Dictionary<string, float> stats, string value)
    {
        float power = 0;

        if (stats.TryGetValue(value, out power))
        {
            return power;
        }
        else
        {
            Debug.LogError("Unable to get value: " + value + ", from item data stats.");
        }

        return power;
    }

    void PickUpExperience(GameObject xpObject)
    {
        playerExp.AddExperience();

        xpObject.GetComponent<DroppedExperience>().ReceivedExperience();
    }
}
