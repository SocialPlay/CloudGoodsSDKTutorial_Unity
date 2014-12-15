using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GenerationItemPackage : MonoBehaviour {

    public int GenerationID;
    public int Location;
    public string UserType;

    public ItemContainer targetContainer;

    List<SelectedGenerationItem> selectedItems = new List<SelectedGenerationItem>();

    bool isGenerateTimerStarted = false;
    bool hasSentPackage = false;

    float timer = 0.0f;
    float maxSendPackageTimer = 2.0f;

    public bool HasPackageBeenSent()
    {
        return hasSentPackage;
    }

    public void InitializeItemIDs(SelectedGenerationItem selectedItem)
    {
        selectedItems.Add(selectedItem);

        if (!isGenerateTimerStarted)
            isGenerateTimerStarted = true;
    }

    public void AddItemID(SelectedGenerationItem selectedItem)
    {
        SelectedGenerationItem generationItem = selectedItems.Find(x => x.ItemId == selectedItem.ItemId);

        if(generationItem != null)
            generationItem.Amount += selectedItem.Amount;
        else
            selectedItems.Add(selectedItem);

        Debug.Log("Item ID: " + selectedItem.ItemId + " with amount: " + selectedItem.Amount + "  has been added to generation package: " + GenerationID);
    }

    void Update()
    {
        if (isGenerateTimerStarted && !hasSentPackage)
        {
            timer += Time.deltaTime;

            if (timer >= maxSendPackageTimer)
            {
                Debug.Log("Generation Items Sent Package ID: " + GenerationID);
                CloudGoods.GiveGeneratedItemToOwner(UserType, selectedItems, GenerationID, Location, OnReceivedGiveItemGenerationItemResult);
                hasSentPackage = true;
            }
        }
    }

    void OnReceivedGiveItemGenerationItemResult(List<GiveGeneratedItemResult> itemResults)
    {
        Debug.Log("Finished giving generationItems");

        targetContainer.UpdateContainerWithItems(itemResults);

    }

}
