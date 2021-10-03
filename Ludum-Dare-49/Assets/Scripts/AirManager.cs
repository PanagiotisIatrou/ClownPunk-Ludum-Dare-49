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
    private IEnumerator coroutine;

    public GameObject Air;

    public void StartAirLeft()
    {
        coroutine = Left(0.5f);
    }

    private IEnumerator Left(float waitTime)
    {
        AreaEffector2D air = Air.GetComponent<AreaEffector2D>();
        while (air.forceMagnitude < 2f)
        {
            air.forceMagnitude += Time.deltaTime / waitTime;
            yield return null;
        }
        air.forceMagnitude = 2f;
    }

    public void StartAirRight()
    {
        while (Air.GetComponent<AreaEffector2D>().forceMagnitude > -2f)
        {
            Air.GetComponent<AreaEffector2D>().forceMagnitude -= Time.deltaTime;
        }
    }

    public void StartAirRandomly()
    {

    }

    public void StopAir()
    {
        while (Air.GetComponent<AreaEffector2D>().forceMagnitude != 0)
        {
            if (Air.GetComponent<AreaEffector2D>().forceMagnitude > 0)
                Air.GetComponent<AreaEffector2D>().forceMagnitude -= Time.deltaTime;
            else
                Air.GetComponent<AreaEffector2D>().forceMagnitude += Time.deltaTime;
        }
    }
}
