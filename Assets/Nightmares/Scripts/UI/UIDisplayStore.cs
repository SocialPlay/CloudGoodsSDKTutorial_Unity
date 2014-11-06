using UnityEngine;
using System.Collections;

public class UIDisplayStore : MonoBehaviour
{
    public StoreInitializer storeInitializer;

    public void ToggleStore()
    {
        storeInitializer.InitializeStore();
    }
}
