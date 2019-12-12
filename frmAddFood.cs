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
    public partial class frmAddFood : Form
    {
        public frmAddFood()
        {
            InitializeComponent();
        }

        private void lblAddFood_Click(object sender, EventArgs e)
        {

        }

       
        private void food_ListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            if ((item_NameTextBox.Text != "") &&  (
            categoryComboBox.Text != "") && (
            quantityTextBox.Text != "") && (
            fridge_PantryComboBox.Text != ""))
            {
                this.Validate();
                this.food_ListBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.foodListDataSet);

                MessageBox.Show("Saved!");
            }
            else
            {
                MessageBox.Show("Error: All fields must be filled in.");
            }
            bindingNavigatorAddNewItem.PerformClick();
            descriptionTextBox.Text = "n/a";
            descriptionTextBox.Visible = false;
            expiration_DateDateTimePicker.MinDate = DateTime.Now; //Sets the minimal date the user can pick.
            expiration_DateDateTimePicker.Value = DateTime.Now.AddDays(7);
        }

        private void frmAddFood_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodListDataSet.Food_List' table. You can move, or remove it, as needed.
            this.food_ListTableAdapter.Fill(this.foodListDataSet.Food_List);
            this.food_ListBindingNavigator.Visible = false;
            bindingNavigatorAddNewItem.PerformClick();

            descriptionTextBox.Text = "n/a";
            descriptionTextBox.Visible = false;
            expiration_DateDateTimePicker.MinDate = DateTime.Now; //Sets the minimal date the user can pick.
            expiration_DateDateTimePicker.Value = DateTime.Now.AddDays(7);

        }

        private void food_ListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            food_ListBindingNavigatorSaveItem.PerformClick();

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
            item_NameTextBox.Enabled = true;           
            categoryComboBox.Enabled = true;
            quantityTextBox.Enabled = true;
            expiration_DateDateTimePicker.Enabled = true;
            fridge_PantryComboBox.Enabled = true;
        }

        private void item_NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
