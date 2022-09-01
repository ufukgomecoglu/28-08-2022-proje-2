using DataAccsessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Proje_2
{
    public partial class CityState : Form
    {
        DataModel dataModel= new DataModel();
        public CityState()
        {
            InitializeComponent();
        }

        private void CityState_Load(object sender, EventArgs e)
        {
            comboBoxCity.ValueMember = "CityID";
            comboBoxCity.DisplayMember = "Name";
            List<City> cities = dataModel.GetCity();
            cities.Insert(0, new City() {CityID=0,Name="Chose"}) ;
            comboBoxCity.DataSource= cities ;
            comboBoxState.Enabled = false ;
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityID =comboBoxCity.SelectedIndex;
            if (cityID != 0)
            {
                comboBoxState.Enabled = true;
                comboBoxState.DisplayMember = "Name";
                comboBoxState.ValueMember = "StateID";
                comboBoxState.DataSource = dataModel.GetState(cityID);
            }
            else
            {
                comboBoxState.Enabled = false;
                comboBoxState.Text = "";
            }
        }
    }
}
