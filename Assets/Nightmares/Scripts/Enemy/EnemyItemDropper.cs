using UnityEngine;
using System.Collections;

public class EnemyItemDropper : MonoBehaviour
{
    public GameObject itemDropPrefab;
    public Vector3 dropItemOffsetPosition;
    public int maxDroppedItemEnergy;

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
                DropItems();
            }
        }
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
}
