using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PharmaApp
{
    public class CategorieMedicament : Crud<CategorieMedicament>
    {

        public int IdCategorie
        {
            get;set;
        }
        public string LibelleCategorie
        {
            get;set;
        }
        public CategorieMedicament()
        {
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<CategorieMedicament> FindAll()
        {
            List<CategorieMedicament> listeCategorie = new List<CategorieMedicament>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from categorie;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CategorieMedicament uneCategorie = new CategorieMedicament();
                            uneCategorie.IdCategorie = (int)reader.GetInt32(0);
                            uneCategorie.LibelleCategorie = reader.GetString(1);
                            listeCategorie.Add(uneCategorie);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return listeCategorie;
        }

        public List<CategorieMedicament> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
