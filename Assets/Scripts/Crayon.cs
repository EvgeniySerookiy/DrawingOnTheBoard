using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Crayon : MonoBehaviour
{
    public event Action<Color> ColorSelected;
    
    [SerializeField] private Image _image;

    public void SetActiveCrayon()
    {
        ColorSelected?.Invoke(_image.color);
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }
}
