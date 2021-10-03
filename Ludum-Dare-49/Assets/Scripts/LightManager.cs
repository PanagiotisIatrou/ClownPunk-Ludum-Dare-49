using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Singleton
    private static LightManager _instance;
    public static LightManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LightManager>();
            }

            return _instance;
        }
    }

    UnityEngine.Experimental.Rendering.Universal.Light2D lt1;
    UnityEngine.Experimental.Rendering.Universal.Light2D lt2;
    float duration = 2f;
    Color color0 = new Color(0.945098f, 0.3476057f, 0f);
    Color color1 = new Color(1f, 0f, 0F);
    private float timeOn = 0.1f;
    private float timeOff = 0.1f;
    private float changeTime = 0f;
    private bool flage = false;

    public GameObject specialEffects;
    public GameObject lights1;
    public GameObject lights2;
    
    private float intensityGoal=22f;
    private float intensity;
    // Start is called before the first frame update
    void Start()
    {
        lt1 = lights1.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        lt2 = lights2.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        intensity = lt1.intensity;
        specialEffects.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.deltaTime, duration) / duration;
        lt1.color = Color.Lerp(color1, color0, t);
        lt2.color = Color.Lerp(color1, color0, t);

        if (flage == false)
        {
            lt1.enabled = true;
            lt2.enabled = true;
            specialEffects.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            flickering();
            Debug.Log(specialEffects.GetComponent<ParticleSystem>());
            specialEffects.GetComponent<ParticleSystem>().Play();
        }


        if (intensity >= intensityGoal && intensityGoal == 22f)
        {
            intensity -= 0.01f;
        }
        else if (intensity <= intensityGoal && intensityGoal == 28f)
        {
            intensity += 0.01f;
        }
        else if (intensityGoal == 22f)
        {
            intensityGoal = 28f;
        }
        else if (intensityGoal == 28f)
        {
            intensityGoal = 22f;
        }

        lt1.intensity = intensity;
        lt2.intensity = intensity;
    }

    public void flickeringOn()
    {
        flage = true;
    }

    public void flickeringOff()
    {
        flage = false;
    }

    public void flickering()
    {
        if (Time.time > changeTime)
        {
            lt1.enabled = !lights1.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled;
            lt2.enabled = !lights2.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled;
            if (lt1.enabled)
            {
                changeTime = Time.time + timeOn;
            }
            else
            {
                changeTime = Time.time + timeOff;
            }
        }
    }
}
