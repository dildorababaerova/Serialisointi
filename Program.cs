using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Globalization;
using System.ComponentModel;


namespace Serialisointi
{
    [Serializable]

    class Student
    {
        //Fields
        string firstname;
        string lastname;
        string dateOfBirth;
        int startYear;
        int endYear;
        string occupation;


        // Properties

        public string Firstname {  get { return firstname; } set {  firstname = value; } }
        public string Lastname { get { return lastname; } set {  lastname = value; } }  
        public string DateOfBirth { get {  return dateOfBirth; } set { } }
        public int StartYear { get {  return startYear; } set {  startYear = value; } }
        public int EndYear { get { return endYear; } set {  endYear = value; } }
        public string Occupation { get { return occupation; } set { occupation = value; } }


        // Constructor

        public Student()

        {
            this.firstname = "Etunimi";
            this.lastname = "Sukunimi";
            this.dateOfBirth = "1970-12-31";
            this.startYear = 2000;
            this.endYear = 2025;
            this.occupation = "Ohjelmistokehittaja";
        }


        public Student(string firstname, string lastname, string dateOfBirth, int startYear, int endYear, string occupation) 
        {
            this.firstname = firstname;
            this.lastname = lastname;   
            this.dateOfBirth = dateOfBirth;
            this.startYear = startYear;
            this.endYear = endYear;
            this.occupation = occupation;
        }
        // Methods
        public void ShowStudentDetails()
        {
            Console.WriteLine("Opiskelijan tiedot ");
            Console.WriteLine("--------------------");
            Console.WriteLine("Tutkinto: " + this.occupation);
            Console.WriteLine("Etunimi: " + this.firstname);
            Console.WriteLine("Sukunimi: " + this.lastname);
            Console.WriteLine("Syntymäpäivä: " + this.dateOfBirth);
            Console.WriteLine("Alkuvuosi" + this.startYear);
            Console.WriteLine("Loppuvuosi" + this.endYear);
            
        }

        public void CalculateSchoolPeriod()
        {
            Console.WriteLine("Opiskelu vuosi: " + (endYear - startYear));

                }


    }
    internal class Program
    {
        static void Main(string[] args)
        {

            // Create an array of Student objects

            Student[] student = new Student[3];

            student[0] = new Student("Vladimir", "Putin", "1941",  2012, 2015, "Lakimies");
            


            student[1] = new Student("Emmanuel", "Macron", "1976-12-12", 2021, 2023, "Tanssi koulu tanssija");
            


            student[2] = new Student("Chin", "Kim", "1978-06-06", 2022, 2025, "Puolustus akademian kapteeni" );
            

            
            // Create binary formatter
            IFormatter formatter = new BinaryFormatter();


            // Create a stream for writting to the file
            Stream writeStream = new FileStream("Students.dat", FileMode.Create, FileAccess.Write);


            // Serialize to the file
            formatter.Serialize(writeStream, student);

            writeStream.Close();

            // Create a stream for reading data from the file

            Stream readStream = new FileStream("Students.dat", FileMode.Open, FileAccess.Read);

            Student[] studentFromDisk;

            // Deserialize from the file

            studentFromDisk = (Student[])formatter.Deserialize(readStream);
            readStream.Close();

            // Show all data in a loop
            foreach (var item in studentFromDisk)
            {
                item.ShowStudentDetails();
                item.CalculateSchoolPeriod();
                Console.WriteLine();
            }
            Console.ReadLine();       
                        
        }
    }
}

        