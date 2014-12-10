using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using SocialPlay.Data;

public class GetItemsContainerInserter : MonoBehaviour, IGetItems
{

    static public GetItemsContainerInserter instance;

    public ItemContainer container;

    public event Action<List<ItemData>> onReciveItems;

    void Awake()
    {
        instance = this;
    }

    public void GetGameItem(List<ItemData> items)
    {

        if (container == null)
            throw new Exception("You must provide a container to your GameItemContainerInserter");
        else
        {
            if (onReciveItems != null)
            {
                onReciveItems(items);
            }

            List<SelectedGenerationItem> giveItems = new List<SelectedGenerationItem>();

            int GenerationID = 0;

            foreach (ItemData item in items)
            {
                if (item.IsGenerated)
                    GenerationID = item.GenerationID;

                //ItemContainerManager.MoveItem(item, null, container);        

                Debug.Log("start giving item to user: ID: " + item.ItemID);

                SelectedGenerationItem selectItem = new SelectedGenerationItem();

                selectItem.ItemId = item.ItemID;
                selectItem.Amount = item.stackSize;

                giveItems.Add(selectItem);
            }

            if(GenerationID != 0)
                CloudGoods.GiveGeneratedItemToOwner("User", giveItems, GenerationID, container.GetComponentInChildren<PersistentItemContainer>().Location, OnReceivedGiveItemGenerationItemResult);
        }
    }

    void OnReceivedGiveItemGenerationItemResult(List<GiveGeneratedItemResult> itemResults)
    {
        Debug.Log("Finished giving generationItems");
        //container.RefreshContainer();

        container.UpdateContainerWithItems(itemResults);

    }

}