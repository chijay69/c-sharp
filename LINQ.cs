using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LinqData{

	  class Customer{
	  	public string name, ID, addr;
		public decimal amt;
		//constructor
		public Customer(string fullName, string bankId, string Addr, decimal cash)
		{
			name = fullName;
			ID = bankId;
			addr = Addr;
			amt = cash;
			Console.WriteLine("\n"+name+":\tAcct ID: "+ID+",  Address: "+addr+",  Balance: "+amt);
			Console.WriteLine("--------------------------");
		}
		public override string ToString()
		{
			return "\n"+name+":\tAcct ID: "+ID+" Address: "+addr+" Balance: "+amt+".";
		}
	  }
	  	  
	  class Program{
	  static void Main(string[] args)
	  {
	  //execution

	    int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };
	    	    var evenNumQuery =
		    	  from num in numbers
			         where (num % 2) == 0
				         select num;
					 
	  foreach (int i in evenNumQuery)
	  {
	  if (i == 0)
	     continue;
	  Console.WriteLine("{0} is an even number", i);
	  }//closed loop
	  
	  List <Customer> customers = new List <Customer>();
	  
	  customers.Add(new Customer("Alan", "80911291", "ABC Street", 25.60m));
	  customers.Add(new Customer("Bill", "19872131", "DEF Street", -32.1m));
	  customers.Add(new Customer("Carl", "29812371", "GHI Street", -12.2m));
	  customers.Add(new Customer("David", "78612312", "JKL Street", 12.6m));
	  
	  var overdue =
	  from cust in customers
	  where cust.amt < 0
	  orderby cust.amt ascending
	  select new { cust.name, cust.amt };

	  Console.WriteLine("DEBTORS");
	  Console.WriteLine("-------------------------------");
	  //loop through dataset
	  foreach (var cust in overdue)
	  {
	  //output result
	  Console.WriteLine("Name = {0}, Balance = {1}", cust.name, cust.amt);
	  }//closed loop

	  string path = "myFile.txt";
	  try
	  {
	  using (StreamReader sr = new StreamReader(path))
	  {
		while (sr.EndOfStream != true)
	  	{
			Console.WriteLine(sr.ReadLine());
	        }
	  sr.Close();
	  }//closed fileReader
	  }//closed try statement
	  catch (FileNotFoundException e)
	  {
	  Console.WriteLine(e.Message);
	  }//closed catch statement

	  //another file method

	  if (File.Exists(path))
	  {
	  using (StreamReader sr = new StreamReader(path))
	  {
	  while (!sr.EndOfStream)
	  {
	  Console.WriteLine(sr.ReadLine());
	  }//closed loop
	  sr.Close();
	  }//close file
	  }
	  else
	  {
	  //Do something else
	  Console.WriteLine("Can not find file:  "+path);
	  }//closed if statement

	  //declaring the path to the filestring
	  path = "myFile.txt";??
	  //Writing to the file
	  using(StreamWriter sw=new StreamWriter(path, true))
	  {
	  sw.WriteLine("ABC");
	  sw.WriteLine("DEF");
	  sw.Close();
	  }
	  
	  }//closed Main
	  }//closed Program
}