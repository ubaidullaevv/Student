namespace Library;



public class StudentService
{
    using Dapper;
using DapperPractice1;
using Npgsql;

var connectionString = "Server=127.0.0.1;Port=5432;Database=StudentsDB;User Id=postgres;Password=12345;";


var firstStudent = GetStudentById(1);
Console.WriteLine($"Fullname = {firstStudent.Fullname},Age = {firstStudent.Age}, Email = {firstStudent.Email} Phone={firstStudent.Phone}" );

Console.WriteLine(new String('-',20));
Console.WriteLine("Update");

firstStudent.Fullname = "Habib Ubaidulloev";
var result = Update(firstStudent);
Console.WriteLine($"updated ={result}");

var updated = GetStudentById(1);
Console.WriteLine($"   Fullname = {updated.Fullname},       Age = {updated.Age},       Email = {updated.Email} Phone= {updated.Phone}");    



bool Delete(int id)
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "delete from students where id=@Id";
        var affected = connection.Execute(sql,new {Id=id});
        return affected > 0;
    } 
}

bool Update(Student student)
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "update students set fullname=@fullname, age=@age, score=@score where id=@id";
        var affected = connection.Execute(sql,student);
        return affected > 0;
    } 
}

bool InsertStudent(Student student)
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "insert into students(fullname,age,score) values(@fullname,@age,@score)";
        var affected = connection.Execute(sql,student);
        return affected > 0;
    } 
}

List<Student> GetStudents()
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "select * from students;";
        List<Student> students = connection.Query<Student>(sql).ToList();
        return students;
    }
}

Student GetStudentById(int id)
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "select * from students where id=@Id;";
        var students = connection.QuerySingle<Student>(sql,new {Id=id});
        return students;
    }
}

}
