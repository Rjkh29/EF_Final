using Lab_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Products product=new Products();
        StoreContext storeContext = new StoreContext();

        void BindGridView()
        {
            GridViewProd.DataSource = storeContext.Products.ToList<Products>();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                product.Name = txtName.Text;
                product.Category = txtCat.Text;
                product.Price = Convert.ToInt32(txtPrice.Text);
                storeContext.Products.Add(product);
                int res = storeContext.SaveChanges();
                if (res > 0)
                {
                    MessageBox.Show("Product Inserted");
                }
                else
                {
                    MessageBox.Show("Insertion failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
