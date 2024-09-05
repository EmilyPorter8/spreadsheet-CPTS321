//Emily Porter
//011741612
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Node
    {
        //attributes
        public float Data; //data of node
        public Node Left; //left child
        public Node Right; //right child

        //constructors
        public Node() //if no arguement is passed
        { Data = 0;
            Left = null;
            Right = null;
        }

        public Node(float newData) //if data is passed
        { Data = newData; }

        //I am unsure if destructors are necassary for C#
        ~Node()
        { Data = 0;
            Left = null;
            Right = null;
        }
    }
}
