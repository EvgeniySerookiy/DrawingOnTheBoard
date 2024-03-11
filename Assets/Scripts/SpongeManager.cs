using System;
using UnityEngine;

public class SpongeManager : MonoBehaviour
{
    public event Action OnSpongePressed;
    
    [SerializeField] private Sponge _spongePrefab;
    private Sponge _sponge;
    
    private void Start()
    {
        Initialize();
    }
    
    private void Initialize()
    { 
        _sponge = Instantiate(_spongePrefab, transform);
        _sponge.OnSpongePressed += HandleSpongePressed;
    }

    private void HandleSpongePressed()
    {
        OnSpongePressed?.Invoke();
    }
}
