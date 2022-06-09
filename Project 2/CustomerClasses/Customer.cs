using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClasses
{
    public class Customer
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Address { set; get; }

        public Dictionary<string, bool> Interests { set; get; }  //In my project2 solution I haved declared a dictionary of Interests. 

        //other option could be a List as:
        public List<string> InterestsList;

        public Customer()
        {
            FirstName = " ";
            LastName = " ";
            Address = " ";
            InterestsList = new List<string>();
        }
        public Customer(string fname, string lname, string address)
        {
            FirstName = fname;
            LastName = lname;
            Address = address;
            InterestsList = new List<string>();
        }
            public Customer(string fname, string lname, string address, int intrests)
        {
            FirstName = fname;
            LastName = lname;
            Address = address;
            InterestsList = new List<string>();

                if (intrests == 211)
                {
                    InterestsList.Add("Epost");
                }
                else if (intrests == 121)
                {
                    InterestsList.Add("Events");
                }
                else if (intrests == 112)
                {
                    InterestsList.Add("Info");
                }
                else if (intrests == 221)
                {
                    InterestsList.Add("Epost");
                    InterestsList.Add("Events");
                }
                else if (intrests == 212)
                {
                    InterestsList.Add("Epost");
                    InterestsList.Add("Info");
                }
                else if (intrests == 122)
                {
                    InterestsList.Add("Events");
                    InterestsList.Add("Info");
                }
                else if (intrests == 222)
                {
                    InterestsList.Add("Epost");
                    InterestsList.Add("Events");
                    InterestsList.Add("Info");
                }

            {

            }
        }
        
    }
}
