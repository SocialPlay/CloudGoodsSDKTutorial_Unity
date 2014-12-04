using UnityEngine;
using System.Collections;

public class ItemLevelRestriction : MonoBehaviour, IContainerRestriction
{
    public PlayerExperience playerXp;
    public LevelRequirementMessage lvReqMessage;

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
            if (playerXp.level >= levelRequired)
            {
                return true;
            }

            //display message.
            lvReqMessage.DisplayMessage();

            return false;
        }
        
        return true;
    }
}
