using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    walk,
    fly,
}
public class Enemy : MonoBehaviour
{
    public float enemyHp;
    public float enemyAtk;
    public float enemyDefense;
    public float enemySpeed;
    public float rangeAttack;

    public EnemyType enemyType;

    //attacked by Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Skill1")
        {
            var enchanSkill = collision.gameObject.GetComponentInParent<Enchantress_Skill>();
            if (enchanSkill != null)
            {
                float damage = enchanSkill.Skill1_damage();
                enemyHp -= Mathf.Max((damage - enemyDefense), 1f);
            }
            
        }
        if (collision.gameObject.tag == "Skill2")
        {
            var enchanSkill = collision.gameObject.GetComponentInParent<Enchantress_Skill>();
            if (enchanSkill != null)
            {
                float damage = enchanSkill.Skill2_damage();
                enemyHp -= Mathf.Max((damage - enemyDefense), 1f);
            }

        }
        if (collision.gameObject.tag == "Skill3")
        {
            var enchanSkill = collision.gameObject.GetComponentInParent<Enchantress_Skill>();
            if (enchanSkill != null)
            {
                float damage = enchanSkill.Skill3_damage();
                enemyHp -= Mathf.Max((damage - enemyDefense), 1f);
            }

        }
        if (collision.gameObject.tag == "Skill4")
        {
            var enchanSkill = collision.gameObject.GetComponentInParent<Enchantress_Skill>();
            if (enchanSkill != null)
            {
                float damage = enchanSkill.Skill4_damage();
                enemyHp -= Mathf.Max((damage - enemyDefense),1f);
            }

        }
    }
}
