using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private float shakeTimeRemaining, shakePower, shakeFadeTime;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StarterShake(.2f,.2f);
        }
    }
    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmout = Random.Range(-1f, 1f) * shakePower;
            float yAmout = -Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmout, yAmout, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
        }
    }

    public void StarterShake(float lenght,float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;
        shakeFadeTime = power / lenght;
    }
}
