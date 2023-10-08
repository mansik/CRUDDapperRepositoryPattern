using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapperRepositoryPattern.Models
{
    /// <summary>
    /// internal 접근 지정자를 사용하면 메서드의 인자로 클래스를 전달할 수 없어서 public로 하였음
    /// * 반드시 public로 선언해야 DataGridView에 데이터 원본 선택시 나타난다.
    /// </summary>
    public class Student
    {
        public int StudentID { get; set; }
        public string? FullName { get; set; }
        public bool Gender { get; set; }
        public string? Birthday { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }

    }
}
