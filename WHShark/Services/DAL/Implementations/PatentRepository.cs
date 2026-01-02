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
    internal sealed class PatentRepository : IGenericRepository<Patent>
    {
        #region Singleton
        private readonly static PatentRepository _instance = new PatentRepository();

        public static PatentRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private PatentRepository()
        {
            //Implement here the initialization code
        }
        #endregion


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
            get => "Patent_Select";
        }

        private string SelectAllStatement
        {
            get => "Patent_SelectAll";
        }
        #endregion

        public void Add(Patent obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patent> SelectAll()
        {
            List<Patent> patentes = new List<Patent>();
            Patent patenteGet = null;

            try
            {
                using (var reader = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.StoredProcedure))
                {
                    object[] values = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        patenteGet = PatentAdapter.Current.Adapt(values);
                        patentes.Add(patenteGet);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }

            return patentes;
        }

        public Patent SelectOne(Guid id)
        {
            Patent patentGet = null;

            try
            {
                using (var reader = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.StoredProcedure,
                                                new SqlParameter[] { new SqlParameter("@IdPatente", id) }))
                {
                    object[] values = new object[reader.FieldCount];

                    if (reader.Read())
                    {
                        reader.GetValues(values);
                        patentGet = PatentAdapter.Current.Adapt(values);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }

            return patentGet;
        }

        public void Update(Patent obj)
        {
            throw new NotImplementedException();
        }
    }
}
