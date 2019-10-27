using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Actions/Debug print")]
    public class DebugPrintAction : Action
    {
        public string text;

        public override void Warmup()
        {
            Debug.Log("Warmup called", this);
        }

        public override void Tick()
        {
            Debug.Log("Tick called", this);
        }

        public override void Cooldown()
        {
            Debug.Log("Cooldown called", this);
        }
    }
}