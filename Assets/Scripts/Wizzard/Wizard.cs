using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {
    
    public int HealthPoints;
    public int ManaPoints;
    public int Condition;
    public int Vitality;
    public int Intelligence;
    public int Resistance;
    public int Vision;
    public ElementEnum MainElement;

    public void TakeDamage(int damage)
    {
        int realDamage = damage - Resistance;
        if (damage > 0)
        {
            Debug.Log("Damage taken : " + damage);
            this.HealthPoints -= damage;
        }

        if (HealthPoints < 0 )
        {
            Debug.Log("Wizzard died");
        }
    }
}
