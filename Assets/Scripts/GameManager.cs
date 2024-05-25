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
        public BigInteger Level_Hp; // �������� �����ϴ� HP
        public BigInteger Level_Damage; // ������ ���� Damage ��

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

    // static: �������� ���� �޴����� �ν��Ͻ�ȭ
    // ��Ŭ�� ����: �ʿ��� �ν��Ͻ��� �� �ϳ��� �����Ͽ� ����ϴ� ������ ����
    public static GameManager instance;
    public Player_Value m_Player_Value;
    public Text Text_Gold;
    public Text Text_Level_Hp;
    public Text Text_Level_Damage;
    public Text Text_Damage;
    public List<Text> Text_List;


    // start �Լ� ���� ������ �ʱ�ȭ�� ���� ����
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
                // 3d ��ǥ�� 2d ��ǥ�� ��ȯ
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
