using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Entity;
using WebAppMVC.Bll.Repositorio;

namespace WebAppMVC.Bll.RegraNegocio
{
    public class regranegocio_Time
    {
        public bool Adicionar(entity_Time objTime)
        {
            repositorio_Time repositorio_Time = null;
            bool insert = false;

            try
            {
                repositorio_Time = new repositorio_Time();

                //Adiciona Time
                repositorio_Time.Adicionar(objTime);

                insert = true;

                return insert;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }

        public bool Atualizar(entity_Time objTime)
        {
            repositorio_Time repositorio_Time = null;
            bool update = false;

            try
            {
                repositorio_Time = new repositorio_Time();

                //Atualiza Time
                repositorio_Time.Atualizar(objTime);

                update = true;

                return update;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public bool Deletar(entity_Time objTime)
        {
            repositorio_Time repositorio_Time = null;
            bool delete = false;

            try
            {
                repositorio_Time = new repositorio_Time();

                //Deleta Time
                repositorio_Time.Deletar(objTime);

                delete = true;

                return delete;

            }
            catch (Exception)
            {
                throw;
            }


        }

        public List<entity_Time> Pesquisar()
        {
            repositorio_Time repositorio_Time = null;
            try
            {
                repositorio_Time = new repositorio_Time();

                var lstTime = new List<entity_Time>();

                lstTime = repositorio_Time.Pesquisar().ToList();

                // Listar todos os times
                return lstTime;

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
