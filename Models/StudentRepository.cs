using Dapper;
using System.Data;

namespace CRUDDapperRepositoryPattern.Models
{
    internal class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        // GenericRepository에서 구현
        //readonly IDbConnection _connection;

        public StudentRepository() : base()
        {
            //_connection = AppConnection.Connection;
        }

        public override bool Insert(Student student)
        {
            int rowsEffected = 0;
            try
            {
                var p = new DynamicParameters();
                p.Add("@StudentID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { student.FullName, student.Birthday, student.Gender, student.Email, student.Address, student.ImageUrl });

                _connection.Execute("sp_Students_Insert", p, commandType: CommandType.StoredProcedure);
                student.StudentID = p.Get<int>("@StudentID");
            }
            catch (Exception) { }
            return rowsEffected > 0;
        }

        public override bool Delete(int studentID)
        {
            int rowsEffected = 0;
            try
            {
                rowsEffected = _connection.Execute("delete from Students where StudentID = @StudentID", new { StudentID = studentID });
            }
            catch (Exception) { }
            return rowsEffected > 0;
        }

        public override IEnumerable<Student>? GetAll()
        {
            IEnumerable<Student>? result = null;
            try
            {
                var sql = @"select * from Students;";
                result = _connection.Query<Student>(sql);
            }
            catch (Exception) { }
            return result;
        }

        public override Student? GetById(int studentID)
        {
            Student? result = null;
            try
            {
                result = _connection.QueryFirstOrDefault<Student>(@"select * from Students where StudentID = @StudentID", new { StudentID = studentID });
            }
            catch (Exception) { }
            return result;
        }

        public override bool Update(Student student)
        {
            int rowsEffected = 0;
            try
            {
                rowsEffected = _connection.Execute("sp_Students_Update", new { student.StudentID, student.FullName, student.Birthday, student.Gender, student.Email, student.Address, student.ImageUrl }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception) { }
            return rowsEffected > 0;
        }
    }
}
