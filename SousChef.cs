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
    public partial class frmSousChefMain : Form
    {
        PantryFr temp;
        frmAddFood addMyFood;
        frmFridge Fridge;
        frmFridgePantry FridgePantry;
        frmRecipes RecipesPage;

        public frmSousChefMain()
        {
            InitializeComponent();
        }
        
        private void MainFr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodListDataSet.Food_List' table. You can move, or remove it, as needed.
            this.food_ListTableAdapter.Fill(this.foodListDataSet.Food_List);
            addMyFood = new frmAddFood();
            temp = new PantryFr();
            addMyFood = new frmAddFood();
            Fridge = new frmFridge();
            FridgePantry = new frmFridgePantry();
            RecipesPage = new frmRecipes();
       

          
            try
            {
                this.food_ListTableAdapter.FillBy(this.foodListDataSet.Food_List);
            }
            catch { }

            int rowCount = int.Parse(this.foodListDataSet.Tables["Food List"].Rows.Count.ToString());
        
            for (int i = 0; i < rowCount; i++)
            {              
                lboxExpiring.Items.Add(this.foodListDataSet.Tables["Food List"].Rows[i]["Item Name"].ToString()
                    + " - "+ this.foodListDataSet.Tables["Food List"].Rows[i]["Expiration Date"].ToString().Remove(10));
            }

      
      
           


  

        }

        private void refreshPage()
        {
            lboxExpiring.Items.Clear();
            try
            {
                this.food_ListTableAdapter.FillBy(this.foodListDataSet.Food_List);
            }
            catch { }

            int rowCount = int.Parse(this.foodListDataSet.Tables["Food List"].Rows.Count.ToString());

            for (int i = 0; i < rowCount; i++)
            {
                lboxExpiring.Items.Add(this.foodListDataSet.Tables["Food List"].Rows[i]["Item Name"].ToString()
                    + " - " + this.foodListDataSet.Tables["Food List"].Rows[i]["Expiration Date"].ToString().Remove(10));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            addMyFood.ShowDialog();
            this.refreshPage();

        }

        private void btnRecipes_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RecipesPage.ShowDialog();
            this.refreshPage();
            this.Visible = true;
        }

        private void btnFridge_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Fridge.ShowDialog();
            this.refreshPage();
            this.Visible = true;

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FridgePantry.ShowDialog();
            this.refreshPage();
            this.Visible = true;
        }

        private void PantryMainBTN_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            temp.ShowDialog();
            this.refreshPage();
            this.Visible = true;

        }

       
    }
}
