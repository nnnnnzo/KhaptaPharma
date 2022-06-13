using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PharmaApp
{
    public class Autorisation : Crud<Autorisation>
    {

        public string LibelleMaladie
        {
            get;set;
        }
        public string DateAutorisation
        {
            get;set;
        }
        public string LibelleMedicament
        {
            get;set;
        }
        public string Commentaire
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
                    reader = access.getData("select libellemedicament, libellemaladie, DATEAUTORISATION, commentaire from AUTORISER a join maladie ma on a.idmaladie = ma.idmaladie join medicament me on a.idmedicament = me.IDMEDICAMENT; ");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Autorisation uneAutorisation = new Autorisation();
                            uneAutorisation.LibelleMaladie = reader.GetString(0);
                            uneAutorisation.LibelleMedicament = reader.GetString(1);
                            uneAutorisation.DateAutorisation = ((DateTime)reader.GetDateTime(2)).ToShortDateString();
                            uneAutorisation.Commentaire = reader.GetString(3);
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
