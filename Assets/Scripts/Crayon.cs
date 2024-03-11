using System;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Crayon : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Color _crayonColor;
    public event Action<Color> OnColorSelected;

    private void Start()
    {
        _crayonColor = GetComponent<Image>().color;
    }

    public void GetColor()
    {
        OnColorSelected?.Invoke(_crayonColor);
        Debug.Log("Произошло событие");
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }
}
