using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private List<Vector3> _points = new List<Vector3>();
    
    public void SetColor(Color color)
    {
        if (_lineRenderer == null)
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }
        
        _lineRenderer.startColor = color;
        Debug.Log(_lineRenderer.startColor);
        _lineRenderer.endColor = color;
        Debug.Log(_lineRenderer.endColor);
    }
    
    public void AddPoint(Vector3 point)
    {
        _points.Add(point);
        
        if (_lineRenderer == null)
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }
        
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPositions(_points.ToArray());
    }
}

