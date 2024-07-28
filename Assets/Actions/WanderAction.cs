using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Actions/Wander")]
    public class WanderAction : Action
    {
        public float speed;

        public float waitTimeAtGoal;

        private Dictionary<int, Vector3> goals;

        private Dictionary<int, float> waitTimers;

        public override void Warmup(GameObject gameObject)
        {
            goals = new Dictionary<int, Vector3>();
            waitTimers = new Dictionary<int, float>();

            Debug.Log("Warmed up up Wander action", this);

        }

        public override void Tick(GameObject gameObject)
        {
            if (!goals.ContainsKey(gameObject.GetInstanceID()))
            {
                SetNeWGoal(gameObject);
            }

            if (Vector3.Distance(gameObject.transform.position, goals[gameObject.GetInstanceID()]) < 1f)
            {
                if (!waitTimers.ContainsKey(gameObject.GetInstanceID()))
                {
                    waitTimers[gameObject.GetInstanceID()] = 0;
                }
                if (waitTimers[gameObject.GetInstanceID()] < waitTimeAtGoal)
                {
                    waitTimers[gameObject.GetInstanceID()] += Time.deltaTime;
                }
                else
                {
                    waitTimers[gameObject.GetInstanceID()] = 0;
                    SetNeWGoal(gameObject);
                }
            }
            else
            {
                gameObject.transform.position = gameObject.transform.position + (goals[gameObject.GetInstanceID()] - gameObject.transform.position).normalized * speed * Time.deltaTime;
                //Debug.Log("I'm moving!", this);
            }
        }

        public override void Cooldown(GameObject gameObject)
        {
            //Debug.Log("Cooldown called", this);
        }

        private void SetNeWGoal(GameObject gameObject)
        {
            goals[gameObject.GetInstanceID()] =
                new Vector3(
                Random.Range(-100, 100),
                0,
                Random.Range(-100, 100)
            );
        }
    }
}