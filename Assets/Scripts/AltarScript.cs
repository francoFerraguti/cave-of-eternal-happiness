using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarScript : MonoBehaviour
{
    Renderer renderer;
    bool blackening = false;
    bool moving = false;

    float movementSpeed = 12.0f;


    void Awake()
    {
        renderer = this.GetComponent<Renderer>();
    }

    void Update()
    {
        blacken();
        move();
    }

    void move()
    {
        if (!moving)
        {
            return;
        }

        transform.Translate(-Vector3.up * Time.deltaTime * movementSpeed, Space.World);

        if (transform.position.y <= -100.0f)
        {
            moving = false;
        }
    }

    void blacken()
    {
        if (!blackening)
        {
            return;
        }
        var currentColor = renderer.material.GetColor("_ReflectColor");
        renderer.material.SetColor("_ReflectColor", currentColor - new Color(0.01f, 0.01f, 0.01f, 0));

        if (currentColor.r <= 0 || currentColor.g <= 0 || currentColor.b <= 0)
        {
            renderer.material.SetColor("_ReflectColor", new Color(0, 0, 0, 1));
            blackening = false;
        }
    }

    public void SetBlackening()
    {
        blackening = true;
    }

    public void SetMoving()
    {
        moving = true;
    }
}
