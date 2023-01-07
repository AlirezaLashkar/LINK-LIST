using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//vase in project 2 ta tabe ADD neveshtam ke ykishe faqat 1 parametr migre va link list sade ro piade sazi mikone
//(darvaq link node akharo null mizare) va yek tabe add dige k 2 paramterie -->parametr aval data asli va parametr 2
//on node k mikhaym behesh link bshe va halqavi bshe.
//vase in ke bad az har add halqavi dshte bshim byd az tabe 2 estfde knim. 
//yani age ma az tabe 2vom estefade kardim va badesh az tabe aval estfde konim darvaqe ma yek
//link list sade va yek tarafe darim.
//vase link kardn be head kafie dar tabe 2 parametr 2 ra 0 bzrim

namespace project_2
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
        public node head;//sare ezafe
        public node last;//akhrin node
        public int numberOFNode = 0;//tedad node ha
        public linkList()
        {
            head = new node();
            last = head;
        }
        public void addNode(int data)//add krdn be entha list
                                     //bedon in ke halqavi bshe
        {
            node node = new node();//new node misazim
            node.data = data;//data node ro az karbar grftim
            last.nextNode = node;//link node akhrin node list ra node jadid qarr midhim
            last = node;//akhrin node list ra update mknim va node new ro mizrim
            numberOFNode++;
        }

        public void addNode(int data, int numNode)//add krdn be entha list va link kardn halqavi be vasat list
        {
            //mishod inja check konim age numNode > numberOFnode bod in node ro ezafe nakone
            //vali man ezafe mikonam va link list ro be sade tabdil mikonam 
            node node = new node();//new node misazim
            node.data = data;//data node ro az karbar grftim
            last.nextNode = node;//link node akhrin node list ra node jadid qarr midahim
            last = node;//akhrin node list ra update mknim va node new ro mizrim
            numberOFNode++;
            //////////////////
            node p = head;
            int pnode = 0;
            while (true)
            {
                if (pnode == numNode)//ta zamani ke be khone mored nazar reisd edame mide be peyda krdn
                    break;
                if (pnode > numNode)//age be andaze on shomre , tedad node ndshtim break kone
                {
                    p = null;
                    break;
                }
                p = p.nextNode;
                pnode++;
            }
            if(p == null)
                last.nextNode = null;////age be andaze on shomre , tedad node ndshtim link last ro null bzre
                                     ////va darvaqe mesle link list sade piade sazi bshe
            else
                last.nextNode = p;//akhrin node ra be on node ke shomaresh ro dadim link mikonim
        }

        public Boolean circular()//check krdn in ke aya link list halqavi ast ya kheyr
        {
            node p = head;
            int numnoDe = 0;//shemordan tedad node ha
            int k = 0;//age k = 0 bood yani halqavi nist
            while (true)
            {
                p = p.nextNode;
                if (p == null)//age p null bud break kone
                    break;
                numnoDe++;
                if (numnoDe > numberOFNode)//age tedad node hayii k ta alan shemorde shude az number
                                           //Of node bishtr bud yani halq darim
                {
                    k = 1;//k ro be 1 avaz mikonim ke neshon mide halqavie va break mknim
                    break;
                }
            }
            if (k == 0)//true va false ro barasae k return mknim
                return false;
            else
                return true;
        }

        public void printLinkList()
        {
            if (circular() == false)//age halghavi nabod
            {
                node p = head;
                while (true)
                {
                    if (p.nextNode == null)//har vqt be akhrin node resid baraye badish break kone va HEAD ro namayesh bde
                    {
                        Console.Write("END");
                        break;
                    }
                    Console.Write("|{0}| - - - >", p.nextNode.data);
                    p = p.nextNode;
                }
            }
            if (circular() == true)//age halqavi bud
            {
                node p = head;
                int n = 0;
                while (true)
                {
                    if (n >= numberOFNode)//har vqt be akhrin node resid baraye badish break kone va link node ro namayesh bde
                    {
                        if(last.nextNode.data == -1)//age link node akhar be avlin node link shude bud HEAD ro print kon
                            Console.Write("HEAD");
                        else
                        { 
                            Console.Write("Link To DaTa:  " + last.nextNode.data);
                        }
                        break;
                    }
                    Console.Write("|{0}| - - - >", p.nextNode.data);
                    n++;    
                    p = p.nextNode;
                }
            }
        }     
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            linkList linkList = new linkList();
            int k = 0;
            int p = 0;
            while (p == 0)
            {
                Console.WriteLine("1-Add Node in simple link list\n2-Add node in circular Link list\n3-print link list\n4-circular?" +
                    "\n5- EXIT");
 
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
                        Console.Write("Enter the Data to ADD: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the node number to Link: ");
                        int a1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        linkList.addNode(a,a1);
                        break;
                    case 3:
                        linkList.printLinkList();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write(linkList.circular());
                        Console.WriteLine();
                        break;
                    case 5:
                        p = 1;
                        break;
                }

            }
            Console.ReadKey();
        }
    }
}
