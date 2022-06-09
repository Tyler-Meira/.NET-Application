using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseClasses;
using CustomerClasses;

namespace Project_2
{
    public partial class Form1 : Form
    {
        CustomerTable custT;
        public Form1()
        {
            InitializeComponent();
            custT = new CustomerTable();
            custT.CreateTable();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                enterCust();
                DialogResult updateAdd = MessageBox.Show("Do you want to update address?", "Update Operation", MessageBoxButtons.YesNo);
                if (updateAdd == DialogResult.Yes)
                {
                    txtAdd.ReadOnly = false;
                }
                else
                {
                    txtAdd.ReadOnly = true;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error");
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            custT.DropTable();
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            custT.changeAddress(txtLName.Text, txtFName.Text, txtAdd.Text);
            enterCust();
            txtAdd.ReadOnly = true;
        }

        public void enterCust()
        {
            try
            {
                Customer cust = null;
                cust = custT.getCustomer(txtLName.Text);
                txtFName.Text = cust.FirstName.ToString();
                txtAdd.Text = cust.Address.ToString();

                //Clears Previous Selected Intrests
                resetIntrests();

                if (cust.InterestsList.Contains("Epost"))
                {
                    clbMailing.SetItemChecked(0, true);
                }
                if (cust.InterestsList.Contains("Events"))
                {
                    clbMailing.SetItemChecked(1, true);
                }
                if (cust.InterestsList.Contains("Info"))
                {
                    clbMailing.SetItemChecked(2, true);
                }

            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("No client exists with that last name");
                throw e;
            }     
        }

        public void resetIntrests()
        {
            clbMailing.SetItemChecked(0, false);
            clbMailing.SetItemChecked(1, false);
            clbMailing.SetItemChecked(2, false);
        }
    }
}
