using Services.DAL.Contracts;
using Services.DAL.Tools;
using Services.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Services.DomainModel.Security.Composite;

namespace Services.DAL.Implementations
{
    public sealed class FamilyFamilyRepository : IJoinRepository<Family>
    {
        #region Singleton
        private readonly static FamilyFamilyRepository _instance = new FamilyFamilyRepository();

        public static FamilyFamilyRepository Current
        {
            get
            {
                return _instance;
            }
        }

        private FamilyFamilyRepository()
        {
            //Implement here the initialization code
        }
        #endregion
        public void Add(Family obj)
        {
            foreach (var item in obj.GetChildrens())
            {
                //Verificar si los hijos son familia o patente...
                //Familia_Familia_Insert
                if (item.ChildrenCount() > 0)
                {

                }

            }
        }

        public void Delete(Family obj)
        {
            //Ejecutar el sp Familia_Familia_DeleteParticular

            throw new NotImplementedException();
        }

        public void GetChildren(Family obj)
        {
            //1) Buscar en SP Familia_Familia_SelectParticular y retornar id de familias relacionados
            //2) Iterar sobre esos ids -> LLamar al Adaptador y cargar las familias...

            Family familyGet = null;

            try
            {
                using (var reader = SqlHelper.ExecuteReader("Family_Family_SelectParticular",
                                                        System.Data.CommandType.StoredProcedure,
                                                        new SqlParameter[] { new SqlParameter("@IdFamily", obj.IdComponent) }))
                {
                    object[] values = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        reader.GetValues(values);
                        //Obtengo el id de familia relacionado a la familia principal...(obj)
                        Guid idFamiliaHija = Guid.Parse(values[1].ToString());

                        familyGet = FamilyRepository.Current.SelectOne(idFamiliaHija);

                        obj.Add(familyGet);
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
