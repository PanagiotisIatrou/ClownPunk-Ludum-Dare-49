using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed = 0.1f;
    private IEnumerator coroutine;

    private void Update()
    {
        if (AirManager.Instance.getTypeAir() == 0)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = Right(0.1f);
            StartCoroutine(coroutine);
        }
        else if(AirManager.Instance.getTypeAir() == 1)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = Right(0.3f);
            StartCoroutine(coroutine);
        }
        else
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = Left(-0.3f);
            StartCoroutine(coroutine);
        }
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public IEnumerator Left(float whereToStop)
    {
        while (speed > whereToStop)
        {
            speed -= Time.deltaTime ;
            yield return null;
        }
        speed = whereToStop;
    }

    public IEnumerator Right(float whereToStop)
    {
        while (speed > whereToStop)
        {
            speed += Time.deltaTime;
            yield return null;
        }
        speed = whereToStop;
    }
}
