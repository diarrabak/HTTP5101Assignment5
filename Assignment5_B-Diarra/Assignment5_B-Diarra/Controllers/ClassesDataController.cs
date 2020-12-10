using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Assignment5_B_Diarra.Models;
using System.Web.Http.Cors;

namespace Assignment5_B_Diarra.Controllers
{
    public class ClassesDataController : ApiController
    {
        // The school database context class allow us to access our MySQL school Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the classes table of our school database.
        /// <summary>
        /// Returns a list of modules in the system
        /// </summary>
        /// <example>GET api/classesData/ListClasses</example>
        /// <returns>
        /// A list of classes with assigned teachers name
        /// </returns>
        [HttpGet]
        public IEnumerable<ClassModule> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query will get informatiom from classes and teachers tables
            //cmd.CommandText = "SELECT classes.*,teacherfname,teacherlname FROM classes Left JOIN teachers ON classes.teacherid=teachers.teacherid";
            cmd.CommandText = "SELECT* FROM  classes";
            //This variable will contain the ghathered results
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of classes and teacher information
            List<ClassModule> classes = new List<ClassModule> { };
            Teacher professor = new Teacher();
            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                ClassModule classe = new ClassModule();   //A temporary variable to store current class
                classe.classId = (int)ResultSet["classid"];
                classe.teacherId = (int)(Int64)ResultSet["teacherid"];
                classe.classCode = ResultSet["classcode"].ToString();
                classe.className = ResultSet["classname"].ToString();
                classe.startDate = (DateTime)ResultSet["startdate"];  //Cast the result to date type
                classe.finishDate = (DateTime)ResultSet["finishdate"];  //Cast the result to date type
                

                //Add the module to the List
                classes.Add(classe);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of modules and their teachers
            return classes;
        }


        [Route("api/ClassesData/displayClasse/{id}")]

        [HttpGet]
        public ClassModule displayClasse(int id)
        {
            ClassModule classe = new ClassModule();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query will get teachers and modules taught
            cmd.CommandText = "SELECT classes.*,teacherfname,teacherlname FROM classes Left JOIN teachers ON classes.teacherid = teachers.teacherid WHERE classid=@classid";
            cmd.Parameters.AddWithValue("@classid", id);
            cmd.Prepare();

            //This variable will contain the ghathered results
            MySqlDataReader ResultSet = cmd.ExecuteReader();
            classe.professor = new Teacher();
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                classe.classId = (int)ResultSet["classid"];
                classe.teacherId = (int)(Int64)ResultSet["teacherid"];
                classe.classCode = ResultSet["classcode"].ToString();
                classe.className = ResultSet["classname"].ToString();
                classe.startDate = (DateTime)ResultSet["startdate"];  //Cast the result to date type
                classe.finishDate = (DateTime)ResultSet["finishdate"];  //Cast the result to date type            

                //Professor
                classe.professor.firstName = ResultSet["teacherfname"].ToString();
                classe.professor.surName = ResultSet["teacherlname"].ToString();

            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the teacher and his modules
            return classe;
        }


        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void UpdateClasse(int id, [FromBody] long teacherId)
        {
            if (teacherId > 0)
            {
                //Create an instance of a connection
                MySqlConnection Conn = School.AccessDatabase();


                //Open the connection between the web server and database
                Conn.Open();

                //Establish a new command (query) for our database
                MySqlCommand cmd = Conn.CreateCommand();

                //The keys are added with their values in the table
                cmd.CommandText = "UPDATE classes SET teacherid=@teacherid WHERE classid=@classid";
                cmd.Parameters.AddWithValue("@classid", id);
                cmd.Parameters.AddWithValue("@teacherid", teacherId);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Conn.Close();
            }
            


        }
    }
}


//NB:The original code of this function is from the Web Application professor Christine Bittle of Humber College.