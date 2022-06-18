using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PharmaApp
{
    public class Autorisation : Crud<Autorisation>
    {
        /// <summary>
        /// Permet d'obtenir le nom de la maladie
        /// </summary>
        public string LibelleMaladie
        {
            get; set;
        }
        /// <summary>
        /// Permet d'obtenir la Date d'autorisation du médicament voulut
        /// </summary>

        public string DateAutorisation
        {
            get; set;
        }
        /// <summary>
        /// Permet d'obtenir le nom du médicament
        /// </summary>
        public string LibelleMedicament
        {
            get; set;
        }

        /// <summary>
        /// Permet d'obtenir le commentaire lié à une autorisation
        /// </summary>
        public string Commentaire
        {
            get; set;
        }

        /// <summary>
        /// Permet d'obtenir le nom d'une catégorie de médicament
        /// </summary>
        public string LibelleCategorie
        {
            get; set;
        }

        /// <summary>
        /// Permet d'obtenir l'identifiant d'une maladie précise
        /// </summary>

        public int idmaladieSQL
        {
            get; set;
        }

        /// <summary>
        /// Permet d'obtenir l'identifiant d'une maladie précise
        /// </summary>
        public int idmedicamentSQL
        {
            get; set;
        }

        /// <summary>
        ///  Permet d'initialiser une autorisation
        /// </summary>

        public Autorisation()
        {
        }

        /// <summary>
        /// Permet de creer une autorisation en récupérant l'identifiant de la maladie, l'identifiant du médicament, la date d'autorisation ainsi que le commentaire à l'aide d'une requête SQL
        /// </summary>

        public void Create()
        {
            DataAccess access = new DataAccess();
            access.setData($"INSERT INTO AUTORISER(idmaladie, dateautorisation, idmedicament, commentaire) VALUES({idmaladieSQL}, '{this.DateAutorisation}', {idmedicamentSQL}, '{this.Commentaire.Replace("'", "''")}')");
        }

        /// <summary>
        /// Permet de supprimer une autorisation identifié grâce à 3 propriété : l'identifiant de la maladie, la date d'autorisation, ainsi que de l'identifiant du médicament
        /// </summary>

        public void Delete()
        {
            DataAccess access = new DataAccess();
            access.setData($"DELETE FROM AUTORISER WHERE IDMALADIE ={idmaladieSQL} AND DATEAUTORISATION='{this.DateAutorisation}' AND IDMEDICAMENT={idmedicamentSQL}");
        }
        /// <summary>
        /// Méthode pas implémentée qui ne fait rien
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de modifier une autorisation ( sa date d'autorisation, la maladie/le médicament sur laquelle l'autorisation porte
        /// </summary>

        public void Update()
        {
            DataAccess access = new DataAccess();
            access.setData($"DELETE FROM AUTORISER");
            foreach (Autorisation uneAutorisation in ApplicationData.listeAutorisations)
            {
                uneAutorisation.Create();
            }
            
        }

        /// <summary>
        /// Cette méthode récupére les objets qui qualifie une autorisation tel que le nom de la maladie, le nom du médicament, le commentaire, la date d'autorisation etc.
        /// Pour ensuite les mettre dans une liste d'autorisation de type autorisation.
        /// </summary>
        /// <returns> Retourne la liste d'autorisation avec toute les autorisations créée</returns>
        
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

        /// <summary>
        /// Méthode pas implémentée
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns> Rien</returns>

        public List<Autorisation> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cette méthode récupére les objets qui qualifie une autorisation tel que le nom de la maladie, le nom du médicament, le commentaire, la date d'autorisation etc.
        /// Pour ensuite les mettre dans une liste d'autorisation de type autorisation en fonction d'un critère précis ainsi que d'un champ.
        /// </summary>
        /// <param name="critères"> La valeur d'un champ exemple : Marc</param>
        /// <param name="champ"> Colonne ou se trouve un critère exemple : Employe</param>
        /// <returns> la liste d'autorisation voulut en focntion du critère et du champ</returns>

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
