using MegaManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;

namespace MegaManager.DAL
{
    public class GabaritoDAL : BaseDAL
    {
        private bool _disposed;


        public List<Gabarito> GetAll()
        {
            var listResult = new List<Gabarito>();

            using (DataContext ctx = new DataContext())
            {
                listResult = ctx.Gabaritos.ToList();
            }

            return listResult;
        }


        public List<Gabarito> GetAll2()
        {
            var listResult = new List<Gabarito>();
            
            using (var command = connection.CreateCommand())
            {
                string query = string.Format("SELECT * FROM TB_GABARITO");

                command.CommandText = query;

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Gabarito res = new Gabarito();

                    res.Id = reader.GetInt32(0);
                    res.Numero = reader.GetInt32(1);

                    res.Descricao = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                        res.Observacoes = reader.GetString(3);


                    res.Quantidade1 = reader.GetInt32(4);
                    res.Quantidade2 = reader.GetInt32(5);
                    res.Quantidade3 = reader.GetInt32(6);
                    res.Quantidade4 = reader.GetInt32(7);
                    res.Quantidade5 = reader.GetInt32(8);
                    res.Quantidade6 = reader.GetInt32(9);
                    res.Quantidade7 = reader.GetInt32(10);


                    listResult.Add(res);
                }
            }

            return listResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose all managed resources here.
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}
