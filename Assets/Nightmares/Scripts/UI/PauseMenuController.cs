using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
    Animator animator;

    bool animatorShowPanel = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (PauseManager.IsPaused)
        {
            if (!animator.IsInTransition(0) && !animatorShowPanel)
            {
                animatorShowPanel = true;
                animator.SetTrigger("Show Panel");
            }
        }
        else
        {
            if (!animator.IsInTransition(0) && animatorShowPanel)
            {
                animatorShowPanel = false;
                animator.SetTrigger("Hide Panel");
            }
        }
    }
}
