using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    CanvasRenderer renderer;

    float alphaSpeed = 0.01f;
    float moveSpeed = 0.1f;

    bool showing = false;
    bool waiting = false;
    bool hiding = false;

    float timerWaiting = 0;
    float timeWaiting = 3.3f;

    float alpha = 0;

    void Start()
    {
        renderer = gameObject.GetComponent<CanvasRenderer>();
        setAlpha(0);
    }

    void Update()
    {
        if (showing)
        {
            setAlpha(alpha + alphaSpeed);

            transform.position -= new Vector3(0, moveSpeed, 0);

            if (alpha >= 1.0f)
            {
                showing = false;
                waiting = true;
            }

        }
        else if (waiting)
        {
            timerWaiting += Time.deltaTime;

            if (timerWaiting >= timeWaiting)
            {
                waiting = false;
                hiding = true;
            }
        }
        else if (hiding)
        {
            setAlpha(alpha - alphaSpeed);

            transform.position += new Vector3(0, moveSpeed, 0);

            if (alpha <= 0)
            {
                showing = false;
                waiting = false;
                hiding = false;

                timerWaiting = 0;
            }
        }
    }

    public void Show(string text)
    {
        this.GetComponent<Text>().text = text;
        showing = true;
    }

    void setAlpha(float n)
    {
        renderer.SetAlpha(n);
        alpha = n;
    }
}
