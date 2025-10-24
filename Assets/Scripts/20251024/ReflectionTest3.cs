using UnityEngine;
using System;
using System.Reflection;

namespace MyCustomer
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            this.Name = "Customer";
        }
    }
}

namespace ReflectionTest3
{
    class MyClass
    {
        public string Name { get; set; }
    }

    public class ReflectionTest3 : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            MyClass myClass = new MyClass();
            Debug.Log("MyClass Name: " + myClass.Name);

            SetDefaultName(myClass);
            Debug.Log("MyClass Name: " + myClass.Name);

            Run();
        }

        static void SetDefaultName(System.Object myObject)
        {
            PropertyInfo propertyInfo = myObject.GetType().GetProperty("Name");

            if(propertyInfo != null )
            {
                propertyInfo.SetValue(myObject, "Kim");
            }
        }

        public static void Run()
        {
            // Type 정보를 얻어온다.
            Type customerType = Type.GetType("MyCustomer.Customer");

            // 얻어온 Type으로 동적 클래스 객체를 생성
            System.Object obj = Activator.CreateInstance(customerType);

            string name = ((MyCustomer.Customer)obj).Name;

            Debug.Log(name);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
