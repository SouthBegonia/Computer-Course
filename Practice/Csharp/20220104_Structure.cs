using System;

namespace CsharpExam
{
    public class _20220104_Structure
    {
        static void Main(string[] args)
        {
            Transform t = new Transform();

            //Compiler Error CS1612  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs1612
            t.v.x = 1;

            //Fix
            Vector tempV = t.v;
            tempV.x = 1;
            t.v = tempV;

            t.ShowV();
            Console.Read();
        }


        public struct Vector
        {
            public float x;
            public float y;
            public float z;
        }

        public class Transform
        {
            Transform()
            {
                Vector newV = new Vector();
                newV.x = 1;
                newV.y = 2;
                newV.z = 3;

                v = newV;
            }

            public Vector v { get; set; }

            public void ShowV()
            {
                Console.WriteLine(v.x + "..." + v.y + "..." + v.z);
            }
        }
    }
}