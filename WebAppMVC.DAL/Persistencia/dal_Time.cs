using System;
using System.Data;
using System.Data.SqlClient;
using WebAppMVC.DAL.Conexao;
using WebAppMVC.Entity;

namespace WebAppMVC.DAL.Persistencia
{
    public class dal_Time
    {

        public void Adicionar(entity_Time objTime)
        {
            SqlCommand cmd = null;

            IGerenciadorTransacao objGerenciadorTransacao = null;

            try
            {
                using (objGerenciadorTransacao = FabricaGerenciadorTransacao.GetGerenciador(TipoBDGerenciador.SqlServer))
                {
                    cmd = new SqlCommand(this.Insert);

                    cmd.Parameters.AddWithValue("@Time", objTime.Time);
                    cmd.Parameters.AddWithValue("@Estado", objTime.Estado);
                    cmd.Parameters.AddWithValue("@Cores", objTime.Cores);


                    objGerenciadorTransacao.Execute(cmd);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public void Atualizar(entity_Time objTime)
        {
            SqlCommand cmd = null;

            IGerenciadorTransacao objGerenciadorTransacao = null;

            try
            {
                using (objGerenciadorTransacao = FabricaGerenciadorTransacao.GetGerenciador(TipoBDGerenciador.SqlServer))
                {
                    cmd = new SqlCommand(this.Update);

                    cmd.Parameters.AddWithValue("@id", objTime.TimeID);
                    cmd.Parameters.AddWithValue("@Time", objTime.Time);
                    cmd.Parameters.AddWithValue("@Estado", objTime.Estado);
                    cmd.Parameters.AddWithValue("@Cores", objTime.Cores);


                    objGerenciadorTransacao.Execute(cmd);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public void Deletar(entity_Time objTime)
        {
            SqlCommand cmd = null;

            IGerenciadorTransacao objGerenciadorTransacao = null;

            try
            {
                using (objGerenciadorTransacao = FabricaGerenciadorTransacao.GetGerenciador(TipoBDGerenciador.SqlServer))
                {
                    cmd = new SqlCommand(this.Delete);

                    cmd.Parameters.AddWithValue("@id", objTime.TimeID);


                    objGerenciadorTransacao.Execute(cmd);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        public DataTable Pesquisar()
        {
            DataTable dt = null;
            SqlCommand cmd = null;
            IGerenciadorTransacao objGerenciadorTransacao = null;

            try
            {
                using (objGerenciadorTransacao = FabricaGerenciadorTransacao.GetGerenciador(TipoBDGerenciador.SqlServer))
                {
                    cmd = new SqlCommand(this.Select);

                    dt = objGerenciadorTransacao.GetDataTable(cmd);
                }

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
        }


        #region " Comandos SQL "

        protected string Insert
        {
            get
            {
                return "INSERT INTO Time(Time,Estado,Cores) VALUES (@Time,@Estado,@Cores)";
            }
        }

        protected string Update
        {
            get
            {
                return "UPDATE Time SET Time = @Time, Estado = @Estado, Cores = @Cores  WHERE TimeID = @id";
            }
        }

        protected string Delete
        {
            get
            {
                return "DELETE FROM Time WHERE TimeID = @id";
            }
        }

        protected string Select
        {
            get
            {
                return "SELECT TimeID,Time,Estado,Cores FROM Time";
            }
        }

        #endregion




    }
}
