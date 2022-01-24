using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesTaxWin
{
    public partial class Form1 : Form
    {

        public Form1()
        {
           
        InitializeComponent();

        }
        private void bnbInput1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBook1.Text) ||
                string.IsNullOrEmpty(txtBook2.Text) ||
                string.IsNullOrEmpty(txtMusic.Text) ||
                string.IsNullOrEmpty(txtChoclatebar.Text))
           {
                lblError1.Visible = true;
                errorProvidertextbox.SetError(lblError1, "Input data!");
            }
            else
            {

                var inputOne = new[]
               {
            txtBook1.Text = lblbook1.Text + txtBook1.Text,
            txtBook2.Text = lblbook2.Text + txtBook2.Text,
            txtMusic.Text = lblMusicCd.Text + txtMusic.Text,
            txtChoclatebar.Text = lblChoclatebar.Text+ txtChoclatebar.Text
            };

                ProssesDataOne(inputOne);
                txtBook1.Text = "";
                txtBook2.Text = "";
                txtMusic.Text = "";
                txtChoclatebar.Text = "";
            }
        }


        private void bnbInput2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImportChoclate.Text) ||
                string.IsNullOrEmpty(txtImportBottle.Text))
              {
                lblError2.Visible = true;
                errorProvidertextbox.SetError(lblError2, "Input data!");
            }
            else
            {
                var inputTwo = new[]
            {
            txtImportChoclate.Text = lblImportChoclate.Text + txtImportChoclate.Text,
            txtImportBottle.Text = lblImportBottle.Text + txtImportBottle.Text,
            };
                ProssesDataTwo(inputTwo);
                txtImportChoclate.Text = "";
                txtImportBottle.Text = "";
            }
        }

        private void bnbInput3_Click(object sender, EventArgs e)
        {
 
            if (string.IsNullOrEmpty(txtImBoofPerfume.Text) ||
               string.IsNullOrEmpty(txtBoOfPerfume.Text) ||
               string.IsNullOrEmpty(txtPaOfHePi.Text) ||
               string.IsNullOrEmpty(txtImBoOfCho1.Text) ||
               string.IsNullOrEmpty(txtImBoOfCho2.Text))
            {
                lblError3.Visible = true;
                errorProvidertextbox.SetError(lblError3, "Input data!");
            }
            else
            {

                var inputThree = new[]
          {
            txtImBoofPerfume.Text = label1.Text + txtImBoofPerfume.Text,
            txtBoOfPerfume.Text = lblbottelofperfume.Text + txtBoOfPerfume.Text,
            txtPaOfHePi.Text = lblpacketofheadache.Text + txtPaOfHePi.Text,
            txtImBoOfCho1.Text = label2.Text + txtImBoOfCho1.Text,
            txtImBoOfCho2.Text = label3.Text + txtImBoOfCho2.Text
            };
                ProssesDataThree(inputThree);
                txtImBoofPerfume.Text = "";
                txtBoOfPerfume.Text = "";
                txtPaOfHePi.Text = "";
                txtImBoOfCho1.Text = "";
                txtImBoOfCho2.Text = "";
            }
        }
        private void ProssesDataOne(string[] input)
        {
            lblError1.Visible = false;
            var shoppringCart = ItemParser.Parse(input);
            var taxCalculator = new Calculate();
            taxCalculator.CalculateIn(shoppringCart);
            foreach (var cartItem in shoppringCart.CartItems)
            {

                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].Name = "Output";
                dataGridView1.Rows.Add(cartItem);
            }
            lblTotal.Visible = true;
            lblTax.Visible = true;
            lblTax.Text = "Sales Taxes:" + (shoppringCart.TotalTax).ToString();
            lblTotal.Text = "Total:" + (shoppringCart.TotalCost).ToString();

        }
        private void ProssesDataTwo(string[] input)
        {
            lblError2.Visible = false;
            var shoppringCart = ItemParser.Parse(input);
            var taxCalculator = new Calculate();
            taxCalculator.CalculateIn(shoppringCart);
            // ShopingCartPrinter.PrintCard(shoppringCart);
            foreach (var cartItem in shoppringCart.CartItems)
            {
                dataGridView3.ColumnCount = 1;
                dataGridView3.Columns[0].Name = "Output";
                dataGridView3.Rows.Add(cartItem);
            }
            lblTaxInput2.Visible = true;
            lblTotalinput2.Visible = true;
            lblTaxInput2.Text = "Sales Taxes:" + (shoppringCart.TotalTax).ToString();
            lblTotalinput2.Text = "Total:" + (shoppringCart.TotalCost).ToString();

        }
        private void ProssesDataThree(string[] input)
        {
            lblError3.Visible = false;
            var shoppringCart = ItemParser.Parse(input);
            var taxCalculator = new Calculate();
            taxCalculator.CalculateIn(shoppringCart);
            foreach (var cartItem in shoppringCart.CartItems)
            {
                dataGridView2.ColumnCount = 1;
                dataGridView2.Columns[0].Name = "Output";
                dataGridView2.Rows.Add(cartItem);
            }
            lblTaxinput3.Visible = true;
            lblTotalInput3.Visible = true;
            lblTaxinput3.Text = "Sales Taxes:" + (shoppringCart.TotalTax).ToString();
            lblTotalInput3.Text = "Total:" + (shoppringCart.TotalCost).ToString();

        }

        private void txtImBoofPerfume_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtBoOfPerfume_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtPaOfHePi_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtImBoOfCho1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtImBoOfCho2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtImportChoclate_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtImportBottle_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtBook1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtBook2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtMusic_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtChoclatebar_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z\s]");
            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}







