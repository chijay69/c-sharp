using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace LambdaExpression {
class Program {
      static void Main(string[] args)
      {
	//list to store numbers
	List <int> numbers = new List <int> () {36, 71, 12, 15, 29, 18, 27, 17, 9, 34};
	//foreach loop to display list items
	foreach(var item in numbers)
	{
		Console.Write("{0}, ", item);
	}
	Console.WriteLine();
	//using lambda to calculate the square of each item in list
	var numbersSquare = numbers.Select(x => x*x);
	Console.Write("Squares: ");
	foreach(var value in numbersSquare)
	{
		Console.Write("{0}, ",value );
	}
	Console.WriteLine();
	// Using Lambda expression to find all numbers divisible by 3
	var numbersDivisibleBy3 = numbers.FindAll(x=>(x%3 == 0));
	Console.Write("Numbers Divisible By 3: ");
	foreach(var value in numbersDivisibleBy3)
	{
		
		Console.Write("{0}, ",value );
	}
	Console.WriteLine();

	//List with each element of student type
	List <Student> students = new List <Student> ()
	{
	new Student(1, "Liza"),
	new Student(2, "Stewart"),
	new Student(3, "Tina"),
	new Student(4, "Stefani"),
	new Student(5, "Trish"),
	new Student(3, "Stella"),
	};


        // To sort the details list

        // based on name of student

        // in ascending order of name and RollNo

        var newStudents = students.OrderBy(x => x.Name);
	newStudents  = newStudents.OrderBy(x => x.RollNo);

	Console.WriteLine("Reorder student alphabetically");
	foreach (var value in newStudents)
	{
	Console.WriteLine("Name: {1}, Roll: {0}", value.RollNo, value.Name);		
	}

	Console.WriteLine();
	
      }// close Main

}//close Program


	 class Student{
	       string name = "None";
	       int no = 0;
	       
	       //methods
	       public int RollNo
	       {
		get { return no; }
	       	private set { no = value; }
	       }
	       
	       public string Name
	       {
	       get { return name; }
	       private set { if(name != ""){ name=value; } }
	       }
	       
	       public Student()
	       {
		Console.WriteLine("Student Class... ");
	       }
	       
	       public Student(int num, string nam)
	       {
		no = num;
		name = nam;
		Console.WriteLine("Student Class...\n");
	       }
	       
	       //public override string ToString()
	       //{
		//Console.WriteLine("\nName: {0}, Roll: {1}", RollNo, Name);
	       //}
	       
	 }
}