using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private List<Vector3> _points = new();

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetColor(Color color)
    {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }
    
    public void AddPoint(Vector3 point)
    {
        _points.Add(point);
        
        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPositions(_points.ToArray());
    }
}

