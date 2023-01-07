using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class node 
    {
        public int data;
        public node nextNode;
        public node()
        {
            data = -1;//data first ya hmun head ya sare ezafe ro -1 mizrim
            nextNode = null;
        }
    }
    public class linkList
    {
        public node head;//sare ezafe(first)
        public node last;//akhrin node
        public int numberOFNode = 0;//tedad node ha
        public linkList()
        {
            head = new node();
            last = head;
            last.nextNode = head;
        }
        public void addNode(int data)//add krdn be entha list
        {
            node node = new node();//new node misazim
            node.data = data;//data node ro az karbar grftim
            last.nextNode = node;//link node akhrin node list ra node jadid qarr midhim
            last = node;//akhrin node list ra update mknim va node new ro mizrim
            last.nextNode = head;//akhrin node ra be avlin node link mikonim
            numberOFNode++;
        }
        public void delete(int data)//delete krdn yek data khas dar hameye khane ha
        {
            if (isEmpty() == true)
            {
                Console.WriteLine("We don't have Node to delete");
            }
            else
            {
                node q = head;
                node p = head.nextNode;
                while (p != head)
                {
                    if (p.data == data)
                    {
                        q.nextNode = p.nextNode;//link qablisho link node badie node mored nazzar bezr
                        numberOFNode--;//az tedad node ha kam mikonim
                    }
                    else
                        q = p;
                    p = p.nextNode;
                }
            }

            
        }
        public void printList()//print krdn list
        {
            node p = head;
            while(true)
            {
                if(p.nextNode == head)//har vqt be akhrin node resid baraye badish break kone va HEAD ro namayesh bde
                {
                    Console.Write("HEAD");
                    break;
                }
                Console.Write("|{0}| - - - >", p.nextNode.data);
                p = p.nextNode;
            }
        }
        public void print()//tabe print ke sare ezafe ro ham print mikone
        {
            node p = head;
            int k = 0;
            while (true)
            {
                if (p == head)//har vqt be akhrin node resid baraye badish break kone va HEAD ro namayesh bde
                {
                    if (k == 0)
                    {
                        k = 1;
                    }
                    else
                    {
                        Console.Write("HEAD");
                        break;
                    }

                }
                Console.Write("|{0}| - - - >", p.data);
                p = p.nextNode;
            }
        }
        public void reversList()//makos krdn yek link list
        {
            node p = head;
            node q = null;
            while (true)
            {
                node r = q;
                q = p;
                p = p.nextNode;
                q.nextNode = r;
                if(p == head)
                    break;
            }
            head = q;
            last = p;
            last.nextNode = head;
        }
        public void printReversList(node p)//chap barax list noe 1 (orginal)
        {
            if (p.nextNode != head)
            {
                printReversList(p.nextNode);
                if (p.data != -1)
                    Console.Write("|{0}| - - - >", p.data);
                else
                    Console.Write("HEAD");
            }
            else//be akharin node ke resid in print kone va break kone 
            {
                Console.Write("|{0}| - - - >", p.data);
            }

        }
        public void printReversList()//chap barax list noe 2 
        {
            reversList();//ebteda list ra makos mikonim
            print();//estfde az tabe 2vom print
            reversList();//halat avli link list
        }
        public bool isEmpty()//khali budn list
        {
            node p = head;
            if (p.nextNode == head) return true;
            else return false;
        }
        public void swap(int i, int j)//jabe ja krdn 2 node dar yek link list
        {
            int pnode = 0;//shomre node avali
            int qnode = 0;//shomre node dovomi
            node p = head;//node avali
            node r1 = head;//posht node avali harkat mikone
            node q = head;//node dovomi
            node r2 = head;//posht node dovom harkat mikone
            while (true)
            {
                p = p.nextNode;
                pnode++;
                if (pnode == i)//ta zamani ke be khone mored nazar reisd edame mide be peyda krdn
                    break;
                r1 = r1.nextNode;
            }
            while (true)
            {
                q = q.nextNode;
                qnode++;
                if (qnode == j)//ta zamani ke be khone mored nazar reisd edame mide be peyda krdn
                    break;
                r2 = r2.nextNode;
            }
            r1.nextNode = q;//link node qable node aval ro node dovomi mizre
            node k = q.nextNode;//zakhirde krdn node dovom dar yek node komki
            q.nextNode = p.nextNode;//link node dovom ro mizrim link node aval
            r2.nextNode = p;//link node qable node dovom ro node avali mizrim
            p.nextNode = k;//link node avali ro node dovomi mizrim
        }
    }

    public class queue//class saf
    {
        //int max = 10000; //vase tabe is full
        node front;
        node rear;
        int numberOfNode = 0;//tedad
        public queue()
        {
            front = null;
            rear = null;
        }
        public void addNode(int data)//add krdn be saf
        {
            node newnode = new node();
            newnode.data = data;
            if (front == null)//vase avlin bar va jahaiii ke add krdim va delete krdim va queue khali shude
            {
                rear = newnode;
                front = rear;//kolan dar inja front be avlin khaneii k add shude eshare mikone va rear be akhrin akhe
                numberOfNode++;
            }
            else
            {
                rear.nextNode = newnode;
                rear = rear.nextNode;
                numberOfNode++;
            }
        }
        public Boolean isEmpty()//khali budn ya nbudn saf
        {
            if(front == null) return true;//harja front = null bshe yani ma node ndrim
            else return false;  
        }
        //public Boolean isFull()
        //{
        //    if (numberOfNode == max) return true;
        //    else return false;
        //}

        public void delete()//hazf krdn node az saf k az ebteda delete miknim
        {
            if (isEmpty() == true)//ebteda tabe isempty check mishe ke aya por hast ya khali
                Console.WriteLine("Queue Is Empty");
            else
            {
                node q = front;//meqdar front ro dar yek node qarar midahim
                front = null;//front ke hmon node mored nazar baraye delete hast ro null mizrim
                front = q.nextNode;//front ro yek khone be jlo mibrim ba estfde az node komaki
                numberOfNode--;//number of node ra kahesh midahim
            }
        }
        public void printQueueE()//print krdn node haye yek saf
        {
            if (isEmpty() == true)
                Console.WriteLine("Queue Is Empty");
            else
            {
                node p = new node();
                p = front;
                while (true)
                {
                    if (p == null)
                    {
                        Console.Write("END");
                        break;

                    }
                    else
                        Console.Write("|{0}| - - - >", p.data);
                    p = p.nextNode;
                }
            }
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            linkList linkList = new linkList();
            queue q = new queue();
            while (true)
            {
                Console.WriteLine("link list : ");
                Console.WriteLine("1-Add Node\n2-Delete Node\n3-Print Link list\n4-Print Revers List\n" +
                    "5-Revers List\n6-Swap Two Node\nQueue : \n7-Add Node\n8-Delete Node\n9-Print Queue");
                Console.Write("Please specify the status: ");
                k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        Console.Write("Enter the Data to Add: ");
                        int d = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        linkList.addNode(d);
                        break;
                    case 2:
                        Console.Write("Enter the Data to Delete: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        linkList.delete(a);
                        break;
                    case 3:
                        linkList.printList();
                        Console.WriteLine();
                        break;
                    case 4:
                        linkList.printReversList(linkList.head);
                        Console.WriteLine();
                        break;
                    case 5:
                        linkList.reversList();
                        linkList.print();
                        break;
                    case 6:
                        Console.Write("Enter the first Node Number to Swap:  ");
                        int s = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the second Node Number to Swap:  ");
                        int g = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        linkList.swap(s, g);
                        break;
                    case 7:
                        Console.Write("Enter the Data to Add: ");
                        int r = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        q.addNode(r);
                        break;
                    case 8:
                        q.delete();
                        Console.WriteLine();
                        break;
                    case 9:
                        q.printQueueE();
                        Console.WriteLine();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
