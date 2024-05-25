using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Character : MonoBehaviour
{
    // enum: ���� ���ڷ� �̷���� ����� ����. (0,1,2,3,4,...)
    // (Idle, Death, 2, 3, 4, ...)�� ��� ����
    // Character_State.Idle = 0, Character_State.Death = 1
    public enum Character_State
    {
        Idle,
        Death
    }
    // BigInteger: (���Ѵ����) ū ���� ��Ÿ���� �ڷ���. ��ġ�� �����̹Ƿ� Int32���� ū ���� ����ؾ� ��.
    public BigInteger Hp;
    public BigInteger Hp_Max;
    public BigInteger Damage;
    public float Attack_Speed;

    public Character_State State;
    public BigInteger Gold;


    public void Init(BigInteger hp, BigInteger damage)
    {
        // ���� �ʱ�ȭ
        Hp_Max = hp;
        Hp = Hp_Max;
        Damage = damage;
        Attack_Speed = 1.0f;
        Gold = 10;
        State = Character_State.Idle; // ��� �ִ� ����
    }

    public void Get_Hp(BigInteger hp)
    {
        if (State == Character_State.Death)
        {
            return;
        }

        Hp += hp;
        if (Hp > Hp_Max)
        {
            Hp = Hp_Max;
        }
    }

    public void Get_Damage(BigInteger damage)
    {
        if (State == Character_State.Death)
        {
            return;
        }

        Hp -= damage;
        if (Hp <= 0)
        {
            Dead();
        }
    }

    public void Hit_Damage(Character target, BigInteger damage)
    {
        target.Get_Damage(damage);
        // Debug.Log("Target State:" + target.State + " Hp: " + target.Hp + " / " + damage);
        GameManager.instance.Set_Text(damage.ToString(), target.transform.position);
    }

    // virtual: ��ӹ��� �ڽ� Ŭ�������� ������ ������ �Լ�
    public virtual void Dead()
    {
        Debug.Log("Dead");
        State = Character_State.Death;
    }

    
}
