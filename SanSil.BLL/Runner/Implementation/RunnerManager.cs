using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanSil.BLL.Runner.Interface;
using SanSil.DAL;
using System.Globalization;

namespace SanSil.BLL.Runner.Implementation
{
    public class RunnerManager : IRunnerManager
    {
        private readonly Lazy<log4net.ILog> _logger = new Lazy<log4net.ILog>(() => log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType));

        public Models.Runner GetRunner(int id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var runner = db.Runner.FirstOrDefault(x => x.Id == id);
                if (runner != null)
                {
                    return new Models.Runner
                    {
                        Id = runner.Id,
                        Name = runner.Name,
                        SurName = runner.SurName,
                        YearBirthday = runner.YearBirthday,
                        Email = runner.Email,
                        DocumentTypeId = runner.DocumentTypeId,
                        Telephone = runner.Telephone,
                        PostalCode = runner.PostalCode,
                        IsLocalRunner = runner.IsLocalRunner ?? false,
                        GenderId = runner.GenderId,
                        DNI = runner.DNI,
                        Club = runner.Club
                    };
                }
                return null;
            }
        }


        public Models.Runner GetRunner(string pDNI)
        {
            using (var db = new SanSilvestreEntities())
            {
                var runner = db.Runner.FirstOrDefault(x => x.DNI == pDNI);
                if (runner != null)
                {
                    return new Models.Runner
                    {
                        Id = runner.Id,
                        Name = runner.Name,
                        SurName = runner.SurName,
                        YearBirthday = runner.YearBirthday,
                        Email = runner.Email,
                        DocumentTypeId = runner.DocumentTypeId,
                        Telephone = runner.Telephone,
                        PostalCode = runner.PostalCode,
                        IsLocalRunner = runner.IsLocalRunner ?? false,
                        GenderId = runner.GenderId,
                        DNI = runner.DNI,
                        Club = runner.Club
                    };
                }
                return null;
            }
        }

        public Dictionary<string, string> GetGenderDir()
        {
            using (var db = new SanSilvestreEntities())
            {
                //TODO: Depending on role return different lists
                return db.Gender.OrderBy(x => x.Id).ToDictionary(x => x.Id.ToString(CultureInfo.InvariantCulture), x => x.Name);
            }
        }

        public Dictionary<string, string> GetDocumentTypeDir()
        {
            using (var db = new SanSilvestreEntities())
            {
                //TODO: Depending on role return different lists
                return db.DocumentType.OrderBy(x => x.Id).ToDictionary(x => x.Id.ToString(CultureInfo.InvariantCulture), x => x.Name);
            }
        }

        public int SaveRunner(Models.Runner RunModel)
        {
            //TODO: Mapper

            var runner = new DAL.Runner
            {
                Id = RunModel.Id,
                Name = RunModel.Name,
                SurName = RunModel.SurName,
                Email = RunModel.Email,
                DocumentTypeId = RunModel.DocumentTypeId,
                Telephone = RunModel.Telephone,
                PostalCode = RunModel.PostalCode,
                IsLocalRunner = RunModel.IsLocalRunner,
                GenderId = RunModel.GenderId,
                DNI = RunModel.DNI.ToUpper(),
                Club = RunModel.Club,
                YearBirthday = RunModel.YearBirthday ,
            };
            
            using (var db = new SanSilvestreEntities())
            {
                if (runner.Id == 0)
                {
                    //Add
                    if (db.Runner.Any(x => x.Id == runner.Id)) throw new ApplicationException("El corredor ya existe en la base de datos (Mismo Id)");
                    db.Runner.Add(runner);
                    //var data = db.
                    var pCategory = db.Competition_Category.SingleOrDefault(p => p.CompetitionId == 1 && p.GenderId == RunModel.GenderId
                                    && p.YearFrom <= RunModel.YearBirthday
                                    && p.YearTo >= RunModel.YearBirthday);

                    var runnerCompetition = new DAL.Competition_Runner
                    {
                        Id = RunModel.Id,
                        RunnerId = RunModel.Id,
                        CompetitionId = 1,
                        CategoryId = pCategory.CategoryId,
                        Dorsal = RunModel.Dorsal,
                        ElapsedTime = null,
                        PositionId = 0,
                        GeneralPosition=0,
                        GenderId = RunModel.GenderId,
                    };


                    db.Competition_Runner.Add(runnerCompetition);
                    db.SaveChanges();
                    _logger.Value.Debug(string.Format("Corredor '{0}' añadido a la base de datos", runner.Id));
                }
                else
                {
                    //Edit
                    var currentRunner = db.Runner.FirstOrDefault(x => x.Id == runner.Id);
                    if (currentRunner == null) throw new ApplicationException("El corredor no existe en la base de datos");

                    var RunnerChanged = true;
                    //var roleIds = runner.UserRole.Select(x => x.RoleId).ToList();
                    //var currentRoleIds = currentRunner.UserRole.Select(x => x.RoleId).ToList();

                    ////Delete roles not used 
                    //if (currentRunner.UserRole.Any(x => !roleIds.Contains(x.RoleId)))
                    //{
                    //    RunnerChanged = true;
                    //    db.UserRole.RemoveRange(currentRunner.UserRole.Where(x => !roleIds.Contains(x.RoleId)));
                    //}
                    ////Add new roles
                    //if (runner.UserRole.Any(x => !currentRoleIds.Contains(x.RoleId)))
                    //{
                    //    RunnerChanged = true;
                    //    runner.UserRole.Where(x => !currentRoleIds.Contains(x.RoleId)).ToList().ForEach(x => db.UserRole.Add(new UserRole
                    //    {
                    //        RoleId = x.RoleId,
                    //        UserId = runner.UserId
                    //    }));
                    //}
                    if (RunnerChanged)
                    {
                        db.SaveChanges();
                        _logger.Value.Debug(string.Format("User '{0}' updated in database", runner.Id));
                    }
                }
            }
            return runner.Id;
        }

        public void RemoveRunner(int id)
        {
            using (var db = new SanSilvestreEntities())
            {
                var currentRunner = db.Runner.FirstOrDefault(x => x.Id == id);
                if (currentRunner == null) throw new ApplicationException("Corredor no existe en la base de datos");

                var CompetitionDataRemoved = false;
                if (currentRunner.Competition_Runner.Any())
                {
                    db.Competition_Runner.RemoveRange(currentRunner.Competition_Runner);
                    CompetitionDataRemoved = true;
                }

                db.Runner.Remove(currentRunner);
                db.SaveChanges();
                if (CompetitionDataRemoved) _logger.Value.Debug(string.Format("Corredor '{0}' eliminado de la Competicion actual", id));
                _logger.Value.Debug(string.Format("Corredor '{0}' eliminado de la base de datos", id));
            }
        }

    }
}
