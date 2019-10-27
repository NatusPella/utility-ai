using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [System.Serializable]
    public class RuleGroup
    {
        public string name;
        public int priority;
               
        public Rule[] rules;

        [System.NonSerialized]
        public float utility;

        [System.NonSerialized]
        public Rule highestRule;
        
        public void CalculateUtility()
        {
            highestRule = null;
            float highestUtility = -1;
            float total = 0;
            foreach (Rule rule in rules)
            {
                rule.CalculateUtility();
                total += rule.utility;

                if (rule.utility > highestUtility)
                {
                    highestUtility = rule.utility;
                    highestRule = rule;
                }
            }

            utility = total / rules.Length;
        }
    }
}