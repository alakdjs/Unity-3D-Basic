using System.Reflection;
using UnityEngine;
using System;
using Packages.Rider.Editor;
using Test;

namespace Test
{
    public interface Move
    {
        void Move();
    }

    class Monster : Move
    {
        // 필드
        private int _health;
        private string _name;
        private string _description;

        // property
        public int Health
        {
            get { return _health; }
        }

        public Monster() { }

        // method
        public void Attack()
        {
            _health = 0;
        }

        public int GetHealth()
        {
            return _health;
        }

        // interface
        public void Move()
        {
            _health += 1;
        }
    }
}

namespace ReflectionTest2
{

    public class ReflectionTest2 : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Monster mons = new Monster();

            // mons 객체의 타입 정보를 가지고 온다.
            Type type = mons.GetType();

            PrintInterfaces(type); // 해당 타입의 interface 목록을 가져온다.
            PrintFields(type); // 해당 타입의 필드 목록을 가지고 온다.
            PrintProperties(type); // 해당 타입의 프로퍼티 목록을 가지고 온다.
            PrintMethods(type); // 해당 타입의 메소드 목록을 가지고 온다.
        }

        /// <summary>
        /// 클래스 타입의 interface 정보를 가지고 온다.
        /// </summary>
        /// <param name="type"></param>
        static void PrintInterfaces(Type type)
        {
            Debug.Log("----------------------- interfaces -----------------------");
            Type[] interfaces = type.GetInterfaces();

            foreach (Type i in interfaces)
            {
                Debug.Log($"Name:: {i.Name}");
            }
        }

        /// <summary>
        /// 클래스 타입의 필드 정보를 가지고 온다.
        /// </summary>
        /// <param name="type"></param>
        static void PrintFields(Type type)
        {
            Debug.Log("\n----------------------- Fields -----------------------");
            FieldInfo[] fields = type.GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                String accesLevel = "protected";
                if (field.IsPublic)
                {
                    accesLevel = "public";
                }
                else if (field.IsPrivate)
                {
                    accesLevel = "private";
                }

                Debug.Log($"Access: {accesLevel}, Type: {field.FieldType.Name}, Name: {field.Name}");
            }
        }

        /// <summary>
        /// 클래스 타입의 메소드 목록을 가지고 온다.
        /// </summary>
        /// <param name="type"></param>
        static void PrintMethods(Type type)
        {
            Debug.Log("----------------------- Methods -----------------------");

            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Debug.Log($"Type: {method.ReturnType.Name}, Name: {method.Name}, Parameter: ");

                ParameterInfo[] args = method.GetParameters();

                for (int i = 0; i < args.Length; i++)
                {
                    Debug.Log($"{args[i].ParameterType.Name}");
                    if (i < args.Length - 1)
                    {
                        Debug.Log(", ");
                    }
                }
                Debug.Log("\n");
            }
        }

        /// <summary>
        /// 클래스 타입의 프로퍼티 목록을 가지고 온다.
        /// </summary>
        /// <param name="type"></param>
        static void PrintProperties(Type type)
        {
            Debug.Log("----------------------- propertiec -----------------------");

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Debug.Log($"Type: {property.PropertyType.Name}, Name: {property.Name}");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}