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
                if (activeRule.action != null)
                {
                    if (activeRule.action.readyForCooldown)
                    {
                        RuleGroup nextRuleGroup = FindNextRuleGroup();
                        Rule nextRule = FindNextRuleGroup().highestRule;
                        if (nextRule == activeRule)
                        {
                            activeRule.action.Tick();
                        }
                        else
                        {
                            activeRule.action.Cooldown();

                            if (nextRule != null)
                            {
                                if (nextRule.action != null)
                                {
                                    nextRule.action.Warmup();
                                    nextRule.action.Tick();
                                }
                            }

                            activeRuleGroup = nextRuleGroup;
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
                    RuleGroup nextRuleGroup = FindNextRuleGroup();
                    Rule nextRule = FindNextRuleGroup().highestRule;

                    if (nextRule != null)
                    {
                        if (nextRule.action != null)
                        {
                            nextRule.action.Warmup();
                            nextRule.action.Tick();
                        }
                    }

                    activeRuleGroup = nextRuleGroup;
                    activeRule = nextRule;
                }
            }
            else
            {
                activeRuleGroup = FindNextRuleGroup();
                activeRule = activeRuleGroup.highestRule;
                if (activeRule != null)
                {
                    activeRule.action.Warmup();
                    activeRule.action.Tick();
                }
            }

        }

        private RuleGroup FindNextRuleGroup()
        {
            RuleGroup nextRuleGroup = null;

            int bestPriority = -1;
            float bestUtility = 0f;

            foreach (RuleGroup ruleGroup in profile.ruleGroups)
            {
                if (ruleGroup.priority > Mathf.Max(bestPriority, minimalActivation))
                {
                    ruleGroup.CalculateUtility();
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

            return nextRuleGroup;
        }
    }
}