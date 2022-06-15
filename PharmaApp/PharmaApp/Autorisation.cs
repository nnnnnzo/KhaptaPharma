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
            get; set;
        }

        public string DateAutorisation
        {
            get; set;
        }
        public string LibelleMedicament
        {
            get; set;
        }
        public string Commentaire
        {
            get; set;
        }
        public string LibelleCategorie
        {
            get; set;
        }

        public int idmaladieSQL
        {
            get; set;
        }
        public int idmedicamentSQL
        {
            get; set;
        }
        public Autorisation()
        {
        }
        public void Create()
        {
            DataAccess access = new DataAccess();
            access.setData($"INSERT INTO AUTORISER(idmaladie, dateautorisation, idmedicament, commentaire) VALUES({idmaladieSQL}, '{this.DateAutorisation}', {idmedicamentSQL}, '{this.Commentaire}')");
        }

        public void Delete()
        {
            DataAccess access = new DataAccess();
            access.setData($"DELETE FROM AUTORISER WHERE IDMALADIE ={idmaladieSQL} AND DATEAUTORISATION='{this.DateAutorisation}' AND IDMEDICAMENT={idmedicamentSQL}");
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
                    reader = access.getData("select libellemedicament, libellemaladie, DATEAUTORISATION, commentaire, a.idmaladie, a.idmedicament, c.libellecategorie from AUTORISER a join maladie ma on a.idmaladie = ma.idmaladie join medicament me on a.idmedicament = me.IDMEDICAMENT join categorie c on me.idcategorie=c.idcategorie;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Autorisation uneAutorisation = new Autorisation();
                            uneAutorisation.LibelleMedicament = reader.GetString(0);
                            uneAutorisation.LibelleMaladie = reader.GetString(1);
                            uneAutorisation.DateAutorisation = ((DateTime)reader.GetDateTime(2)).ToShortDateString();
                            uneAutorisation.Commentaire = reader.GetString(3);
                            uneAutorisation.idmaladieSQL = reader.GetInt32(4);
                            uneAutorisation.idmedicamentSQL = reader.GetInt32(5);
                            uneAutorisation.LibelleCategorie = reader.GetString(6);
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

        public List<Autorisation> FindBySelection(string critères, string champ)
        {
            List<Autorisation> listeAutorisationsCriteres = new List<Autorisation>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData($"select libellemedicament, libellemaladie, DATEAUTORISATION, commentaire, a.idmaladie, a.idmedicament, c.libellecategorie from AUTORISER a join maladie ma on a.idmaladie = ma.idmaladie join medicament me on a.idmedicament = me.IDMEDICAMENT join categorie c on me.idcategorie=c.idcategorie where {champ}='{critères}';");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Autorisation uneAutorisation = new Autorisation();
                            uneAutorisation.LibelleMedicament = reader.GetString(0);
                            uneAutorisation.LibelleMaladie = reader.GetString(1);
                            uneAutorisation.DateAutorisation = ((DateTime)reader.GetDateTime(2)).ToShortDateString();
                            uneAutorisation.Commentaire = reader.GetString(3);
                            uneAutorisation.idmaladieSQL = reader.GetInt32(4);
                            uneAutorisation.idmedicamentSQL = reader.GetInt32(5);
                            uneAutorisation.LibelleCategorie = reader.GetString(6);
                            listeAutorisationsCriteres.Add(uneAutorisation);
                        }
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return listeAutorisationsCriteres;
        }

    }
}
