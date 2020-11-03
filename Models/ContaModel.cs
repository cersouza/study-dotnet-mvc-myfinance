using MyFinance.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class ContaModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Saldo { get; set; }
        public string Usuario_Id { get; set; }

        public ContaModel() { }
        public ContaModel(string usuarioId)
        {
            Usuario_Id = usuarioId;
        }

        public List<ContaModel> ListaContas()
        {
            var sql = $"SELECT Id, Nome, Saldo, Usuario_Id FROM conta WHERE Usuario_Id={Usuario_Id}";
            
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            List<ContaModel> listaContas = new List<ContaModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ContaModel conta = new ContaModel();
                conta.Id = dt.Rows[i]["Id"].ToString();
                conta.Nome = dt.Rows[i]["Nome"].ToString();
                conta.Saldo = dt.Rows[i]["Saldo"].ToString();
                conta.Usuario_Id = dt.Rows[i]["Usuario_Id"].ToString();
                listaContas.Add(conta);
            }       

            return listaContas;
        }

        public bool CriarConta()
        {
            try
            {
                var sql = $"INSERT INTO conta(Nome, Saldo, Usuario_Id) VALUES('{Nome}', {Saldo}, '{Usuario_Id}')";
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemoverConta(string idConta)
        {
            try
            {
                var sql = $"DELETE FROM conta WHERE Id = {idConta} and Usuario_Id = {Usuario_Id}";
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
