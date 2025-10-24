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

        // GameObject에 부착된 Component에 메세지를 전송하는 메소드
        public void SendMessage(string method)
        {
            foreach (var part in _parts)
            {
                Type type = part.GetType();

                var func = type.GetMethod(method);

                // 찾는 메소드가 없는 경우 func에 null 전달됨.
                if(func != null)
                {
                    func.Invoke(part, null); // 메세지
                }
            }
        }


        // GameObject Component 추가
        public void AddPart(Component part)
        {
            _parts.Add(part);
        }

        // GameObject Component 제거
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

        // obj 객체에 Component를 추가
        obj.AddPart(new ReflectionCom.Apart("머리"));
        obj.AddPart(new ReflectionCom.Bpart("가슴"));
        obj.AddPart(new ReflectionCom.Cpart("총"));
        obj.AddPart(new ReflectionCom.Apart("다리"));
        obj.AddPart(new ReflectionCom.Cpart("대포"));

        obj.SendMessage("Update");

        Debug.Log("Awake call");

        obj.SendMessage("Awake");

    }

}
