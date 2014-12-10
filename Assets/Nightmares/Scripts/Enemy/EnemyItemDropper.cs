using UnityEngine;
using System.Collections;

public class EnemyItemDropper : MonoBehaviour
{
    public GameObject itemDropPrefab;
    public GameObject expDropPrefab;
    public Vector3 dropItemOffsetPosition;
    public int maxDroppedItemEnergy;
    public int numberOfExperienceDrops = 3;

    EnemyHealth enemyHealth;
    bool gotItem = false;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (!gotItem && enemyHealth != null)
        {
            if (enemyHealth.isDead)
            {
                gotItem = true;

                DropExperience();

                if (ItemDropChance()) DropItems();
            }
        }
    }

    bool ItemDropChance()
    {
        int dropChance = Random.Range(0, 10);

        if (dropChance <= 1 || dropChance >= 10)
        {
            return true;
        }

        return false;
    }

    void DropItems()
    {
        Vector3 itemDropPosition = transform.position;
        itemDropPosition += dropItemOffsetPosition;

        GameObject nightmareItemGenerator = Instantiate(itemDropPrefab, itemDropPosition, Quaternion.identity) as GameObject;
        ItemGenerator itemGenerator = nightmareItemGenerator.GetComponent<ItemGenerator>();

        itemGenerator.MaxEnergy = maxDroppedItemEnergy;
        itemGenerator.GenerateItems();
    }

    void DropExperience()
    {
        Vector3 dropPos = transform.position;
        dropPos += Vector3.up * 2;

        int randomModifier = Random.Range(numberOfExperienceDrops - 3, numberOfExperienceDrops + 3);

        for (int i = 0; i < randomModifier; i++)
        {
            Instantiate(expDropPrefab, dropPos, Quaternion.identity);
        }
    }
}
