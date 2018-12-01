using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public Text text1;
    public Text text2;

    public void SetText(string text, int n)
    {
        if (n == 1)
        {
            text1.GetComponent<TextScript>().Show(text);
        }

        if (n == 2)
        {
            text2.GetComponent<TextScript>().Show(text);
        }
    }
}
