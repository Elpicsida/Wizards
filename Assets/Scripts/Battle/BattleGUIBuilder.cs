using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUIBuilder : MonoBehaviour
{
    [SerializeField]
    Text wizardName;
    [SerializeField]
    Image faceImage;
    [SerializeField]
    Text healthPointsText;
    [SerializeField]
    ProgressBarController healtPointBar;
    [SerializeField]
    Text manaPointsText;
    [SerializeField]
    ProgressBarController manaPointBar;
    [SerializeField]
    Text conditionText;
    [SerializeField]
    ProgressBarController conditionBar;
    [SerializeField]
    Text vitalityText;
    [SerializeField]
    Text intelligenceText;
    [SerializeField]
    Text resistanceText;
    [SerializeField]
    Text visionText;
    [SerializeField]
    Image mainElementImage;

    BattleGUIWIzardMainStats battleGUIWIzardMainStats;

    void Awake()
    {
        battleGUIWIzardMainStats.wizardName = wizardName;
        battleGUIWIzardMainStats.faceImage = faceImage;
        battleGUIWIzardMainStats.healthPointsText = healthPointsText;
        battleGUIWIzardMainStats.manaPointsText = manaPointsText;
        battleGUIWIzardMainStats.conditionText = conditionText;
        battleGUIWIzardMainStats.vitalityText = vitalityText;
        battleGUIWIzardMainStats.intelligenceText = intelligenceText;
        battleGUIWIzardMainStats.resistanceText = resistanceText;
        battleGUIWIzardMainStats.visionText = visionText;
        battleGUIWIzardMainStats.mainElementImage = mainElementImage;
    }

    public void BuildAllWizardGUI(Wizard wizard)
    {
        SetImages(wizard);
        SetParameters(wizard);
    }

    public void SetImages(Wizard wizard)
    {
        battleGUIWIzardMainStats.faceImage.sprite = wizard.Face;

        string path = string.Format("Battle/GUI/{0}", wizard.MainElement);
        StartCoroutine(LoadingSpriteAsyncFromPath(path));
    }

    IEnumerator LoadingSpriteAsyncFromPath(string path)
    {
        var request = Resources.LoadAsync<Sprite>(path);
        yield return request;
        while (!request.isDone)
            yield return null;

        if (request.asset != null)
        {
            battleGUIWIzardMainStats.mainElementImage.sprite = request.asset as Sprite;
        }
    }

    public void SetParameters(Wizard wizard)
    {
        battleGUIWIzardMainStats.healthPointsText.text = wizard.HealthPoints.ToString();
        healtPointBar.Init(wizard.HealthPoints);
        battleGUIWIzardMainStats.manaPointsText.text = wizard.ManaPoints.ToString();
        manaPointBar.Init(wizard.ManaPoints);
        battleGUIWIzardMainStats.conditionText.text = wizard.Condition.ToString();
        manaPointBar.Init(wizard.Condition);
        battleGUIWIzardMainStats.vitalityText.text = wizard.Vitality.ToString();
        battleGUIWIzardMainStats.intelligenceText.text = wizard.Intelligence.ToString();
        battleGUIWIzardMainStats.resistanceText.text = wizard.Resistance.ToString();
        battleGUIWIzardMainStats.visionText.text = wizard.Vision.ToString();
    }

    public void Test(Wizard wizard)
    {
        battleGUIWIzardMainStats.healthPointsText.text = wizard.HealthPoints.ToString();
        healtPointBar.Init(1);
        battleGUIWIzardMainStats.manaPointsText.text = wizard.ManaPoints.ToString();
        manaPointBar.Init(1);
        battleGUIWIzardMainStats.conditionText.text = wizard.Condition.ToString();
        manaPointBar.Init(1);
        battleGUIWIzardMainStats.vitalityText.text = wizard.Vitality.ToString();
        battleGUIWIzardMainStats.intelligenceText.text = wizard.Intelligence.ToString();
        battleGUIWIzardMainStats.resistanceText.text = wizard.Resistance.ToString();
        battleGUIWIzardMainStats.visionText.text = wizard.Vision.ToString();
    }
}

public struct BattleGUIWIzardMainStats
{
    public Text wizardName;
    public Image faceImage;
    public Text healthPointsText;
    public Text manaPointsText;
    public Text conditionText;
    public Text vitalityText;
    public Text intelligenceText;
    public Text resistanceText;
    public Text visionText;
    public Image mainElementImage;
}
