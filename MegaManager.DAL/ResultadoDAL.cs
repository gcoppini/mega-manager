using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaManager.Models;
using System.Configuration;
using MegaManager.Domain.Main;
using MegaManager.Data.Main;
using System.Linq;

namespace MegaManager.DAL
{
    public class ResultadoDAL : BaseDAL
    {
        private bool _disposed;


        public List<Resultado> GetAll() 
        {
            var listResult = new List<Resultado>();

            using (DataContext ctx = new DataContext())
            {
                listResult = ctx.Resultados.ToList();
            }


            return listResult;
        }

        public void ImportToDatabase(List<Resultado> listToImport)
        {
            using (DataContext ctx = new DataContext())
            {
                foreach (var item in listToImport)
                {
                    ctx.Resultados.Add(item);
                }

                ctx.SaveChanges();
            }
        }




        public List<Resultado> GetAll2()
        {
            var listResult = new List<Resultado>();
    
            using (var command = connection.CreateCommand())
            {
                string query = string.Format("SELECT * FROM TB_RESULTADO");

                command.CommandText = query;

                DbDataReader reader = command.ExecuteReader();

                int somaAnterior = 0;
                while (reader.Read())
                {
                    Resultado res = new Resultado
                    {
                        Concurso = reader.GetString(1),
                        Dezena1 = reader.GetString(2),
                        Dezena2 = reader.GetString(3),
                        Dezena3 = reader.GetString(4),
                        Dezena4 = reader.GetString(5),
                        Dezena5 = reader.GetString(6),
                        Dezena6 = reader.GetString(7),
                        DataSorteio = reader.GetString(8)
                    };

                    res.DiferencaSomaAnteior = Math.Abs(res.Soma - somaAnterior);
                    somaAnterior = res.Soma;

                    listResult.Add(res);
                }
            }
            
       
            return listResult;
        }

        public void ImportToDatabase2(List<Resultado> listToImport)
        {

            foreach (var item in listToImport)
            {
                using (var command = connection.CreateCommand())
                {
                    string query = string.Format("INSERT INTO TB_RESULTADO values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                                                item.Concurso,
                                                item.Dezena1,
                                                item.Dezena2,
                                                item.Dezena3,
                                                item.Dezena4,
                                                item.Dezena5,
                                                item.Dezena6,
                                                item.DataSorteio);


                    command.CommandText = query;
                    int ret = command.ExecuteNonQuery();
                    System.Diagnostics.Debug.Print(ret.ToString());
                }
            }
        }
        
        public bool Delete()
        {
            bool retorno = false;

            using (var command = connection.CreateCommand())
            {
                string query = string.Format("DELETE FROM TB_RESULTADO");

                command.CommandText = query;

                int ret = command.ExecuteNonQuery();
            }
            
            return retorno;
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
