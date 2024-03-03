using System;
using UnityEngine;


[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light dirLight;
    [SerializeField] private LightPreset preset;
    [SerializeField, Range(0, 360)] private float timeOday = 180;

    private void Update()
    {
        if(preset == null) return;

        if(Application.isPlaying){
            timeOday += Time.deltaTime;
            timeOday %= 360;
            UpdateLighting(timeOday);
        }
    }

    private void UpdateLighting(float time){
        RenderSettings.ambientLight = preset.ambColor.Evaluate(time);
        RenderSettings.fogColor = preset.fogColor.Evaluate(time);

        if(dirLight != null){
            dirLight.color = preset.dirColor.Evaluate(time);
            dirLight.transform.localRotation = Quaternion.Euler(new Vector3(time-90f,170,0));
        }
    }

    private void OnValidate()
    {
        if(dirLight != null) return;

        if(RenderSettings.sun != null) dirLight = RenderSettings.sun;
        else {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light item in lights){
                if(item.type == LightType.Directional){
                    dirLight = item;
                    return;
                }
            }
        }
    }
}