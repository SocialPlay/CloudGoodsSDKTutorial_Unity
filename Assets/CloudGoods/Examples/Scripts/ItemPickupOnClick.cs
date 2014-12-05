using UnityEngine;
using System.Collections;

public class ItemPickupOnClick : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                hit.collider.gameObject.GetComponent<ItemDataComponent>().Pickup(true);
            }
        }
	}
}
