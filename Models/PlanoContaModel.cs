using MyFinance.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class PlanoContaModel
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Usuario_Id { get; set; }

        public PlanoContaModel() { }
        public PlanoContaModel(string usuarioId)
        {
            Usuario_Id = usuarioId;
        }

        public List<PlanoContaModel> Listar()
        {
            var sql = $"SELECT Id, Descricao, Tipo FROM plano_contas WHERE Usuario_Id={Usuario_Id}";
            
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            List<PlanoContaModel> listaPlanoContas = new List<PlanoContaModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PlanoContaModel conta = new PlanoContaModel();
                conta.Id = dt.Rows[i]["Id"].ToString();
                conta.Descricao = dt.Rows[i]["Descricao"].ToString();
                conta.Tipo = dt.Rows[i]["Tipo"].ToString();
                conta.Usuario_Id = dt.Rows[i]["Usuario_Id"].ToString();
                listaPlanoContas.Add(conta);
            }       

            return listaPlanoContas;
        }

        public bool Criar()
        {
            try
            {
                var sql = $"INSERT INTO plano_contas(Descricao, Tipo, Usuario_Id) VALUES('{Descricao}', {Tipo}, '{Usuario_Id}')";
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Editar(string idConta)
        {
            try
            {
                var sql = $"UPDATE plano_contas SET Descricao = '{Descricao}', Tipo = '{Tipo}' WHERE Id = {idConta} and Usuario_Id = {Usuario_Id}";
                DAL objDAL = new DAL();
                objDAL.ExecutarComandoSQL(sql);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Remover(string idConta)
        {
            try
            {
                var sql = $"DELETE FROM plano_contas WHERE Id = {idConta} and Usuario_Id = {Usuario_Id}";
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
