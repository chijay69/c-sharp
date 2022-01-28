
// C# program to illustrate how to  
// create an anonymous function 

using System; 

    public delegate void Show(string x);

class GFG { 

    
    // identity method with two parameters
    public static void identity(Show mypet, string color)
    {

        color = " Black" + color;

        mypet(color);
    }

    public delegate void petanim(string pet); 

  

    // Main method 

    static public void Main() 

    { 



        // Here anonymous method pass as 

        // a parameter in identity method

        identity(delegate(string color) { 

          Console.WriteLine("The color of my dog is {0}", color); }, "White");


  
	string fav = "Rabbit";
	
        // An anonymous method with one parameter 

        petanim p = delegate(string mypet) 

        { 

            Console.WriteLine("My favorite pet is: {0}", mypet);
	    // Accessing variable defined

            // outside the anonymous function

	    Console.WriteLine("And I like {0} also.", fav);
						 
        }; 

        p("Dog"); 

    }
}