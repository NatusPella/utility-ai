using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{    
    public class Action : ScriptableObject
    {
        public enum Resuls {None, Success, Failure}

        public bool readyForCooldown = true;

        public virtual void Warmup() { }

        public virtual void Tick() { }

        public virtual void Cooldown() { }
    }
}