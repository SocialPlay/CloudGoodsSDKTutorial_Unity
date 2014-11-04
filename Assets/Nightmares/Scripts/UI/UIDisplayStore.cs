using UnityEngine;
using System.Collections;

public class UIDisplayStore : MonoBehaviour
{
    public UIDisplay uiDisplay;
    public DisplayStoreItems displayStoreItems;
    public UnityUIDisplayItemBundles displayItemBundles;

    public void ToggleStore()
    {
        uiDisplay.DisplayUI();

        if (uiDisplay.isUIDisplayed)
        {
            displayStoreItems.DisplayItems();
            displayItemBundles.GetItemBundles();

            CloudGoods.GetStandardCurrencyBalance(0, null);
            CloudGoods.GetPremiumCurrencyBalance(null);
        }
    }
}
