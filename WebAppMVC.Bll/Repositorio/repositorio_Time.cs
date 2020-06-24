using System;
using System.Collections.Generic;
using WebAppMVC.Entity;
using WebAppMVC.DAL.Persistencia;
using System.Data;

namespace WebAppMVC.Bll.Repositorio
{
    public class repositorio_Time
    {

        public void Adicionar(entity_Time objTime)
        {
            dal_Time dalTime = null;

            try
            {
                dalTime = new dal_Time();

                dalTime.Adicionar(objTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(entity_Time objTime)
        {
            dal_Time dalTime = null;

            try
            {
                dalTime = new dal_Time();

                dalTime.Atualizar(objTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(entity_Time objTime)
        {
            dal_Time dalTime = null;

            try
            {
                dalTime = new dal_Time();

                dalTime.Deletar(objTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<entity_Time> Pesquisar()
        {
            dal_Time dalTime = null;
            entity_Time objTime = null;
            var lstTime = new List<entity_Time>();
            DataTable dt = null;

            try
            {
                dalTime = new dal_Time();
                dt = dalTime.Pesquisar();

                foreach (DataRow dr in dt.Rows)
                {
                    objTime = new entity_Time();

                    if (!Convert.IsDBNull(dr["TimeID"]))
                        objTime.TimeID = Convert.ToInt32(dr["TimeID"]);

                    if (!Convert.IsDBNull(dr["Time"]))
                        objTime.Time = dr["Time"].ToString();

                    if (!Convert.IsDBNull(dr["Estado"]))
                        objTime.Estado = dr["Estado"].ToString();

                    if (!Convert.IsDBNull(dr["Cores"]))
                        objTime.Cores = dr["Cores"].ToString();

                    lstTime.Add(objTime);
                }
                return lstTime;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
