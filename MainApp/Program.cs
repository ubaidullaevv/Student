using Library;
using Npgsql;
using Dapper;

StudentService studentService=new StudentService();
studentService.GetStudentById(1);