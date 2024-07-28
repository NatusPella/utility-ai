using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [System.Serializable]
    public class Rule
    {
        public string name;

        public Input[] inputs;
        public AnimationCurve curve;

        public Action action;

        [System.NonSerialized]
        public float utility;

        public void CalculateUtility(GameObject gameObject)
        {
            float total = 0;
            foreach (Input input in inputs)
            {
                input.CalculateUtility(gameObject);
                total += input.utility;
            }

            utility = curve.Evaluate(total / inputs.Length);
        }
    }
}