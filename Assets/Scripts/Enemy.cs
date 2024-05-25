using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Character target;

    // Start is called before the first frame update
    void Start()
    {
        // hp, damage �ʱ�ȭ
        Init(10, 1);
    }

    float Attack_Cooltime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (State == Character_State.Death)
        {
            return;
        }

        if (Attack_Cooltime < Attack_Speed)
        {
            Attack_Cooltime += Time.deltaTime;
        } else
        {
            // init���� �ʱ�ȭ�� Damage ���� �Էµ�
            Hit_Damage(target, Damage);
            Attack_Cooltime = 0.0f;
        }
    }

    // �ڽĿ��� override Ű���� �ۼ�
    public override void Dead()
    {
        base.Dead();
        Debug.Log("Enemy Dead!");
        GameManager.instance.m_Player_Value.Get_Gold(Gold, transform.position);
        Spawn();
    }

    public int Lv_Hp = 200;
    public int Lv_Damage = 200;
    public int Lv_Gold = 200;

    // ���� ��Ȱ: �ִ� HP, ������ ���׷��̵� + �÷��̾�� ��� ����
    public void Spawn()
    {
        Hp_Max += Hp_Max * Lv_Hp / 100;
        Damage += Damage * Lv_Damage / 100;
        Gold += Gold * Lv_Gold / 100;
        Hp = Hp_Max;
        State = Character_State.Idle;
    }
}
