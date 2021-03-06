using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoaderTextControl : MonoBehaviour
{
    public string textValue1, textValue2;
    public Text textElement1, textElement2;
    void Start()
    {
        if (GameControlManage.punched)
        {
            GameControlManage.punched = false;
            textValue1 = "Don't worry... it's ok.\n Reloading Level: ";
        }
        else
        {
            textValue1 = "Loading Level: ";
        }
        textValue1 += GameControlManage.level + ".\n";
        textValue2 = "\nRemember: The size of the map,the nubmer of enemies and their strength will upgrade as you complete every level. " + ((GameControlManage.level >= 5) ? "\n" : "") + "So it will just become harder to you (and to your PC to render all this mess) from a level to level.";
        if (GameControlManage.level >= 5)
        {
            textValue2 += "\n\nHint: It's not always about running and fighting... sometimes all you need is just to relax and explore the world... maybe there's something more ;).";
        }
        textElement1.text = textValue1;
        textElement2.text = textValue2;
    }
}





