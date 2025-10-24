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
        // �ʵ�
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

            // mons ��ü�� Ÿ�� ������ ������ �´�.
            Type type = mons.GetType();

            PrintInterfaces(type); // �ش� Ÿ���� interface ����� �����´�.
            PrintFields(type); // �ش� Ÿ���� �ʵ� ����� ������ �´�.
            PrintProperties(type); // �ش� Ÿ���� ������Ƽ ����� ������ �´�.
            PrintMethods(type); // �ش� Ÿ���� �޼ҵ� ����� ������ �´�.
        }

        /// <summary>
        /// Ŭ���� Ÿ���� interface ������ ������ �´�.
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
        /// Ŭ���� Ÿ���� �ʵ� ������ ������ �´�.
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
        /// Ŭ���� Ÿ���� �޼ҵ� ����� ������ �´�.
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
        /// Ŭ���� Ÿ���� ������Ƽ ����� ������ �´�.
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