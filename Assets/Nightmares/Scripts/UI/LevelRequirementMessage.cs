using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelRequirementMessage : MonoBehaviour
{
    AutoTimer startColorFade = new AutoTimer(0);
    Color colorModifier;
    Text ui;

    void Start()
    {
        ui = GetComponent<Text>();

        initUiColor();
    }

    void initUiColor()
    {
        colorModifier = ui.color;
        colorModifier.a = 0;

        ui.color = colorModifier;
    }

    void Update()
    {
        if (startColorFade.IsDone() && ui.color.a > 0)
        {
            colorModifier.a -= 2 * Time.deltaTime;

            ui.color = colorModifier;
        }
    }

    public void DisplayMessage()
    {
        startColorFade.Reset(3);

        colorModifier.a = 1;
        ui.color = colorModifier;
    }
}
