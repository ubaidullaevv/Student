namespace Library;

using Dapper;
using Npgsql;


public class StudentService
{

var connectionString = "Server=localhost;Port=5432;Database=StudentsDB;User Id=postgres;Password=12345;";



bool DeleteStudent(int id)
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "delete from students where id=@StudentId";
        var affected = connection.Execute(sql,new {StudentId=id});
        return affected > 0;
    } 
}

bool UpdateStudent(Student student)
{
    using (var connection = new NpgsqlConnection(connectionString))
    {
        var sql = "update students set studentId=@StudentId fullname=@fullname, age=@age, score=@score where id=@StudentId";
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
        var sql = "select * from students where id=@StudentId;";
        var students = connection.QuerySingle<Student>(sql,new {StudentId=id});
        return students;
    }
}

}
