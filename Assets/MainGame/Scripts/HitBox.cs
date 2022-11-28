using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Enemy_Health health;

    public void OnBulletHit(BulletDamage weapon)
    {
        health.TakeDamage(weapon.GiveDamage);
    }
    
}
