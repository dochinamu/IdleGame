using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public class Player_Value
    {
        public BigInteger Gold;
        public BigInteger Level_Hp; // 레벨별로 증가하는 HP
        public BigInteger Level_Damage; // 레벨에 따른 Damage 양

        public void Get_Gold(BigInteger value, UnityEngine.Vector3 pos)
        {
            Gold += value;
            GameManager.instance.Text_Gold.text = "Level_Gold: " + Gold;
            GameManager.instance.Set_Text(value.ToString(), pos);
        }

        public void Get_Level_Hp()
        {
            Level_Hp += 1;
            GameManager.instance.Text_Level_Hp.text = "Level_Hp: " + Level_Hp;
        }

        public void Get_Level_Damage()
        {
            Level_Damage += 1;
            GameManager.instance.Text_Level_Damage.text = "Level_Damage: " + Level_Damage;
        }
    }

    // static: 정적으로 게임 메니저를 인스턴스화
    // 싱클톤 패턴: 필요한 인스턴스를 단 하나만 생성하여 사용하는 디자인 패턴
    public static GameManager instance;
    public Player_Value m_Player_Value;
    public Text Text_Gold;
    public Text Text_Level_Hp;
    public Text Text_Level_Damage;
    public Text Text_Damage;
    public List<Text> Text_List;


    // start 함수 실행 이전에 초기화를 위해 실행
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Player_Value = new Player_Value();
        GameManager.instance.Text_Gold.text = "Gold:" + m_Player_Value.Gold;
        GameManager.instance.Text_Level_Hp.text = "Level_Hp:" + m_Player_Value.Level_Hp;
        GameManager.instance.Text_Level_Damage.text = "Level_Damage:" + m_Player_Value.Level_Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set_Text(string text, UnityEngine.Vector3 pos)
    {
        bool set = false;
        foreach (Text t in Text_List)
        {
            if (!t.gameObject.activeSelf)
            {
                t.text = text;
                // 3d 좌표를 2d 좌표로 변환
                t.transform.position = Camera.main.WorldToScreenPoint(pos);
                t.gameObject.SetActive(true);
                set = true;
                break;
            }
        }

        if (!set)
        {
            Text t = Instantiate(Text_Level_Damage, Camera.main.WorldToScreenPoint(pos), UnityEngine.Quaternion.identity).GetComponent<Text>();
            t.transform.SetParent(Text_Level_Damage.transform.parent);
            t.text = text;
            Text_List.Add(t);
        }
        {
            
        }
    }
}
