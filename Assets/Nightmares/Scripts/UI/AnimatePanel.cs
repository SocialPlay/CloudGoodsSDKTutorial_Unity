using UnityEngine;
using System.Collections;

public class AnimatePanel : MonoBehaviour
{
    string showPanelTrigger = "Show Panel";
    string hidePanelTrigger = "Hide Panel";

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowPanel()
    {
        if (!anim.IsInTransition(0))
        {
            anim.SetTrigger(showPanelTrigger);
        }
    }

    public void HidePanel()
    {
        if (!anim.IsInTransition(0))
        {
            anim.SetTrigger(hidePanelTrigger);
        }
    }
}
