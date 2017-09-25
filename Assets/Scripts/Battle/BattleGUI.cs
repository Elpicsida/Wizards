using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGUI : MonoBehaviour {

    private CanvasScaler scaler;
    public Vector2 Resolution { get { return this.scaler.referenceResolution; } }

    void Awake()
    {
        scaler = GetComponent<CanvasScaler>();
    }
}
