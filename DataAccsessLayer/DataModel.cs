using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }
        public List<City> GetCity()
        {
            try
            {
                cmd.CommandText = "SELECT CityID, Name FROM Cities";
                con.Open();
                List<City> cities = new List<City>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new City { CityID=reader.GetInt32(0),Name=reader.GetString(1)});
                }
                return cities;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<State> GetState(int CityID)
        {
            try
            {
                List<State> states = new List<State>();
                cmd.CommandText = "SELECT StateID, CityID, Name FROM States WHERE CityID=@CityID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CityID", CityID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(new State {StateID=reader.GetInt32(0),CityID=reader.GetInt32(1),Name=reader.GetString(2) });
                }
                return states;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
