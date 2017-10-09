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
        CameraSingleton.Instance.WatchObject(leftWizardController.gameObject);
    }

    public WizardController GetActiveWizard()
    {
        return leftWizardController.IsActive ? leftWizardController : rightWizardControler;
    }

    public void ChangeTurn()
    {
        if (leftWizardController.IsActive)
        {
            leftWizardController.IsActive = false;
            rightWizardControler.IsActive = true;
        }
        else
        {
            leftWizardController.IsActive = true;
            rightWizardControler.IsActive = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            leftWizardController.IsActive = true;
            rightWizardControler.IsActive = false;
            CameraSingleton.Instance.WatchObject(leftWizardController.gameObject);
        }

        if (Input.GetKey(KeyCode.N))
        {
            rightWizardControler.IsActive = true;
            leftWizardController.IsActive = false;
            CameraSingleton.Instance.WatchObject(rightWizardControler.gameObject);
        }
    }
}
