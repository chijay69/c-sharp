using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PaySlip
{
class Program
{
static void Main(string[] args)
{
List <Staff> myStaff = new List<Staff>();
FileReader fr = new FileReader();
int month = new int();
int year = new int();
month=0;
year=0;

while (year == 0)
{
Console.Write("\nPlease enter the year: ");

try
{
//Code to convert the input to an integer
year = Convert.ToInt32(Console.ReadLine());
}
catch (FormatException)
{
//code to handle exception
Console.WriteLine("Wrong input.\nEnter correct year values");
}
}


while (month == 0)
{
Console.Write("\nPlease enter the month: ");

try
{
//Code to convert the input to an integer
month = Convert.ToInt32(Console.ReadLine());

if (month > 0 || month < 12)
{

}
else
{
Console.WriteLine("Wrong input.\nEnter values between 1-12");
month=0;//re-assigns month to 0
}//closed if-else

}//closed try block

catch (FormatException)
{
//code to handle exception
Console.WriteLine("Wrong input.\nEnter integers only");
}//closed catch block

}// closed loop

myStaff = fr.ReadFile();


for (int i = 0; i < myStaff.Count; i++)
{
try
{
Console.Write("Enter hours worked for {0}: ", myStaff[i].NameOfStaff);
myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());

myStaff[i].CalculatePay();
Console.WriteLine("{0}", myStaff[i].ToString());
}
catch (Exception e)
{
Console.WriteLine(e.Message);
i--; //iterate again
}
}

PaySlipClass ps = new PaySlipClass(month, year);

ps.GeneratePaySlip(myStaff);
ps.GenerateSummary(myStaff);

Console.Read();

}//closed main
}//closed program


class Staff
{
private float hourlyRate;
private int hWorked; //(backing field for HoursWorked)

public float TotalPay{ get; set;}
public float BasicPay{ get; set;}
public string NameOfStaff{ get; set;}
public int HoursWorked{
get { return hWorked; }
set { hWorked = value; }
}


public Staff(string name, float rate)
{
NameOfStaff=name;
hourlyRate=rate;
Console.WriteLine("Name: {0}\nRate: {1}",name, rate);
}//closed constructor

public virtual void CalculatePay()
{
Console.WriteLine("Calculating Pay...");
BasicPay = hourlyRate*hWorked;
TotalPay = BasicPay;
}//close method

public override string ToString()
{
return "\nName:"+NameOfStaff+" Rate: "+hourlyRate+" Total: "+TotalPay+".";
}//closed method

}//closed Class


class Manager:Staff
{
private const float managerHourlyRate = 50.00f;
public int Allowance{get; private set;}

public Manager(string name) : base(name, managerHourlyRate)
{
Console.WriteLine("Name = {0}", name);
}
public override void CalculatePay()
{
base.CalculatePay();
Allowance = 1000;

if (HoursWorked > 160)
{
TotalPay = TotalPay+Allowance;
}
//closed if statement
}// closed method

public override string ToString()
{
return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate = " + managerHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = " + BasicPay + "\nAllowance = " + Allowance + "\n\nTotalPay = " + TotalPay;
}//closed method
}//closed class


class Admin:Staff
{
private const float overtimeRate = 15.50f;
private const float adminHourlyRate = 30.00f;

public float Overtime { get; private set; }

public Admin(string name):base(name, adminHourlyRate)
{
//empty constructor just for initializing base constructor
}

public override void CalculatePay(){
base.CalculatePay();

if (HoursWorked>60){
float overtime = overtimeRate * (HoursWorked - 160);
Console.WriteLine("\n{0}", TotalPay + overtime);
}//closed if

}//closed constructor

public override string ToString()
{
return "\nNameOfStaff = " + NameOfStaff + "\nadminHourlyRate = " + adminHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = " + BasicPay + "\nOvertime = " + Overtime + "\n\nTotalPay = " + TotalPay;
}// closed method
						
}//closed class


class FileReader
{
List<Staff> myStaff = new List<Staff>();
string[] result = new string[2];
string path = "staff.txt";
string[] separator = {","};

public List<Staff> ReadFile(){
if (File.Exists(path)){
using(StreamReader sr = new StreamReader(path))
{
while(!sr.EndOfStream){
result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
if (result[1] == "Manager"){
   myStaff.Add(new Manager(result[0]));
   //creates new Manager obj and adds to list myStaff
   Console.WriteLine("Created Manager");
}//closed if
else if (result[1] == "Admin"){
     myStaff.Add(new Admin(result[0]));
     //creates new Admin obj and adds to list myStaff
     Console.WriteLine("Created Admin");
}//closed else-if

else{
	Console.WriteLine("Error: type unknown\n{0}");
}//closed else

}//closed while loop

sr.Close();
}//closed reader
}//closed if
else
{
Console.WriteLine("File Not Found.");
}//closed else
return myStaff;
}//closed method
}//closed class


class PaySlipClass
{
private int month;
private int year;
enum MonthsOfYear
{
JAN, FEB, MAR, APR, MAY, JUNE, JULY, AUG, SEP, OCT, NOV, DEC
}

public PaySlipClass (int monthOfPay, int yearOfPay)
{
month = monthOfPay;
year = yearOfPay;
}//close constructor

public void GeneratePaySlip(List<Staff>myStaff)
{
string path;

foreach (Staff f in myStaff)
{
path = f.NameOfStaff;
path = path + ".txt";

using(StreamWriter sw = new StreamWriter(path))
{
sw.WriteLine("\n");
sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
sw.WriteLine("==============================================");
sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
sw.WriteLine("");
sw.WriteLine("BasicPay: {0:C}", f.BasicPay);

if (f.GetType() == typeof(Manager))
{
sw.WriteLine("");
sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
}//close if
else if (f.GetType() == typeof(Admin))
{
sw.WriteLine("");
sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);
}else
{
Console.WriteLine("Error1");
}//close else

sw.WriteLine("");
sw.WriteLine("==============================================");
sw.WriteLine("TotalPay: {0:C}", f.TotalPay);
sw.WriteLine("==============================================");
sw.Close();
}// close sw

}//close loop

}//close method

public void GenerateSummary(List<Staff>mystaffs)
{
var result =
          from cust in mystaffs
          where cust.HoursWorked < 10
          orderby cust.NameOfStaff ascending
          select new { cust.NameOfStaff, cust.HoursWorked };


string path = "summary.txt";

using(StreamWriter sw = new StreamWriter(path))
{
sw.WriteLine("Staff with less than 10 working hours\n");
foreach(var staff in result)
{
sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", staff.NameOfStaff, staff.HoursWorked);
}
// close loop

sw.Close();

}//close streamreader

}//close method
}//close class

}
