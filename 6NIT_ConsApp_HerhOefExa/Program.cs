using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//----------------
using System.Data;
using System.Data.SqlClient;
//----------------

namespace _6NIT_ConsApp_HerhOefExa
{
    class Program
    {
        static void Main(string[] args)
        {

            update();
            select();

            Console.ReadKey();
            Console.Clear();

        }







        static void select()
        {
            SqlConnection verbindingDB = new SqlConnection(Properties.Settings.Default.apolloDB);

            verbindingDB.Open();

            SqlDataReader gegevensLezen = null;

            SqlCommand vraagSQL = new SqlCommand("SELECT * FROM tblKlanten ORDER BY naam;", verbindingDB);

            gegevensLezen = vraagSQL.ExecuteReader();

            Console.Write("naam".PadRight(30));
            Console.Write("straat".PadRight(40));
            Console.Write("gemeente".PadRight(25));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");

            while (gegevensLezen.Read())
            {
                Console.Write(gegevensLezen["naam"].ToString().PadRight(30));
                Console.Write(gegevensLezen["straat"].ToString().PadRight(40));
                Console.Write(gegevensLezen["gemeente"].ToString().PadRight(25));
                Console.WriteLine();
            }
            verbindingDB.Close();
        }



        static void update()
        {
            SqlConnection verbindingDB = new SqlConnection(Properties.Settings.Default.apolloDB);

            verbindingDB.Open();
            
            SqlParameter parameterNaam = new SqlParameter("@paramNaam", System.Data.SqlDbType.VarChar, 25);

            Console.Write("Gelieve een nieuwe naam in te geven     ");
            parameterNaam.Value = Console.ReadLine();

            SqlCommand aanpassing = new SqlCommand("UPDATE tblKlanten SET naam=@paramNaam WHERE klantnr=2;", 
                verbindingDB);
            
            aanpassing.Parameters.Add(parameterNaam);

            aanpassing.ExecuteNonQuery();

            verbindingDB.Close();

        }
    }
}

//
