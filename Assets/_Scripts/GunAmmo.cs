using System;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public GrenadeLaucher gun;
    public AudioSource reloadSounds;
    public UnityEvent loadedAmmoChanged;

    private int _loadedAmmo;
    //các từ khóa get và set được sử dụng trong thuộc tính (property) 
    //để định nghĩa các phương thức truy cập (accessors)

    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShooting();
            }
        }
    }

    private void UnlockShooting()
    {
        throw new NotImplementedException();
    }

    private void Reload()
    {
        throw new NotImplementedException();
    }
}
