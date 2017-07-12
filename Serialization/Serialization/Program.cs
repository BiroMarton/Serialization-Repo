using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    class Program


    {
        private static void Serialize(Person sp)
        {
            
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);

            
            BinaryFormatter bf = new BinaryFormatter();

            
            bf.Serialize(fs, sp);

            
            fs.Close();
        }

            static void Main(string[] args)
        {

            Person person = new Person(args[0], new DateTime(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3])));;
            Serialize(person);


  
            
        }
    }
}
