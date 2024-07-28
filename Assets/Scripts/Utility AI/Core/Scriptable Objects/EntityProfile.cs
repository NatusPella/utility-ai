using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Entity Profile")]
    public class EntityProfile : ScriptableObject
    {        
        public RuleGroup[] ruleGroups;
    }
}