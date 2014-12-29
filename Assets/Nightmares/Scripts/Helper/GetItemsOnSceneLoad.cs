using UnityEngine;
using System.Collections;

public class GetItemsOnSceneLoad : MonoBehaviour
{
    PersistentItemContainer persistantContainer;

    void OnLevelWasLoaded(int scene)
    {
        LoadPersistentContainer();
    }

	void Start()
    {
        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
	}

    void CloudGoods_OnUserAuthorized(CloudGoodsUser obj)
    {
        LoadPersistentContainer();
    }

    void LoadPersistentContainer()
    {
        persistantContainer = GetComponent<PersistentItemContainer>();

        if (persistantContainer)
        {
            persistantContainer.LoadItems();
        }
    }
}
