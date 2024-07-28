using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Actions/Debug print")]
    public class DebugPrintAction : Action
    {
        public override void Warmup(GameObject gameObject)
        {
            Debug.Log("Warmup called", this);
        }

        public override void Tick(GameObject gameObject)
        {
            Debug.Log("Tick called", this);
        }

        public override void Cooldown(GameObject gameObject)
        {
            Debug.Log("Cooldown called", this);
        }
    }
}