using UnityEngine;
using System.Collections;

public class GetItemsOnSceneLoad : MonoBehaviour
{
    PersistentItemContainer persistantContainer;

	void Start()
    {
        persistantContainer = GetComponent<PersistentItemContainer>();

        if (persistantContainer)
        {
            persistantContainer.LoadItems();
        }
	}
}
