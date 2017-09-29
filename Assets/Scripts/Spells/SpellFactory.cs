using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public class SpellFactory
    {
        public static GameObject GetSpell(SpellNames spellName)
        {
            GameObject spell = null;
            
            switch (spellName)
            {
                case SpellNames.Fireball:
                {
                    spell = GameObject.Instantiate(Resources.Load<GameObject>("Spells/Fireball"));
                    break;
                }
                case SpellNames.FireballStraight:
                {
                    spell = GameObject.Instantiate(Resources.Load<GameObject>("Spells/FireballStraight"));
                        break;
                }
                case SpellNames.FireballTime:
                {
                    spell = GameObject.Instantiate(Resources.Load<GameObject>("Spells/FireballTime"));
                        break;
                }
            }

            return spell;
        }
    }
}
