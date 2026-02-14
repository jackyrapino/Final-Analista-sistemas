using Services.DAL.Contracts;
using Services.DAL.Implementations.Adapter;
using Services.DAL.Tools;
using Services.DomainModel.Security.Composite;
using Services.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations
{
    internal sealed class FamilyRepository : IGenericRepository<Family>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[] () VALUES ()";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[] SET () WHERE  = @";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[] WHERE  = @";
        }

        private string SelectOneStatement
        {
            get => "Family_Select";
        }

        private string SelectAllStatement
        {
            get => "Family_SelectAll";
        }

        #endregion

        #region Singleton
        private readonly static FamilyRepository _instance = new FamilyRepository();

        public static FamilyRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private FamilyRepository()
        {
        }
        #endregion
        public void Add(Family obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> SelectAll(string TSQLfilter)
        {
            throw new NotImplementedException();
        }

        public Family SelectOne(Guid id)
        {
            Family patentGet = null;

            try
            {
                using (var reader = SqlHelper.ExecuteReader("ManagerAuth", "Familia_Select", System.Data.CommandType.StoredProcedure,
                                                new SqlParameter[] { new SqlParameter("@IdFamilia", id) }))
                {
                    object[] values = new object[reader.FieldCount];

                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        patentGet = FamilyAdapter.Current.Adapt(values);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }

            return patentGet;
        }

        public void Update(Family obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> SelectAll()
        {
            var familias = new List<Family>();
            try
            {
                using (var reader = SqlHelper.ExecuteReader("ManagerAuth", "Familia_SelectAll", System.Data.CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        var fam = FamilyAdapter.Current.Adapt(values);
                        familias.Add(fam);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }

            return familias;
        }
    }
}
