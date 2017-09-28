using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    public void Init(WizardTemplate wizardTemplate)
    {
        this.wizardName = wizardTemplate.WizardName;
        this.face = wizardTemplate.Face;
        this.healthPoints = wizardTemplate.HealthPoints;
        this.manaPoints = wizardTemplate.ManaPoints;
        this.condition = wizardTemplate.Condition;
        this.vitality = wizardTemplate.Vitality;
        this.intelligence = wizardTemplate.Intelligence;
        this.resistance = wizardTemplate.Resistance;
        this.vision = wizardTemplate.Vision;
        this.mainElement = wizardTemplate.MainElement;
    }

    private string wizardName;
    public string WizardName { get { return wizardName; } }

    private Sprite face;
    public Sprite Face { get { return face; } }

    private int healthPoints;
    public int HealthPoints { get { return healthPoints; } }

    private int manaPoints;
    public int ManaPoints { get { return manaPoints; } }

    private int condition;
    public int Condition { get { return condition; } }

    private int vitality;
    public int Vitality { get { return vitality; } }

    private int intelligence;
    public int Intelligence { get { return intelligence; } }

    private int resistance;
    public int Resistance { get { return resistance; } }

    private int vision;
    public int Vision { get { return vision; } }

    private ElementEnum mainElement;
    public ElementEnum MainElement { get { return mainElement; } }

}
