using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuchMedia.UtilityAI
{

    public class Entity : MonoBehaviour
    {
        public EntityProfile profile;

        public float minimalActivation = 0.2f;

        private RuleGroup activeRuleGroup;
        private Rule activeRule;

        public void Tick()
        {
            if (profile == null)
            {
                Debug.LogError("Entity was not assigned a profile and cannot run", this);
                return;
            }

            if (activeRule != null)
            {
                //Debug.Log("Executing active rule: " + activeRule.name, this);

                if (activeRule.action != null)
                {
                    if (activeRule.action.readyForCooldown)
                    {
                        RuleGroup nextRuleGroup = FindNextRuleGroup(gameObject);
                        Rule nextRule = nextRuleGroup.highestRule;
                        if (nextRule == activeRule)
                        {
                            activeRule.action.Tick(gameObject);
                        }
                        else
                        {
                            activeRule.action.Cooldown(gameObject);

                            if (nextRule != null)
                            {
                                if (nextRule.action != null)
                                {
                                    nextRule.action.Warmup(gameObject);
                                    nextRule.action.Tick(gameObject);
                                }
                            }

                            activeRuleGroup = nextRuleGroup;
                            activeRule = nextRule;
                        }
                    }
                    else
                    {
                        activeRule.action.Tick(gameObject);
                    }
                }
                else
                {
                    //Debug.Log("Finding next rule", this);

                    RuleGroup nextRuleGroup = FindNextRuleGroup(gameObject);
                    Rule nextRule = nextRuleGroup.highestRule;

                    if (nextRule != null)
                    {
                        if (nextRule.action != null)
                        {
                            nextRule.action.Warmup(gameObject);
                            nextRule.action.Tick(gameObject);
                        }
                    }

                    activeRuleGroup = nextRuleGroup;
                    activeRule = nextRule;
                }
            }
            else
            {
                //Debug.Log("Finding and executing active rulegroup", this);

                activeRuleGroup = FindNextRuleGroup(gameObject);
                if (activeRuleGroup != null)
                {
                    activeRule = activeRuleGroup.highestRule;
                    activeRule.action.Warmup(gameObject);
                    activeRule.action.Tick(gameObject);
                }
            }

        }

        private RuleGroup FindNextRuleGroup(GameObject gameObject)
        {
            RuleGroup nextRuleGroup = null;

            int bestPriority = -1;
            float bestUtility = 0f;

            foreach (RuleGroup ruleGroup in profile.ruleGroups)
            {
                if (ruleGroup.priority > Mathf.Max(bestPriority, minimalActivation))
                {
                    ruleGroup.CalculateUtility(gameObject);
                    float groupUtility = ruleGroup.utility;

                    if (groupUtility > bestUtility)
                    {
                        bestUtility = groupUtility;
                        bestPriority = ruleGroup.priority;

                        //nextRule = ruleGroup.highestRule;
                        nextRuleGroup = ruleGroup;
                    }
                }
            }

            //Debug.Log("Nextrulegroup: " + nextRuleGroup.name, this);

            return nextRuleGroup;
        }
    }
}