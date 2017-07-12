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

        private static Person Deserialize()
        {
           

            
            FileStream fs = new FileStream("Person.Dat", FileMode.Open);

            
            BinaryFormatter bf = new BinaryFormatter();

            
            Person  dsp = (Person)bf.Deserialize(fs);

            
            fs.Close();

            return dsp;
        }
        private static int CalculateAge(Person p)
        {
            int birth = (int)p.BirthDate.Year;
            int today = (int)DateTime.Now.Year;

            return today - birth;

        }

        static void Main(string[] args)
        {
            if(args.Length > 3) { 
            Person person = new Person(args[0], new DateTime(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3])));;
            Serialize(person);
            }
            else {
                Person dsp = Deserialize();

                Console.WriteLine(dsp.Name);
                Console.WriteLine(dsp.BirthDate);
                Console.WriteLine(CalculateAge(dsp));
                Console.ReadKey();
            }





        }
    }
}
