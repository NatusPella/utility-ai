using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Profile")]
    public class Profile : ScriptableObject
    {
        new public string name;
        public RuleGroup[] ruleGroups;
    }
}