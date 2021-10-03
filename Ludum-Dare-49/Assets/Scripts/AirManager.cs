using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirManager : MonoBehaviour
{
    // Singleton
    private static AirManager _instance;
    public static AirManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AirManager>();
            }

            return _instance;
        }
    }

    public GameObject Air;
    private IEnumerator coroutine;
    private float secondForAir = 5f;
    private float spawnerTimer = 0f;
    private int air = 0;

    private void Update()
    {
        StartAirLeft();
        spawnerTimer += Time.deltaTime;
        if (spawnerTimer >= secondForAir)
        {
            spawnerTimer = 0f;
            StartAirLeft();
        }
    }

    public int getTypeAir()
    {
        return air;
    }

    public void StartAirRandomly()
    {
        int whatToChoose = Random.Range(1, 5);
        Debug.Log(whatToChoose);
        if (whatToChoose == 1 && whatToChoose == 2)
        {
            StopAir();
        }
        else if (whatToChoose == 3)
        {
            StartAirRight();
        }
        else
        {
            StartAirLeft();
        }
    }

    public void StartAirLeft()
    {
        air = 2;
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = Left(0.5f,-1.5f);
        StartCoroutine(coroutine);
    }

    public void StartAirRight()
    {
        air = 1;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = Right(0.5f,1.5f);
        StartCoroutine(coroutine);
    }

    public void StopAir()
    {
        air = 0;
        if (coroutine != null)
            StopCoroutine(coroutine);
        if (Air.GetComponent<AreaEffector2D>().forceMagnitude > 0)
            coroutine = Left(0.5f, 0f);
        else
            coroutine = Right(0.5f, 0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator Right(float waitTime, float whereToStop)
    {
        AreaEffector2D air = Air.GetComponent<AreaEffector2D>();
        while (air.forceMagnitude < whereToStop)
        {
            air.forceMagnitude += Time.deltaTime / waitTime;
            yield return null;
        }
        air.forceMagnitude = whereToStop;
    }
    
    public IEnumerator Left(float waitTime, float whereToStop)
    {
        AreaEffector2D air = Air.GetComponent<AreaEffector2D>();
        while (air.forceMagnitude > whereToStop)
        {
            air.forceMagnitude -= Time.deltaTime / waitTime;
            yield return null;
        }
        air.forceMagnitude = whereToStop;
    }



}
