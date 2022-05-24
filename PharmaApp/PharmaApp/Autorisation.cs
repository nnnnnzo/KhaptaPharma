using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PharmaApp
{
    public class Autorisation : Crud<Autorisation>
    {

        public int idMaladie
        {
            get;set;
        }
        public int idDate
        {
            get;set;
        }
        public int idMedicament
        {
            get;set;
        }
        public string commentaire
        {
            get;set;
        }
        public Autorisation()
        {
        }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
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

        public List<Autorisation> FindAll()
        {
            List<Autorisation> listeAutorisations = new List<Autorisation>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from autoriser;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Autorisation uneAutorisation = new Autorisation();
                            uneAutorisation.idMaladie = (int)reader.GetInt32(0);
                            uneAutorisation.idDate = (int)reader.GetInt32(1);
                            uneAutorisation.idMedicament = (int)reader.GetInt32(2);
                            uneAutorisation.commentaire = reader.GetString(3);
                            listeAutorisations.Add(uneAutorisation);
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
            return listeAutorisations;
        }

        public List<Autorisation> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

    }
}
