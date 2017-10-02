using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    
    public WizardController wizardController;
    public SpriteRenderer spriteRenderer;
    private int radiusFromCenter = 2;
    
	void Update () {
        if (wizardController.IsActive)
        {
            spriteRenderer.enabled = true;
            var x = radiusFromCenter * Mathf.Cos(wizardController.Angle * Mathf.Deg2Rad) + wizardController.transform.position.x;
            var y = radiusFromCenter * Mathf.Sin(wizardController.Angle * Mathf.Deg2Rad) + wizardController.transform.position.y;
            transform.position = new Vector2(x, y);
        }
        else
        {
            spriteRenderer.enabled = false;
        }
	}
}
