using MyFinance.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace MyFinance.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Nascimento { get; set; }

        public bool ValidarLogin()
        {
            var sql = $"SELECT id, nome, email, senha, data_nascimento FROM usuario WHERE email='{Email}' AND senha='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                Id = int.Parse(dt.Rows[0]["id"].ToString());
                Nome = dt.Rows[0]["nome"].ToString();
                Data_Nascimento = DateTime.Parse(dt.Rows[0]["data_nascimento"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CriarUsuario()
        {
            try
            {
                var sql = $"INSERT INTO usuario(nome, email, senha, data_nascimento) VALUES('{Nome}', '{Email}', '{Senha}', '{Data_Nascimento}')";
            DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
