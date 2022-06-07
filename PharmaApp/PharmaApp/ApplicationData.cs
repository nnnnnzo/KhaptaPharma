using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaApp
{
    public class ApplicationData
    {
        public static List<CategorieMedicament> listeCategorieMedicament
        {
            get;
            set;
        }

        public static List<Autorisation> listeAutorisations
        {
            get;
            set;
        }
        public static List<Maladie> listeMaladie
        {
            get;
            set;
        }

        public static List<Medicament> listeMedicament
        {
            get;
            set;
        }

        public static void loadApplicationData()
        {
            //chargement des tables
            CategorieMedicament uneCategorie = new CategorieMedicament();
            listeCategorieMedicament = uneCategorie.FindAll();

            Autorisation uneAutorisation = new Autorisation();
            listeAutorisations = uneAutorisation.FindAll();

            Maladie uneMaladie = new Maladie();
            listeMaladie = uneMaladie.FindAll();

            Medicament unMedicament = new Medicament();
            listeMedicament = unMedicament.FindAll();
        }
    }
}
