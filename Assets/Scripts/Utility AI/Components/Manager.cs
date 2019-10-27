using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{
    public class Manager : MonoBehaviour
    {
        private static Entity[] entities;
        private static Tag[] tags;

        private void Awake()
        {
            entities = FindObjectsOfType<Entity>();
            tags = FindObjectsOfType<Tag>();
        }

        private void Start()
        {
            StartCoroutine(TickEntities());
        }

        IEnumerator TickEntities()
        {
            while (true)
            {            
                foreach (Entity entity in entities)
                {
                    entity.Tick();
                    yield return null;
                }
                yield return null;
            }
        }
    }
}
