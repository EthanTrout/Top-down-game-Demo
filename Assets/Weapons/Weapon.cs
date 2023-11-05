using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float _damage = 1;
    float _area;

    public float Damage
    {
        set
        {
            value = _damage;
        }
        get
        {
            return _damage;
        }
    }
    public float Area
    {
        set
        {
            value = _area;
        }
        get
        {
            return _area;
        }
    }
}

