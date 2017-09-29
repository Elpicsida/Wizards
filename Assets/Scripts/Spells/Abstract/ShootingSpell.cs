﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public abstract class ShootingSpell : Spell
    {
        protected GameObject WizardGameObj;

        public override void Activate()
        {
            TurnManager turnManager = GameObject.FindObjectOfType<TurnManager>();
            WizardGameObj = turnManager.GetActiveWizard();
            var wizardController = WizardGameObj.GetComponent<WizzardController>();
            int fireStrength = wizardController.FireStrength;
            int angle = wizardController.Angle;
            var x = fireStrength * Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = fireStrength * Mathf.Sin(angle * Mathf.Deg2Rad);
            int directionInt = wizardController.facingRight ? 1 : -1;
            transform.position = WizardGameObj.transform.position + new Vector3(directionInt * 0.4f, 0.4f, 0f);
            var rigidBodyFireball = GetComponent<Rigidbody2D>();
            rigidBodyFireball.AddForce(new Vector2(x, y));
        }
    }
}
