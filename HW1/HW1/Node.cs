using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Node
    {
        public float Data;
        public Node Left;
        public Node Right;

        public Node() 
        { Data = 0;
            Left = null;
            Right = null;
        }

        public Node(float newData)
        { Data = newData; }

        ~Node()
        { Data = 0;
            Left = null;
            Right = null;
        }
    }
}
