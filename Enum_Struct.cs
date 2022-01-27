using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EnumStruct
{
	class Program{
	static void Main(string[] args)
	{
	DaysOfWeek myDays = DaysOfWeek.Mon;
	Console.WriteLine(myDays);
	MyStruct example = new MyStruct(2, 3, 5);
	example.PrintStatement();
	}//closed Main
	
	}//closed Program
	
	enum DaysOfWeek
	{
	Sun = 1, Mon = 2, Tues, Wed, Thurs, Fri, Sat
	}// closed enum

	struct MyStruct
	{
	//Fields
	private int x, y;
	private AnotherClass myClass;
	private Days myDays;

	//Constructor
	public MyStruct(int a, int b, int c)
	{
        myClass = new AnotherClass();
        myClass.number = a;
        x = b;
        y = c;
        myDays = Days.Mon;
	}
	//Method
	public void PrintStatement()
	{
        Console.WriteLine("x = {0}, y = {1}, myDays = {2}", x, y, myDays);
	}
	}// closed struct

	class AnotherClass
	{
	public int number;
	}// closed class

	enum Days { Mon, Tues, Wed }
}
