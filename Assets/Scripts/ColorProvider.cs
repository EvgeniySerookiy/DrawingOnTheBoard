using System.Collections.Generic;
using UnityEngine;

public class ColorProvider : MonoBehaviour
{
    private List<Color> _colors = new()
    {
        Color.red, Color.green, Color.blue, Color.magenta, Color.yellow, Color.white,
    };

    public Color GetColor(int index)
    {
        return _colors[index];
    }
}
