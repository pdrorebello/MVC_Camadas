using System;
using System.Data;

namespace WebAppMVC.DAL.Conexao
{
    public interface IGerenciadorTransacao : IDisposable
    {
        void IniciarTransacao();
        void Commit();
        void Rollback();

        DataTable GetDataTable(IDbCommand cmd);
        DataSet GetDataSet(IDbCommand cmd);

        object ExecuteScalar(IDbCommand cmd);
        object Execute(IDbCommand cmd);

        IDbConnection Conexao { get; }
    }
}
