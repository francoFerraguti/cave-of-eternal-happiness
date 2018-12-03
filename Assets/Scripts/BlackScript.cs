using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackScript : MonoBehaviour
{
    CanvasRenderer renderer;
    float step = 0.007f;

    void Awake()
    {
        renderer = gameObject.GetComponent<CanvasRenderer>();
        renderer.SetAlpha(0);
    }

    public void Advance()
    {
        renderer.SetAlpha(renderer.GetAlpha() + step);

        if (renderer.GetAlpha() >= 1.0f)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}
