using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace ReflectionCom
{
    class Component
    {
        public void Print()
        {
            Debug.Log("Component Print()");
        }
    }

    class Apart : Component
    {
        private string _name = "";

        public Apart(string name)
        {
            _name = name;
        }

        public new void Print()
        {
            Debug.Log("Apart Print()");
        }

        public void Update()
        {
            Debug.Log($"{_name} Apart Update()");
        }
    }

    class Bpart : Component
    {
        string _name = "";

        public Bpart(string name)
        {
            _name = name;
        }

        public void Awake()
        {
            Debug.Log($"{_name} Bpart Awake()");
        }
    }

    class Cpart : Component
    {
        string _name = "";

        public Cpart(string name)
        {
            _name = name;
        }

        public void Update()
        {
            Debug.Log($"{_name} Cpart Update()");
        }
    }

    class GameObject
    {
        private List<Component> _parts = new List<Component>();

        // GameObject�� ������ Component�� �޼����� �����ϴ� �޼ҵ�
        public void SendMessage(string method)
        {
            foreach (var part in _parts)
            {
                Type type = part.GetType();

                var func = type.GetMethod(method);

                // ã�� �޼ҵ尡 ���� ��� func�� null ���޵�.
                if(func != null)
                {
                    func.Invoke(part, null); // �޼���
                }
            }
        }


        // GameObject Component �߰�
        public void AddPart(Component part)
        {
            _parts.Add(part);
        }

        // GameObject Component ����
        public void RemovePart(Component part)
        {
            _parts.Remove(part);
        }
    }
}

public class ReflectionTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReflectionCom.GameObject obj = new ReflectionCom.GameObject();

        // obj ��ü�� Component�� �߰�
        obj.AddPart(new ReflectionCom.Apart("�Ӹ�"));
        obj.AddPart(new ReflectionCom.Bpart("����"));
        obj.AddPart(new ReflectionCom.Cpart("��"));
        obj.AddPart(new ReflectionCom.Apart("�ٸ�"));
        obj.AddPart(new ReflectionCom.Cpart("����"));

        obj.SendMessage("Update");

        Debug.Log("Awake call");

        obj.SendMessage("Awake");

    }

}
