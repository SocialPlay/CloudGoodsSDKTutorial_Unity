using UnityEngine;
using System.Collections;

public class EnemyItemDrop : MonoBehaviour {
    public GameObject itemDropperPrefab;
    public Vector3 itemDropPoint;
    public int maxItemDropEnergy;

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
        Vector3 dropPoint = transform.position;
        dropPoint += itemDropPoint;

        GameObject item = Instantiate(itemDropperPrefab, dropPoint, Quaternion.identity) as GameObject;
        ItemGetter itemGetter = item.GetComponent<ItemGetter>();

        itemGetter.MaxEnergy = maxItemDropEnergy;
        itemGetter.GetItems();
    }
}
