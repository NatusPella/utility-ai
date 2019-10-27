using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{        
    public class Input : ScriptableObject
    {       
        public AnimationCurve curve;

        [System.NonSerialized]
        public float rawValue;

        [System.NonSerialized]        
        public float utility;

        public virtual void CalculateUtility()
        {
            utility = curve.Evaluate(rawValue);
        }
    }
}