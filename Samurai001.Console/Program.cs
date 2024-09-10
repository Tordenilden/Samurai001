using System.Diagnostics;

namespace Samurai001.Cons
{
    public class Program
    {
        public delegate void TestDelegate();
        public delegate bool TestBoolDelegate(int i);
        // Define the delegate
        public static TestDelegate testDelegateFunction;
        public static TestBoolDelegate testBoolDelegateFunction;


        public static Func<bool> testFunc;
        public static Func<int, bool> testBoolFunc;
        
        static void Main(string[] args)
        {
            // step 1
            //testDelegateFunction = MyFunction1;
            //testDelegateFunction();
            //testDelegateFunction = MyFunction2;
            //testDelegateFunction();

            // step 2
            testBoolDelegateFunction = MyBoolFunction;
            Console.WriteLine(testBoolDelegateFunction(8));

            // step 3
            testDelegateFunction = delegate () { Console.WriteLine("Anonymous method"); };
            testDelegateFunction();

            // step 4
            testDelegateFunction = () => { Console.WriteLine("Anonymous method version 2"); };
            testDelegateFunction();
            // step 5 - nu skal I skrive testBoolDelegateFunction med delegate
            // step 6 - nu skal I skrive testBoolDelegateFunction med Anonymeous function

            // step 7 - Func
            testFunc = () => { return false; };
            testFunc = () => false;
            testBoolFunc = (int i) => i < 10;
            // step 8 
            Console.WriteLine(testFunc());
            Console.WriteLine(testBoolFunc(6));
            // step 9 - Func, Prøv at sætte testBoolFunc til en "rigtig metode" og Invoke the method!! 

        }
        public static void MyFunction1()
        {
            Console.WriteLine("test 1");
        }        
        public static void MyFunction2()
        {
            Console.WriteLine("test 2");
        }       
        public static bool MyBoolFunction(int i)
        {
            return i < 10;
        }

        public static bool TestingDelegates(TestBoolDelegate obj)
        {

            return true;
        }


    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public static getAllStudents()
        //{

        //}
        public bool StortBogstav(string stort) { return true; }
    }
}
