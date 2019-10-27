using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{

    public class Entity : MonoBehaviour
    {
        public Profile profile;
        
        private Rule activeRule;

        public void Tick()
        {
            if (profile == null)
            {
                Debug.LogError("Entity was not assigned a profile and cannot run", this);                
                return;
            }

            if(activeRule != null)
            {
                if (activeRule.action != null)
                {
                    if (activeRule.action.readyForCooldown)
                    {
                        Rule nextRule = FindNextRule();
                        if (nextRule == activeRule)
                        {
                            activeRule.action.Tick();
                        }
                        else
                        {
                            activeRule.action.Cooldown();

                            nextRule.action.Warmup();
                            nextRule.action.Tick();

                            activeRule = nextRule;
                        }
                    }
                    else
                    {
                        activeRule.action.Tick();
                    }
                }
                else
                {
                    Rule nextRule = FindNextRule();

                    if (nextRule.action != null)
                    {
                        nextRule.action.Warmup();
                        nextRule.action.Tick();
                    }                    

                    activeRule = nextRule;
                }                
            }
            else
            {
                Rule activeRule = FindNextRule();
                if (activeRule != null)
                {
                    activeRule.action.Warmup();
                    activeRule.action.Tick();
                }
            }
                
        }

        private Rule FindNextRule()
        {
            Rule nextRule = null;

            int bestPriority = -1;
            float bestUtility = 0;

            foreach (RuleGroup ruleGroup in profile.ruleGroups)
            {
                if (ruleGroup.priority > bestPriority)
                {
                    ruleGroup.CalculateUtility();
                    float groupUtility = ruleGroup.utility;

                    if (groupUtility > bestUtility)
                    {
                        bestUtility = groupUtility;
                        bestPriority = ruleGroup.priority;

                        nextRule = ruleGroup.highestRule;
                    }
                }                
            }

            return nextRule;
        }
    }
}