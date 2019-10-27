using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Inputs/Random float")]
    public class RandomFloatInput : Input
    {
        public override void CalculateUtility()
        {
            rawValue = Random.Range(0f, 1f);
            base.CalculateUtility();           
        }
    }
}