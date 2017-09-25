using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    
    private GameObject parent;
    private WizzardController wizardController;
    private int radiusFromCenter = 2;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        parent = transform.parent.gameObject;
        wizardController = parent.GetComponent<WizzardController>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
	
	// Update is called once per frame
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
