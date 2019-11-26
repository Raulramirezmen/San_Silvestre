using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Runner.Models
{
    public class Runner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Nullable<int> DocumentTypeId { get; set; }
        public string Email { get; set; }
        public Nullable<int> Telephone { get; set; }
        public Nullable<int> PostalCode { get; set; }
        public string GenderId { get; set; }
        public List<Gender> Genders { get; set; }
        public string DNI { get; set; }
        public int YearBirthday { get; set; }
        public string Club { get; set; }
        public bool IsLocalRunner { get; set; }
        //public CompetitionRunner CompRunner { get; set; }
        public int? Dorsal { get; set; }
    }

    public class Gender
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class CompetitionRunner
    {
        public int RunnerId { get; set; }
        public int CompetitionId { get; set; }
        public int CategoryId { get; set; }
        public int Dorsal { get; set; }
        public int PositionId { get; set; }
        public int GeneralPosition { get; set; }
        public DateTime ElapsedTime { get; set; }
    }
}
