using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LightPreset", menuName = "Only-speed-for-me/LightPreset", order = 0)]
public class LightPreset : ScriptableObject {
    public Gradient ambColor;
    public Gradient dirColor;
    public Gradient fogColor;
}
