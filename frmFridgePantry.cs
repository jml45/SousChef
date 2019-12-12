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
    public partial class frmFridgePantry : Form
    {
        frmAddFood addMyFood;

        public frmFridgePantry()
        {
            InitializeComponent();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void frmFridgePantry_Load(object sender, EventArgs e)
        {
            lboxFridgePantry.Items.Clear();
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
            lboxFridgePantry.Items.Clear();
            fillListBox();
        }

        private void fillListBox()
        {
            try
            {
                this.food_ListTableAdapter.Fill(this.foodListDataSet.Food_List);
            }
            catch { }

            int rowCount = int.Parse(this.foodListDataSet.Tables["Food List"].Rows.Count.ToString());

            for (int i = 0; i < rowCount; i++)
            {
                lboxFridgePantry.Items.Add(this.foodListDataSet.Tables["Food List"].Rows[i]["Item Name"].ToString());                         
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                this.food_ListTableAdapter.Delete(lboxFridgePantry.SelectedItem.ToString());

                lboxFridgePantry.Items.Clear();

                fillListBox();
            }
            catch { }

        }

        private void lblFridgePantry_Click(object sender, EventArgs e)
        {

        }
    }
}
