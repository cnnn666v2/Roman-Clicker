using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Skill
{
    int Name;
    List<SkillStats> SkillStats;
}

[SerializeField]
public class SkillStats
{
    int Damage;
    int Heal;
}