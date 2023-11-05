using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float Health { set; get; }

    public bool Invisible { set; get; }

    public void OnHit(float damage, Vector2 Knockback);

    public void OnHit(float damage);

    public bool Targetable { set; get; }

    public void OnObjectDestroyed();

}
