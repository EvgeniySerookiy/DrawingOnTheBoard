using System;
using UnityEngine;

public class Sponge : MonoBehaviour
{
    public event Action OnSpongePressed;

    public void OnMouseDown()
    {
        OnSpongePressed?.Invoke();
    }
}
