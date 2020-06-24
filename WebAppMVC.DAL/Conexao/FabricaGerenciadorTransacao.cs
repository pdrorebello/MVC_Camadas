using System;

namespace WebAppMVC.DAL.Conexao
{
    public class FabricaGerenciadorTransacao
    {
        private static UsuarioBD UserBD { get; set; }

        public static void CriarUsuarioBD(string servidor, string login, string senha, string catalogo)
        {
            FabricaGerenciadorTransacao.UserBD = new UsuarioBD() { Servidor = servidor, LoginBanco = login, SenhaBanco = senha, Catalogo = catalogo };
        }

        /// <summary>
        /// Método que retorna um a propriedade "Servidor" da Classe de UsuarioBD
        /// </summary>
        public static string Servidor
        {
            get
            {
                return FabricaGerenciadorTransacao.UserBD.Servidor;
            }
        }

        /// <summary>
        /// Método que retorna um a propriedade "LoginBanco" da Classe de UsuarioBD
        /// </summary>
        public static string LoginBanco
        {
            get
            {
                return FabricaGerenciadorTransacao.UserBD.LoginBanco;
            }
        }

        /// <summary>
        /// Método que retorna um a propriedade "SenhaBanco" da Classe de UsuarioBD
        /// </summary>
        public static string SenhaBanco
        {
            get
            {
                return FabricaGerenciadorTransacao.UserBD.SenhaBanco;
            }
        }

        /// <summary>
        /// Método que retorna um a propriedade "Catalogo" da Classe de UsuarioBD
        /// </summary>
        public static string Catalogo
        {
            get
            {
                return FabricaGerenciadorTransacao.UserBD.Catalogo;
            }
        }

        public static IGerenciadorTransacao GetGerenciador(TipoBDGerenciador tipoGerenciador)
        {
            if (tipoGerenciador == TipoBDGerenciador.SqlServer)
                return new GerenciadorTransacaoSqlServer();
            else
                throw new Exception("Tipo gerenciador inválido!");
        }
    }
}
