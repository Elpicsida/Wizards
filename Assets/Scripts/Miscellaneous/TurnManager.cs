using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public GameObject[] Wizzards;
    private int activeWizardId = 0;

    [SerializeField]
    WizardTemplate leftWizardTemplate;
    [SerializeField]
    Wizard leftWizard;
    [SerializeField]
    WizardTemplate rightWizardTemplate;
    [SerializeField]
    Wizard rightWizard;
    [SerializeField]
    BattleGUIBuilder battleGUI;

    void Awake()
    {
        leftWizard.Init(leftWizardTemplate);
        rightWizard.Init(rightWizardTemplate);
    }

    void Start()
    {
        Wizzards[0].SendMessage("Activate");
        Camera.main.transform.parent = Wizzards[0].transform;
        battleGUI.BuildAllWizardGUI(rightWizard);
    }

    public GameObject GetActiveWizard()
    {
        return Wizzards[activeWizardId];
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Wizzards[0].SendMessage("Activate");
            Wizzards[1].SendMessage("Deactivate");
            Camera.main.transform.parent = Wizzards[0].transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
            activeWizardId = 0;
        }

        if (Input.GetKey(KeyCode.N))
        {
            Wizzards[1].SendMessage("Activate");
            Wizzards[0].SendMessage("Deactivate");
            Camera.main.transform.parent = Wizzards[1].transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
            activeWizardId = 1;
        }
    }
}
