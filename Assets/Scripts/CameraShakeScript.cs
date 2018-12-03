using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour
{
    public Transform camTransform;

    public float shakeDuration = 0.3f;

    public float shakeAmount = 0.9f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    bool shaking = false;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public void SetShaking(float duration)
    {
        originalPos = camTransform.localPosition;
        shakeDuration = duration;
        shaking = true;
    }

    void Update()
    {
        if (!shaking)
        {
            return;
        }

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0;
            shaking = false;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
