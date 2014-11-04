using UnityEngine;
using System.Collections;

public class DisplayStorePanel : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenStore()
    {
        if (!anim.IsInTransition(0))
        {
            anim.SetTrigger("Store Open");
        }
    }

    public void CloseStore()
    {
        if (!anim.IsInTransition(0))
        {
            anim.SetTrigger("Store Closed");
        }
    }
}
