using UnityEngine;

[CreateAssetMenu]
public class WizardTemplate : ScriptableObject
{
    public string WizardName;

    public Sprite Face;

    public int HealthPoints;

    public int ManaPoints;

    public int Condition;

    public int Vitality;

    public int Intelligence;

    public int Resistance;

    public int Vision;

    public ElementEnum MainElement;
}
