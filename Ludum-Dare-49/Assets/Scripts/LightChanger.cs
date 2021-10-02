using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightChanger : MonoBehaviour
{
    UnityEngine.Experimental.Rendering.Universal.Light2D lt;
    float duration = 2f;
    Color color0 = new Color(0.945098f, 0.3476057f,0f);
    Color color1 = new Color(1f, 0f, 0F);
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color1, color0, t);
    }
}
