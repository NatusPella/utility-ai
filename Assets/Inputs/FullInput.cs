using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Inputs/Constant")]
    public class ConstantInput : Input
    {
        public float value;

        public override void CalculateUtility(GameObject gameObject)
        {
            rawValue = value;
            base.CalculateUtility(gameObject);
        }
    }
}