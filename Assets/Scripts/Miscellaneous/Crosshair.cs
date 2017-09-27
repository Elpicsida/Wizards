using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    
    private GameObject parent;
    private WizzardController wizardController;
    private SpriteRenderer spriteRenderer;
    private int radiusFromCenter = 2;

    void Start () {
        parent = transform.parent.gameObject;
        wizardController = parent.GetComponent<WizzardController>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
	
	void Update () {
        if (wizardController.InputEnabled)
        {
            spriteRenderer.enabled = true;
            var x = radiusFromCenter * Mathf.Cos(wizardController.Angle * Mathf.Deg2Rad) + parent.transform.position.x;
            var y = radiusFromCenter * Mathf.Sin(wizardController.Angle * Mathf.Deg2Rad) + parent.transform.position.y;
            transform.position = new Vector2(x, y);
        }
        else
        {
            spriteRenderer.enabled = false;
        }
	}
}
