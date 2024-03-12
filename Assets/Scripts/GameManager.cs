using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Line> _lines = new();
    
    [SerializeField] private CrayonsManager _crayonsManager;
    [SerializeField] private Line _linePrefab;
    [SerializeField] private Image _image;
    [SerializeField] private RectTransform _chalkArea;
    [SerializeField] private Sponge _spongePrefab;
    [SerializeField] private Transform _transform;
    
    private Sponge _sponge;
    private RectTransform _specificAreaRectTransform;
    private Line _currentLine;
    private Color _startColor;

    private void Start()
    {
        _startColor = _image.color;
        _specificAreaRectTransform = _chalkArea.GetComponent<RectTransform>();
        
        
        foreach (Crayon crayon in _crayonsManager.GetCrayons())
        {
            crayon.ColorSelected += HandleColorSelected;
        }
        
        Initialize();
    }

    private void OnDestroy()
    {
        _sponge.OnSpongePressed -= HandleSpongePressed;
        
        foreach (Crayon crayon in _crayonsManager.GetCrayons())
        {
            crayon.ColorSelected -= HandleColorSelected;
        }
    }

    private void HandleColorSelected(Color selectedColor)
    {
        _image.color = selectedColor;
        
        _currentLine = Instantiate(_linePrefab, transform);
        _currentLine.SetColor(_image.color);
        
        _lines.Add(_currentLine);
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _image.transform.position = new Vector3(mousePosition.x - 0.2f, mousePosition.y - 0.2f, _image.transform.position.z);
        
        if (IsInSpecificArea(mousePosition) && _currentLine != null && Input.GetMouseButton(0))
        {
            return;
        }
        
        if (_currentLine != null && Input.GetMouseButton(0))
        {
            _currentLine.AddPoint(new Vector3(mousePosition.x, mousePosition.y, 0.0f));
        }
        
    }
    
    private bool IsInSpecificArea(Vector2 screenPosition)
    {
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_specificAreaRectTransform, screenPosition, null, out localPosition);

        Rect specificAreaRect = _specificAreaRectTransform.rect;
        return specificAreaRect.Contains(localPosition);
    }
    
    private void HandleSpongePressed()
    {
        foreach (var line in _lines)
        {
            if (line != null)
            {
                Destroy(line.gameObject);
            }
        }
        
        _lines.Clear();

        _image.color = _startColor;
    }
    
    private void Initialize()
    { 
        _sponge = Instantiate(_spongePrefab, _transform);
        _sponge.OnSpongePressed += HandleSpongePressed;
    }
}
