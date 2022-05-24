using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PharmaApp
{
    public class Maladie : Crud<Maladie>
    {
        public int idMaladie
        {
            get;set;
        }

        public string libelleMaladie
        {
            get;set;
        }
        public Maladie()
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

        public List<Maladie> FindAll()
        {
            List<Maladie> listeMaladies = new List<Maladie>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from maladie;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Maladie uneMaladie = new Maladie();
                            uneMaladie.idMaladie = (int)reader.GetInt32(0);
                            uneMaladie.libelleMaladie = reader.GetString(1);
                            listeMaladies.Add(uneMaladie);
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
            return listeMaladies;
        }

        public List<Maladie> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

    }
}
