using Services.DAL.Contracts;
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
    public sealed class FamilyPatentRepository : IJoinRepository<Family>
    {
        #region Singleton
        private readonly static FamilyPatentRepository _instance = new FamilyPatentRepository();

        public static FamilyPatentRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private FamilyPatentRepository()
        {
            //Implement here the initialization code
        }
        #endregion
        public void Add(Family obj)
        {
            foreach (var item in obj.GetChildrens())
            {
                //Verificar si los hijos son familia o patente...
                //Familia_Patente_Insert
                if (item.ChildrenCount() == 0)
                {

                }

            }
        }

        public void Delete(Family obj)
        {
            //Familia_Patente_Delete
        }

        public void GetChildren(Family obj)
        {
            //3) Buscar en SP Familia_Patente_Select y retornar id de patentes relacionados
            //4) Iterar sobre esos ids -> LLamar al Adaptador y cargar las patentes...
            Patent patentGet = null;

            try
            {
                using (var reader = SqlHelper.ExecuteReader("Family_Patent_Select",
                                                        System.Data.CommandType.StoredProcedure,
                                                        new SqlParameter[] { new SqlParameter("@IdFamily", obj.IdComponent) }))
                {
                    object[] values = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        //Obtengo el id de familia relacionado a la familia principal...(obj)
                        Guid idPatentRelated = Guid.Parse(values[1].ToString());

                        patentGet = PatentRepository.Current.SelectOne(idPatentRelated);

                        obj.Add(patentGet);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Handle(this);
            }
        }
    }
}
