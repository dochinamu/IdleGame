using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Character target;

    // Start is called before the first frame update
    void Start()
    {
        Init(100, 1);
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
        }
        else
        {
            // init���� �ʱ�ȭ�� Damage ���� �Էµ�
            Hit_Damage(target, Damage);
            Attack_Cooltime = 0.0f;
        }
    }

    public override void Dead()
    {
        base.Dead();
        Debug.Log("Player Dead!");
        Spawn();
    }
    public void Spawn()
    {
        Hp = Hp_Max;
        State = Character_State.Idle;
    }
}
