using project3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project3.Controllers
{
    public class ClassesDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDB School = new SchoolDB();
        //This Controller Will access the Classes table of our School database.
        /// <summary>
        /// Returns a list of Classes in the system
        /// </summary>
        /// <example>GET api/Classes/ListClasses</example>
        /// <returns>
        /// A list of classes objects.
        /// </returns>

        [HttpGet]
        [Route("api/listClasses")]
        public IEnumerable<Classes> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Classes> Classes = new List<Classes> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                Classes NewClasses = new Classes
                {
                    ClassId = ClassId,
                    ClassCode = ClassCode,
                    TeacherId = TeacherId,
                    StartDate = StartDate,
                    FinishDate = FinishDate,
                    ClassName = ClassName
                };

                
                Classes.Add(NewClasses);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

           
            return Classes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id">the class ID in the database</param>
        /// <returns>A class object</returns>

        [HttpGet]
        [Route("api/showClasses")]
        public Classes FindClasses(int id)
        {
            Classes NewClasses = new Classes();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes where classid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                NewClasses.ClassId = ClassId;
                NewClasses.ClassCode = ClassCode;
                NewClasses.TeacherId = TeacherId;
                NewClasses.StartDate = StartDate;
                NewClasses.FinishDate = FinishDate;
                NewClasses.ClassName = ClassName;
            }
            return NewClasses;
        }
    }
}
