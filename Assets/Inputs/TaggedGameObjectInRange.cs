using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    [CreateAssetMenu(menuName = "Utility AI/Inputs/Tagged GameObject In Range")]
    public class TaggedGameObjectInRangeInput : Input
    {
        public TagID tagID;
        public float maxDistance;

        public override void CalculateUtility(GameObject gameObject)
        {
            Tag[] taggedObjects = FindObjectsOfType<Tag>();

            Tag closestObject = null;
            float closestObjectDistance = Mathf.Infinity;
            foreach (Tag taggedObject in taggedObjects)
            {
                if (taggedObject.id == tagID)
                {
                    float distance = Vector3.Distance(gameObject.transform.position, taggedObject.transform.position);
                    if (distance < maxDistance && distance < closestObjectDistance)
                    {
                        closestObject = taggedObject;
                        closestObjectDistance = distance;
                    }
                }
            }

            if (closestObject != null)
            {
                rawValue = closestObjectDistance / maxDistance;
            }
            else
            {
                rawValue = 0f;
            }

            base.CalculateUtility(gameObject);
        }
    }
}