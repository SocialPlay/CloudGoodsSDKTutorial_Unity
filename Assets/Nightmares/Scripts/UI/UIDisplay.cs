using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDisplay : MonoBehaviour
{
    public RectTransform uiRectTransform;
    public float hidePositionY;
    public float transitionTime = 3;
    public bool showOnPause = true;

    float showPositionY;

    Vector3 rectPosition = new Vector3();

    internal bool isUIDisplayed = false;

    void Start()
    {
        rectPosition = uiRectTransform.position;

        showPositionY = rectPosition.y;
        rectPosition.y = hidePositionY;
    }

    void Update()
    {
        if (showOnPause)
        {
            isUIDisplayed = PauseManager.IsPaused;
        }

        UIReposition();
    }

    private void UIReposition()
    {
        if (isUIDisplayed)
        {
            if (rectPosition.y <= showPositionY)
            {
                rectPosition.y += Time.deltaTime * (transitionTime * 1000);

                if (rectPosition.y > showPositionY)
                {
                    rectPosition.y = showPositionY;
                }
            }
        }
        else
        {
            if (rectPosition.y >= hidePositionY)
            {
                rectPosition.y -= Time.deltaTime * (transitionTime * 1000);
            }

            if (rectPosition.y < hidePositionY)
            {
                rectPosition.y = hidePositionY;
            }
        }

        uiRectTransform.position = rectPosition;
    }

    public void DisplayUI()
    {
        PauseManager.IsPauseDisabled = !isUIDisplayed;
        isUIDisplayed = !isUIDisplayed;
    }
}
