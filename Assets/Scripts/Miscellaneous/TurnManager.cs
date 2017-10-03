using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public Transform[] Wizzards;

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
        Wizzards[0].gameObject.SendMessage("Activate");
        Camera.main.transform.parent = Wizzards[0].transform;
        battleGUI.BuildAllWizardGUI(rightWizard);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            battleGUI.Test(rightWizard);
            Wizzards[0].gameObject.SendMessage("Activate");
            Wizzards[1].gameObject.SendMessage("Deactivate");
            Camera.main.transform.parent = Wizzards[0].transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
        }

        if (Input.GetKey(KeyCode.N))
        {
            Wizzards[1].gameObject.SendMessage("Activate");
            Wizzards[0].gameObject.SendMessage("Deactivate");
            Camera.main.transform.parent = Wizzards[1].transform;
            Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.localPosition.z);
        }
    }
}
