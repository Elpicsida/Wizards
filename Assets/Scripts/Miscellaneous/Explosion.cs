using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion {

    private GameObject[] Wizzards;

    public Explosion() {
        Wizzards = GameObject.FindGameObjectsWithTag("Character");
    }

    public void Explode(int damage, int radius, Vector3 position)
    {
        foreach (GameObject wizard in Wizzards)
        {
            float distance = Vector3.Distance(wizard.transform.position, position);
            int damageTaken = Mathf.RoundToInt(damage * (1 - distance / radius));

            if (damageTaken > 0)
            {
                Wizard wizardstats = wizard.GetComponent<Wizard>();
                wizardstats.TakeDamage(damageTaken);
            }
        }
    }
}
