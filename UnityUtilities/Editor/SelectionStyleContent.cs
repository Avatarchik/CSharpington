using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Lasm.OdinSerializer;

[Serializable]
public class SelectionStyleContent
{
    [OdinSerialize]
    public string image = null;
    [OdinSerialize]
    public string text = string.Empty;
    [OdinSerialize]
    public string tooltip = string.Empty;
    [OdinSerialize]
    public float height = 18;
    [OdinSerialize]
    public float borderThickness = 1;
    [OdinSerialize]
    public Color background = Color.grey;
    [OdinSerialize]
    public Color border = Color.black;
    [OdinSerialize]
    public Color pressed = new Color(0.4f, 0.4f, 0.4f);
    [OdinSerialize]
    public Color active = new Color(0.65f, 0.65f, 0.65f);
}
