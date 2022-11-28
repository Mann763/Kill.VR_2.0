using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int GiveDamage;

    private void OnCollisionEnter(Collision collision)
    {
        var hitBox = collision.collider.GetComponent<HitBox>();

        if (collision.gameObject.tag == "Enemy")
        {
            hitBox.OnBulletHit(this);
            Debug.Log(collision.gameObject.tag + "collided");
        }
    }
}
