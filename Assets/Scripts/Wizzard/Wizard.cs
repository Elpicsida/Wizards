﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    private string wizardName;
    public string WizardName { get { return wizardName; } }

    private Sprite face;
    public Sprite Face { get { return face; } }

    private int healthPoints;
    public int HealthPoints { get { return healthPoints; } }

    private int manaPoints;
    public int ManaPoints { get { return manaPoints; } }

    private int condition;
    public int Condition
    {
        get
        {
            return condition;
        }
        set
        {
            condition = value;
        }
    }

    private int vitality;
    public int Vitality { get { return vitality; } }

    private int intelligence;
    public int Intelligence { get { return intelligence; } }

    private int resistance;
    public int Resistance { get { return resistance; } }

    private int vision;
    public int Vision { get { return vision; } }

    private List<SpellNames> spells;
    public List<SpellNames> Spells { get { return spells; } }

    private ElementEnum mainElement;
    public ElementEnum MainElement { get { return mainElement; } }
    
    public void Init(WizardTemplate wizardTemplate)
    {
        wizardName = wizardTemplate.WizardName;
        face = wizardTemplate.Face;
        healthPoints = wizardTemplate.HealthPoints;
        manaPoints = wizardTemplate.ManaPoints;
        condition = wizardTemplate.Condition;
        vitality = wizardTemplate.Vitality;
        intelligence = wizardTemplate.Intelligence;
        resistance = wizardTemplate.Resistance;
        vision = wizardTemplate.Vision;
        mainElement = wizardTemplate.MainElement;
        spells = wizardTemplate.Spells;
    }

    public void TakeDamage(int damage)
    {
        int realDamage = damage - Resistance;
        if (realDamage > 0)
        {
            Debug.Log("Damage taken : " + realDamage);
            healthPoints -= realDamage;
        }

        if (HealthPoints < 0)
        {
            Debug.Log("Wizard died");
        }
    }
}
