using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{        
    public class Input : ScriptableObject
    {        
        public float rawValue;

        public AnimationCurve curve;

        [System.NonSerialized]        
        public float utility;

        public void CalculateUtility()
        {
            utility = curve.Evaluate(rawValue);
        }
    }
}