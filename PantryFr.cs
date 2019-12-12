using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SousChef2
{
    public partial class PantryFr : Form
    {
        frmSousChefMain temp1 = new frmSousChefMain();
        frmAddFood addMyFood;
        public PantryFr()
        {
            InitializeComponent();
        }

        private void MainPantryBTN_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void lblPantry_Click(object sender, EventArgs e)
        {

        }

        private void PantryFr_Load(object sender, EventArgs e)
        {
            lboxPantry.Items.Clear();
            // TODO: This line of code loads data into the 'foodListDataSet.Food_List' table. You can move, or remove it, as needed.
            this.food_ListTableAdapter.Fill(this.foodListDataSet.Food_List);
            addMyFood = new frmAddFood();

            fillListBox();
        }

        private void food_ListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.food_ListBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.foodListDataSet);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addMyFood.ShowDialog();
            lboxPantry.Items.Clear();
            fillListBox();
        }

        private void fillListBox()
        {
            try
            {
                this.food_ListTableAdapter.FillByPantry(this.foodListDataSet.Food_List);
            }
            catch { }

            int rowCount = int.Parse(this.foodListDataSet.Tables["Food List"].Rows.Count.ToString());

            for (int i = 0; i < rowCount; i++)
            {
                lboxPantry.Items.Add(this.foodListDataSet.Tables["Food List"].Rows[i]["Item Name"].ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                this.food_ListTableAdapter.Delete(lboxPantry.SelectedItem.ToString());

                lboxPantry.Items.Clear();

                fillListBox();
            }
            catch { }
        }
    }
}
