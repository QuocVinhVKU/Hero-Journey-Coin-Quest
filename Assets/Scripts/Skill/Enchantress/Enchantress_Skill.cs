using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillEnum
{
    none,
    skill1,
    skill2,
    skill3,
    skill4
}
public class Enchantress_Skill : MonoBehaviour
{
    [SerializeField] float scaleAtk_skill_1;
    [SerializeField] float scaleAtk_skill_2;
    [SerializeField] float scaleAtk_skill_3;
    [SerializeField] float scaleAtk_skill_4;
    private SkillEnum skillEnum;

    public float Skill1_damage()
    {
        float damage = Player.instance.playerAtk * scaleAtk_skill_1;
        return damage;
    }
    public float Skill2_damage()
    {
        float damage = Player.instance.playerAtk * scaleAtk_skill_2;
        return damage;
    }
    public float Skill3_damage()
    {
        float damage = Player.instance.playerAtk * scaleAtk_skill_3;
        return damage;
    }
    public float Skill4_damage()
    {
        float damage = Player.instance.playerAtk * scaleAtk_skill_4;
        return damage;
    }
}
