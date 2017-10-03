using Assets.Scripts.Spells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireballBallistic : ShootingSpell
{
    public int Damage = 50;
    public int Radius = 5;
    private Explosion explosion;
    
	void Start () {
        explosion = new Explosion();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionobject = collision.gameObject.tag;
        if ("Terrain".Equals(collisionobject) || "Character".Equals(collisionobject))
        {
            explosion.Explode(Damage, Radius, transform.position);
            Destroy(this.gameObject);
        }
    }
}
