using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Character : MonoBehaviour
{
    // enum: 정수 숫자로 이루어진 상수의 집합. (0,1,2,3,4,...)
    // (Idle, Death, 2, 3, 4, ...)로 사용 가능
    // Character_State.Idle = 0, Character_State.Death = 1
    public enum Character_State
    {
        Idle,
        Death
    }
    // BigInteger: (무한대까지) 큰 수를 나타내는 자료형. 방치형 게임이므로 Int32보다 큰 수를 사용해야 함.
    public BigInteger Hp;
    public BigInteger Hp_Max;
    public BigInteger Damage;
    public float Attack_Speed;

    public Character_State State;
    public BigInteger Gold;


    public void Init(BigInteger hp, BigInteger damage)
    {
        // 변수 초기화
        Hp_Max = hp;
        Hp = Hp_Max;
        Damage = damage;
        Attack_Speed = 1.0f;
        Gold = 10;
        State = Character_State.Idle; // 살아 있는 상태
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

    // virtual: 상속받은 자식 클래스에서 재정의 가능한 함수
    public virtual void Dead()
    {
        Debug.Log("Dead");
        State = Character_State.Death;
    }

    
}
