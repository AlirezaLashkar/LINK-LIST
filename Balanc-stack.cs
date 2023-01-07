using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_3
{
    public class node
    {
        public char data;// tarif node k faqat Char migire 
        public node nextNode;
        public node()
        {
            data = ' ';//vase avlin bar Char ro space mizarim
            nextNode = null;
        }
    }
    public class stack
    {
        public node top;//node vase tey krdn stack 
        public int numberOFNode = 0;//tedad node ha
        public stack()
        {
            top = new node();
        }
        public void addNode(char data)
        {
            node p = new node();
            p.data = data;
            p.nextNode = top;//link top hamishse be yek khone qabli eshare mikone
            top = p;
            numberOFNode++;//tedad node ha ro yki ziad mikonim
        }
        public void DeleteNode()
        {
            top = top.nextNode;//top ro node qabli mizarim
            numberOFNode--;//tedad node ha ro yki kam mikonim
        }

        public void BaLans(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                node q = top;//node qable top ro save mikone
                addNode(s[i]);
                if (s[i] == ')' && q.data == '(') //age node qabli ) , ( bod har 2ta ro az stack kharej kone
                {
                    DeleteNode();
                    DeleteNode();
                }
                if (s[i] == ']' && q.data == '[')//age node qabli ] , [ bod har 2ta ro az stack kharej kone
                {
                    DeleteNode();
                    DeleteNode();
                }
                if (s[i] == '}' && q.data == '{')//age node qabli } , { bod har 2ta ro az stack kharej kone
                {
                    DeleteNode();
                    DeleteNode();
                }
            }
            if (isEmpty() == true)//age stack khali bod yani on string balance bude
                Console.WriteLine("It is BaLance");
            else
                Console.WriteLine("It is not BaLance");
        }

        public Boolean isEmpty()//age tedad node ha 0 shud yani stack khalie
        {
            if(numberOFNode == 0)
                return true;
            else
                return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //mesal haye proje
            Console.WriteLine("EX : (){}");
            stack s = new stack();
            string q = "(){}";
            s.BaLans(q);
            Console.WriteLine("------------");
            Console.WriteLine("EX : (([()]){})");
            stack s2 = new stack();
            string w = "(([()]){})";
            s2.BaLans(w);
            Console.WriteLine("------------");
            Console.WriteLine("EX : ((){)}");
            stack s3 = new stack(); 
            string e = "((){)}";
            s3.BaLans(e);
            Console.WriteLine("------------");
            Console.WriteLine("EX : {(]()]}");
            stack s4 = new stack();
            string r = "{(]()]}";
            s4.BaLans(r);
            Console.WriteLine("---------------");

            //vorodi del khah
            int h = 1;
            while (true)
            {
                Console.WriteLine("Enter 0 TO Exit and 1 to Continue : ");
                Convert.ToInt32(Console.ReadLine());
                if (h == 0) break;

                stack s1 = new stack();
                Console.Write("Enter the string:  ");
                string k = Console.ReadLine();
                s1.BaLans(k);

            }

            
            
            Console.ReadKey();
        }
    }
}
