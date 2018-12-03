using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBlackScript : MonoBehaviour
{

    bool unblackening = false;
    CanvasRenderer renderer;
    float step = 0.007f;

    void Awake()
    {
        renderer = gameObject.GetComponent<CanvasRenderer>();

    }

    public void Unblacken()
    {
        unblackening = true;
    }

    public void Alpha1()
    {
        unblackening = false;
        renderer.SetAlpha(1);
    }

    void Update()
    {
        if (unblackening)
        {
            renderer.SetAlpha(renderer.GetAlpha() - step);
        }
    }
}
