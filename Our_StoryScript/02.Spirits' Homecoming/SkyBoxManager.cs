using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoxManager : MonoBehaviour
{
    public GameObject Lr_02;
    public Material[] skybox;
    Light d_light;
    Color lastColor;
    float time;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "02.Spirits' Homecoming")
        {
            RenderSettings.skybox = skybox[0];

            d_light = GetComponent<Light>();
            d_light.color = new Color(0.88f, 0.83f, 0.66f, 1.0f);
            lastColor = new Color(0.62f, 0.11f, 0.11f, 1.0f);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "02.Spirits' Homecoming")
        {
            if (Lr_02.activeSelf)
            {
                RenderSettings.skybox = skybox[1];
                d_light.color = Color.Lerp(d_light.color, lastColor, Time.deltaTime * 1f);
            }
            // RenderSettings.skybox.SetColor("_Tint", skyColor);

            if (time < 360)
            {
                RenderSettings.skybox.SetFloat("_Rotation", time += 0.01f);
            }
            else time = 0;
        }
        else
        {
            if (time < 360)
            {
                RenderSettings.skybox.SetFloat("_Rotation", time += 0.03f);
            }
            else time = 0;
        }
    }
}
