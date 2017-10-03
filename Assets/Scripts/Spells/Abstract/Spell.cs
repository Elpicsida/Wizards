using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Spells
{
    public abstract class Spell : MonoBehaviour
    {
        public Sprite Icon;
        public string Name;
        public ElementEnum Element;
        public abstract void Activate();
    }
}
