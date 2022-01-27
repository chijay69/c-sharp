using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace HelloWorld{
	  //A Simple Program to display the words Hello World
	  class hello{
	  	static void Main(string[] args){
		       Console.WriteLine("Hello World from C#");
		       int counter = 1;
		       Console.WriteLine(++counter);
		       decimal counter1 = (decimal) 1;
		       Console.WriteLine(counter1);
		       int[] userAge = new int[5];
		       Console.WriteLine("userAge array first element before initializing: "+userAge[0]);
		       userAge = new [] {21, 22, 23, 24, 25};
		       Console.WriteLine("After intializing: "+userAge[0]);
		       int [] source = {12, 1, 5, -2, 16, 14};
		       Console.WriteLine("first ele in source array: "+source[0]);
		       int [] dest = {1, 2, 3, 4};
		       Console.WriteLine("1st element in dest Array: " + dest[0]);
		       Array.Copy(source, dest, 3);
		       Console.WriteLine("After copy method: "+dest[0]);
		       int [] numbers = {12, 1, 5, -2, 16, 14};
		       Console.WriteLine("1st ele in num array: "+numbers[0]);
		       Array.Sort(numbers);
		       Console.WriteLine("first ele after Sort method"+numbers[0]);
		       string myName = "Hello World, my name is Jamie";
		       Console.WriteLine("String:" + myName);
		       Console.WriteLine("Length of string:" + myName.Length);
		       string splitMethod = "Peter, John; Andy,,David";
		       string [] sep = {",",";"};
		       
		       string [] subStr = splitMethod.Split(sep,StringSplitOptions.None);
		       string [] subStr0 = splitMethod.Split(sep,StringSplitOptions.RemoveEmptyEntries);
		       Console.WriteLine("2nd ele in split method: "+subStr[1]);
		       Console.WriteLine(subStr0[1]);
		       //declare list without initializing
		       List<int> userAgeList = new List<int> {11,21,31,41};
		       Console.Write("userAgeList 1st ele: "+ userAgeList[0] + ". There are: "+ userAgeList.Count +" elements.");
		       //Add to list
		       userAgeList.Add(51);
		       Console.WriteLine(" userAgeList added ele: "+ userAgeList[4] + ". There are: "+ userAgeList.Count +" elements.");
		       userAgeList.Insert(0,10);
		       Console.WriteLine("Inserted ele in 1st pos: "+userAgeList[0]);
		       Console.Write("Does userAgeList have 51?: "+userAgeList.Contains(51)+". We would remove 51 using the remove method. Does userAgeList contain 51?: ");
		       userAgeList.Remove(51);
		       Console.WriteLine(""+userAgeList.Contains(51));
		       userAgeList.RemoveAt(0);
		       Console.Write("Hey we use RemoveAt to remove '" + userAgeList[0]+ "', ...the first ele. The nō of ele is now "+ userAgeList.Count);
		       Console.WriteLine(". bitch");
		       Console.WriteLine("The number is {0:F3}.", 123.45678);
		       byte results = 79;
		       Console.WriteLine("{0}! You scored {1} marks for your test.", "Good morning", results);
		       Console.WriteLine("Deposit = {0:C}. Account balance = {1:C}.", 2125, 12345.678);
		       Console.WriteLine("\nHenry:\tHis name is \nMike:\tAlozie Victor.\nAlozie:\tI am 5'9\" tall");
		       
		       //I/O procedures

		       int userAge0 = 0;
		       int currentYear = 0;
		       string userName = "";
		       Console.Write("Please enter your name: ");
		       userName = Console.ReadLine();
		       Console.Write("Please enter your age: ");
		       userAge0 = Convert.ToInt32(Console.ReadLine());
		       Console.Write("Please enter the current year: ");
		       currentYear = Convert.ToInt32(Console.ReadLine());
		       Console.Write("Enter your grade: ");
		       string userGrade = Console.ReadLine();
		       
		       if (userAge0 < 0 || userAge0 > 100)
		       {
		       Console.WriteLine("Invalid Age");
		       Console.WriteLine("Age must be between 0 and 100");
		       }
		       else if (userAge0 < 18)
		       Console.WriteLine("Sorry you are underage");
		       else if (userAge0 < 21)
		       Console.WriteLine("You need parental consent");
		       else
		       {
		       Console.WriteLine("Congratulations!");
		       Console.WriteLine("You may sign up for the event!");
		       }
		       switch (userGrade)
		       {
		       case "A+":
		       case "A":
		       Console.WriteLine("Distinction");
		       break;
		       case "B":
		       Console.WriteLine("B Grade");
		       break;
		       case "C":
		       Console.WriteLine("C Grade");
		       break;
		       case "D":
		       case "E":
		       case "F":
                       Console.WriteLine("Fail");
                       break;
		       default:
		       Console.WriteLine("No Grade Input\nEnter Grade.");
		       break;
		       }
		       Console.WriteLine("Hello World! My name is {0} and I am {1}. I was born in {2}.", userName, userAge0>21? "an adult":"a minor", currentYear - userAge0);
		       for (int i=0; i<5; i++){
		       if (i==3){
		       Console.WriteLine(userAgeList[i]);
		       break;
		       }
		       Console.Write("{0}, ",userAgeList[i]);
		       }
		       char[] message = { 'H', 'e', 'l', 'l', 'o' };
		       int counterup=0;
		       foreach (char c in message)
		       counterup++;
		       while (counterup > 0)
		       {
		       Console.WriteLine("Counter = {0}", counterup);
		       counterup = --counterup;
		       }
		       int numerator, denominator;
		       Console.Write("Error handling section\nPlease enter the numerator: ");
		       numerator = Convert.ToInt32(Console.ReadLine());
		       Console.Write("Please enter the denominator: ");
		       denominator = Convert.ToInt32(Console.ReadLine());
		       try
		       {
		       Console.WriteLine("The result is {0}.", numerator/denominator);
		       }
		       catch (Exception e)
		       {
		       Console.WriteLine(e.Message);
		       }
		       finally{
		       Console.WriteLine("---- End of Error Handling Example ----");
		       }
		       int choice = 0;

		       int[] nums = { 10, 11, 12, 13, 14, 15 };
		       Console.Write("Please enter the index of the array: ");
		       try
		       {
		       choice = Convert.ToInt32(Console.ReadLine());
		       Console.WriteLine("nums[{0}] = {1}", choice, nums[choice]);
		       }
		       catch (IndexOutOfRangeException)
		       {
		       Console.WriteLine("Error: Index should be from 0 to 5.");
		       }
		       catch (FormatException)
		       {
		       Console.WriteLine("Error: You did not enter an integer.");
		       }
		       catch (Exception e)
		       {
		       Console.WriteLine(e.Message);
		       }
		       Console.Read();
		}
	  }	  

}
