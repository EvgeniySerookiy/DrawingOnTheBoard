using System.Collections.Generic;
using UnityEngine;

public class CrayonsManager : MonoBehaviour
{
    [SerializeField] private Crayon _crayonPrefab;
    private int count = 6;
    
    private ColorProvider _colorProvider = new();
    private List<Crayon> _crayons = new();
    private int index;

    private void Awake()
    {
        for (var i = 0; i < count; i++)
        {
            SpawnCrayons();
        }
    }

    private void SpawnCrayons()
    {
        Crayon newCrayon = Instantiate(_crayonPrefab, transform);
        newCrayon.SetColor(_colorProvider.GetColor(index));
        _crayons.Add(newCrayon);
        index++;
    }

    public List<Crayon> GetCrayons()
    {
        return _crayons;
    }
}
