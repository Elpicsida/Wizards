using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public Transform[] Wizzards;
    
    void Start () {
        Wizzards[0].gameObject.SendMessage("Activate");
        Camera.main.transform.parent = Wizzards[0].transform;
    }
	
     void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
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
