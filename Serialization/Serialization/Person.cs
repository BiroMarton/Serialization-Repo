﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    class Person : ISerializable
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public Person(string name, DateTime birthDate)
        {

            this.name = name;
            this.birthDate = birthDate;
        }
        public enum Genders : int { Male, Female };

        public Genders gender;

        public override string ToString()
        {
            return (String.Format("name: {0}, birth date: {1}", this.name, this.birthDate));
        }

        public int CalculateAge()
        {
            int birth = (int)BirthDate.Year;
            int today = (int)DateTime.Now.Year;

            return today - birth;

        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("DOB", birthDate);

            name = info.GetString("Name");
            birthDate = info.GetDateTime("DOB");
            CalculateAge();
        }
    }
}
