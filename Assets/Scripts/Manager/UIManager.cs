using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button Skill_1_Btn;
    [SerializeField] Button Skill_2_Btn;
    [SerializeField] Button Skill_3_Btn;
    [SerializeField] Button Skill_4_Btn;

    private void Start()
    {
        Skill_1_Btn.onClick.AddListener(Player.instance.Skill_1);
        Skill_2_Btn.onClick.AddListener(Player.instance.Skill_2);
        Skill_3_Btn.onClick.AddListener(Player.instance.Skill_3);
        Skill_4_Btn.onClick.AddListener(Player.instance.Skill_4);
    }
}
