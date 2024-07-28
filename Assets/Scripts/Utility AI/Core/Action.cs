using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    public class Action : ScriptableObject
    {
        public enum Resuls { None, Success, Failure }

        public bool readyForCooldown = true;

        public virtual void Warmup(GameObject gameObject) { }

        public virtual void Tick(GameObject gameObject) { }

        public virtual void Cooldown(GameObject gameObject) { }
    }
}