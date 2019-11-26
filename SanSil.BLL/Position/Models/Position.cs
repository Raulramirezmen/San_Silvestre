using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSil.BLL.Position.Models
{
    public class Position
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public Nullable<int> PositionId { get; set; }
        public Nullable<int> GeneralPosition { get; set; }
        public Nullable<int> Dorsal { get; set; }
        public int RunnerId { get; set; }
        public string RunnerName { get; set; }
        public string RunnerSurName { get; set; }
        public string Club { get; set; }
        public string Elapsed_Time { get; set; }
        public int CategoryId { get; set; }
        public string GenderId { get; set; }
    }

    public class MyCategoriesDescriptions
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
