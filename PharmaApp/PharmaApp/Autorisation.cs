﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PharmaApp
{
    public class Autorisation : Crud<Autorisation>
    {

        public string libelleMaladie
        {
            get;set;
        }
        public string dateAutorisation
        {
            get;set;
        }
        public string libelleMedicament
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
                    reader = access.getData("select libellemedicament, libellemaladie, DATEAUTORISATION, commentaire from AUTORISER a join maladie ma on a.idmaladie = ma.idmaladie join medicament me on a.idmedicament = me.IDMEDICAMENT; ");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Autorisation uneAutorisation = new Autorisation();
                            uneAutorisation.libelleMaladie = reader.GetString(0);
                            uneAutorisation.libelleMedicament = reader.GetString(1);
                            uneAutorisation.dateAutorisation = ((DateTime)reader.GetDateTime(2)).ToShortDateString();
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
