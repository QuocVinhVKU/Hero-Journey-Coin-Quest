using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour  
{
    [Header("Skill")]
    [SerializeField] Button Skill_1_Btn;
    [SerializeField] Button Skill_2_Btn;
    [SerializeField] Button Skill_3_Btn;
    [SerializeField] Button Skill_4_Btn;

    [Header("Move")]
    [SerializeField] Button moveLeft;
    [SerializeField] Button moveRight;
    [SerializeField] Button jump;

    private void Start()
    {
        Skill_1_Btn.onClick.AddListener(Player.instance.Skill_1);
        Skill_2_Btn.onClick.AddListener(Player.instance.Skill_2);
        Skill_3_Btn.onClick.AddListener(Player.instance.Skill_3);
        Skill_4_Btn.onClick.AddListener(Player.instance.Skill_4);

    }

}
