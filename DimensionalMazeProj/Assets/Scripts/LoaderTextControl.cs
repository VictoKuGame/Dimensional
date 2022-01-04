using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoaderTextControl : MonoBehaviour
{
    public string textValue;
    public Text textElement;
    void Start()
    {
        /*if (GameControlManage.level == 1)
        {
            textValue = "Congratulations, you've finished your tutorial.\nNow, lets generate a random maze.\nWait a sec....";
        }
        */
        textValue = "Loading Level: " + GameControlManage.level + ".\n\nRemember: The size of the map,the nubmer of enemies and their strength will upgrade as you complete every level.\n So it will just become harder to you (and to your PC to render all this mess) from a level to level.";
        if (GameControlManage.level >= 5)
        {
            textValue += "\n\nHint:\n It's not always about running and fighting... sometimes all you need is just to relax and explore the world... maybe there's something more ;).";
        }
        textElement.text = textValue;
    }
}





