using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    WizardTemplate leftWizardTemplate;
    [SerializeField]
    WizardController leftWizardController;
    [SerializeField]
    Wizard leftWizard;

    [SerializeField]
    WizardTemplate rightWizardTemplate;
    [SerializeField]
    Wizard rightWizard;
    [SerializeField]
    WizardController rightWizardControler;

    [SerializeField]
    BattleGUIBuilder battleGUI;

    void Awake()
    {
        leftWizard.Init(leftWizardTemplate);
        rightWizard.Init(rightWizardTemplate);
    }

    void Start()
    {
        leftWizardController.IsActive = true;
        battleGUI.BuildAllWizardGUI(leftWizard);
    }

    public WizardController GetActiveWizard()
    {
        return leftWizardController.IsActive ? leftWizardController : rightWizardControler;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            leftWizardController.IsActive = true;
            rightWizardControler.IsActive = false;
            Camera.main.transform.parent = leftWizardController.transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
        }

        if (Input.GetKey(KeyCode.N))
        {
            rightWizardControler.IsActive = true;
            leftWizardController.IsActive = false;
            Camera.main.transform.parent = rightWizardControler.transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
        }
    }
}
