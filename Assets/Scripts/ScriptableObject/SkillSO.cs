using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillSO : ScriptableObject
{
    public Sprite iconSkill;
    public Sprite fillImage; //cooldown

    public float cooldown;

    public string decription;
}
