using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TaskScheduler.Models
{
    public class TarefaDAL
    {
        string connectionString = "Data Source=RODRIGO;Initial Catalog=TAREFASDB;Integrated Security=True;";

        public IEnumerable<Tarefa> GetTarefas()
        {
            List<Tarefa> tarList = new List<Tarefa>();

            using(SqlConnection con= new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllTarefas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tarefa tar = new Tarefa();
                    tar.ID = Convert.ToInt32(dr["ID"].ToString());
                    tar.Titulo = dr["Titulo"].ToString();
                    tar.Descricao = dr["Descricao"].ToString();
                    tar.Data = dr["Dat"].ToString();
                    tar.Hora_Inicial = dr["Horai"].ToString();
                    tar.Hora_Final = dr["Horaf"].ToString();
                    tar.Prioridade = dr["Prioridade"].ToString();
                    tar.Finalizada = dr["Finalizada"].ToString();

                    tarList.Add(tar);
                }
                con.Close();
            }
            return tarList;
        }

        //Inserir Tarefa
        public void AddTarefa(Tarefa tar)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertTarefa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Titulo", tar.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", tar.Descricao);
                cmd.Parameters.AddWithValue("@Dat", tar.Data);
                cmd.Parameters.AddWithValue("@Horai", tar.Hora_Inicial);
                cmd.Parameters.AddWithValue("@Horaf", tar.Hora_Final);
                cmd.Parameters.AddWithValue("@Prioridade", tar.Prioridade);
                cmd.Parameters.AddWithValue("@Finalizada", tar.Finalizada);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Atualizar Tarefa
        public void UpdateTarefa(Tarefa tar)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateTarefa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TarId", tar.ID);
                cmd.Parameters.AddWithValue("@Titulo", tar.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", tar.Descricao);
                cmd.Parameters.AddWithValue("@Dat", tar.Data);
                cmd.Parameters.AddWithValue("@Horai", tar.Hora_Inicial);
                cmd.Parameters.AddWithValue("@Horaf", tar.Hora_Final);
                cmd.Parameters.AddWithValue("@Prioridade", tar.Prioridade);
                cmd.Parameters.AddWithValue("@Finalizada", tar.Finalizada);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Filtrar por ID

        public Tarefa GetTarefaById(int? tarId)
        {
            Tarefa tar = new Tarefa();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllTarefas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tar.ID = Convert.ToInt32(dr["ID"].ToString());
                    tar.Titulo = dr["Titulo"].ToString();
                    tar.Descricao = dr["Descricao"].ToString();
                    tar.Data = dr["Dat"].ToString();
                    tar.Hora_Inicial = dr["Horai"].ToString();
                    tar.Hora_Final = dr["Horaf"].ToString();
                    tar.Prioridade = dr["Prioridade"].ToString();
                    tar.Finalizada = dr["Finalizada"].ToString();

                }
                con.Close();

            }
            return tar;
        }

        //Deletar Tarefa
        public void DeletarTarefa(int? tarId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteTarefa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TarId", tarId);
              
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
