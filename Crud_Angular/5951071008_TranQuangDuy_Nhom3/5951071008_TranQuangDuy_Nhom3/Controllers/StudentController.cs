using _5951071008_TranQuangDuy_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _5951071008_TranQuangDuy_Nhom3.Controllers
{

    [EnableCors(origins: "http://mywebclient.azurewebsites.net",headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;



        // GET api/<controller>
        public IEnumerable<Student> Get()
        {

            _conn = new SqlConnection(@"Data Source=DESKTOP-TQD\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "select * from Student";

            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)

            };
            _adapter.Fill(_dt);

            List<Student> students = new List<Student>(_dt.Rows.Count);

            if(_dt.Rows.Count > 0)
            {
                foreach(DataRow studentRecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }

            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-TQD\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "select * from Student where id =" + id;

            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)

            };
            _adapter.Fill(_dt);

            List<Student> students = new List<Student>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }

            return students;
        }

        // POST api/<controller>
        public string Post([FromBody] CreateStudent value)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-TQD\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");

            var query = "insert into Student(f_name, n_name, l_name, address, birthDate, score) values(@f_name, @n_name, @l_name, @address, @birthDate, @score)";
            SqlCommand insertCommand = new SqlCommand(query, _conn);

            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@n_name", value.n_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);


            _conn.Open();

            int result = insertCommand.ExecuteNonQuery();
            if(result > 0)
            {
                return "Them Thanh Cong";
            }
            else
            {
                return "Them That Bai";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateStudent value)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-TQD\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");

            var query = "update Student set f_name=@f_name, n_name=@n_name, l_name=@l_name, address=@address, birthDate=@birthDate, score=@score where id=" +id;
            SqlCommand insertCommand = new SqlCommand(query, _conn);

            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@n_name", value.n_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);


            _conn.Open();

            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Sua Thanh Cong";
            }
            else
            {
                return "Sua That Bai";
            }
        }
    

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-TQD\SQLEXPRESS;Initial Catalog=Nawab;Integrated Security=True");

            var query = "delete Student where id=" +id;
            SqlCommand insertCommand = new SqlCommand(query, _conn);


            _conn.Open();

            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Xoa Thanh Cong";
            }
            else
            {
                return "Xoa That Bai";
            }
        }
    }
}