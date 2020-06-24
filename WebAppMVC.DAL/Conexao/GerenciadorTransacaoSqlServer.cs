using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAppMVC.DAL.Conexao
{
    public class GerenciadorTransacaoSqlServer : IGerenciadorTransacao
    {
        private SqlConnection conexao;
        private SqlTransaction transacao;

        public IDbConnection Conexao
        {
            get
            {
                if (this.conexao == null)
                {

                    this.conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnMVC"].ConnectionString);

                }
                return conexao;
            }
        }


        public GerenciadorTransacaoSqlServer()
        {
            try
            {
                if (this.Conexao.State == ConnectionState.Closed)
                {
                    this.Conexao.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region "Métodos de gerência de transações com banco de dados"

        public void IniciarTransacao()
        {
            if (this.Conexao.State == ConnectionState.Closed)
                this.Conexao.Open();

            this.transacao = ((SqlConnection)this.Conexao).BeginTransaction();
        }

        public void Commit()
        {
            this.transacao.Commit();
        }

        public void Rollback()
        {
            this.transacao.Rollback();
        }

        #endregion

        public DataTable GetDataTable(IDbCommand cmd)
        {
            ((SqlCommand)cmd).Connection = (SqlConnection)this.Conexao;
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {
                if (this.transacao != null)
                {
                    cmd.Transaction = this.transacao;
                }

                da = new SqlDataAdapter((SqlCommand)cmd);

                dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetDataSet(IDbCommand cmd)
        {
            ((SqlCommand)cmd).Connection = (SqlConnection)this.Conexao;
            DataSet ds = null;
            SqlDataAdapter da = null;

            try
            {
                if (this.transacao != null)
                    cmd.Transaction = this.transacao;

                da = new SqlDataAdapter((SqlCommand)cmd);

                ds = new DataSet();

                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object ExecuteScalar(IDbCommand cmd)
        {
            cmd.Connection = (SqlConnection)this.Conexao;

            try
            {
                if (this.transacao != null)
                    cmd.Transaction = this.transacao;

                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object Execute(IDbCommand cmd)
        {
            cmd.Connection = (SqlConnection)this.Conexao;

            try
            {
                if (this.transacao != null)
                    cmd.Transaction = this.transacao;

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Dispose()
        {
            if (this.Conexao.State == ConnectionState.Open)
                this.Conexao.Close();

            if (this.transacao != null)
                this.transacao.Dispose();

            this.Conexao.Dispose();

            GC.SuppressFinalize(this);
        }


        ~GerenciadorTransacaoSqlServer()
        {
            this.Dispose();
        }
    }
}
