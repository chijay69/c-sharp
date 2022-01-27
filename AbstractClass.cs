using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AbstractClassDemo
{
	abstract class MyAbstractClass
	{
		private string message = "Hello C#";
		
		public void PrintMessage()
		{
			Console.WriteLine(message);
		}
		
		public abstract void PrintMessageAbstract();
		//public abstract void MyAbstractMethod();
		//abstract class methods
	}


	class ClassA : MyAbstractClass
	{
		public override void PrintMessageAbstract()
		{
			Console.WriteLine("C# is fun!");
		}
	}

	
	class Program{
	      static void Main(string[] args)
	      {
		//MyAbstractClass abClass = new MyAbstractClass();
		ClassA a = new ClassA();
		a.PrintMessage();
		a.PrintMessageAbstract();
		Console.Read();
	      }
	}
}