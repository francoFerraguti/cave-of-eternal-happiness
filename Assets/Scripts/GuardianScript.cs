using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianScript : MonoBehaviour
{

    Renderer renderer;

    float timer = 0;

    float timeToScale = 0.4f;
    float scaleSpeed = 0.0015f;
    bool hasScaled = false;

    float timeToPosition = 0.4f;
    float movementSpeed = 4.0f;
    bool hasPositioned = false;
    Vector3 fixedPosition;

    float horizontalRotationSpeed = 90f;


    void Update()
    {
        timer += Time.deltaTime;

        updateScale();
        updatePosition();
        updateHorizontalRotation();
        updateSine();
    }

    void updateSine()
    {
        if (hasPositioned)
        {
            transform.position = fixedPosition + new Vector3(0.0f, -Mathf.Sin(timer) * 2, 0.0f);
        }
    }

    void updateScale()
    {
        if (timer >= timeToScale && !hasScaled)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
            if (transform.localScale.x >= 0.7f)
            {
                hasScaled = true;
            }
        }
    }
    void updatePosition()
    {
        if (timer >= timeToPosition && !hasPositioned)
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed, Space.World);

            if (transform.position.y >= 62)
            {
                fixedPosition = transform.position;
                hasPositioned = true;
            }
        }
    }
    void updateHorizontalRotation()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * horizontalRotationSpeed);
    }
}
