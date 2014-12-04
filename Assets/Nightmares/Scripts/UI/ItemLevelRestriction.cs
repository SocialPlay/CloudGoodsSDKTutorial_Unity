using UnityEngine;
using System.Collections;

public class ItemLevelRestriction : MonoBehaviour, IContainerRestriction
{
    public PlayerExperience playerXp;

    ItemContainer restrictedContainer;

    string lvReqKey = "Level Requirement";
    float levelRequired = 1;

    void Awake()
    {
        restrictedContainer = GetComponent<ItemContainer>();
        restrictedContainer.containerAddRestrictions.Add(this);
    }

    public bool IsRestricted(ContainerAction action, ItemData itemData)
    {
        if (itemData.stats.TryGetValue(lvReqKey, out levelRequired))
        {
            Debug.Log(string.Format("player level: {0}, level required: {1}", playerXp.level, levelRequired));

            if (playerXp.level >= levelRequired)
            {
                return true;
            }

            Debug.Log("Level does not match, level needed: " + levelRequired);
            return false;
        }
        else
        {
            return true;
        }
    }
}
