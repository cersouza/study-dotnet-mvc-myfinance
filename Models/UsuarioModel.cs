using MyFinance.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MyFinance.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha com seu nome !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha com seu email !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha com sua senha !")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencha com sua data nascimento !")]
        public string Data_Nascimento { get; set; }

        public bool ValidarLogin()
        {
            var sql = $"SELECT id, nome, email, senha, data_nascimento FROM usuario WHERE email='{Email}' AND senha='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                Id = int.Parse(dt.Rows[0]["id"].ToString());
                Nome = dt.Rows[0]["nome"].ToString();
                Data_Nascimento = dt.Rows[0]["data_nascimento"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Registrar()
        {
            try
            {
                string dataFormatada = DateTime.Parse(Data_Nascimento).ToString("yyyy-MM-dd");
                var sql = $"INSERT INTO usuario(nome, email, senha, data_nascimento) VALUES('{Nome}', '{Email}', '{Senha}', '{dataFormatada}')";
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
