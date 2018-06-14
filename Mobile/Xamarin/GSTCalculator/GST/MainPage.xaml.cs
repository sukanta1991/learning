using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace testGst
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            
		}

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            txtAmt.Text = "";
            txtGST.Text = "";
            lblAmt.Text = "";
            lblCgst.Text = "";
            lblSgst.Text = "";
            lblTotal.Text = "";
            lblErr.Text = "";
            txtNum.Text = "1";
        }

        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            Double amount, gst, price, cgst, sgst,calgst,counts,amt;
            try
            {
                lblErr.Text = "";
                if(txtAmt.Text == null || txtGST.Text == null || txtNum.Text == null)
                {
                    throw new ArgumentException("Field is null");
                }
                amt = Convert.ToDouble(txtAmt.Text);
                counts = Convert.ToDouble(txtNum.Text);
                amount = amt * counts;
                gst = Convert.ToDouble(txtGST.Text);
                calgst = gst / 100;
                cgst = (amount * calgst) / (1 + calgst);
                cgst = Math.Round(cgst/2, 2);
                sgst = cgst;
                price = amount - (sgst + cgst);
                lblTgst.Text = "Rs. " + (sgst + cgst).ToString();
                lblAmt.Text = "Rs. " + price.ToString();
                lblCgst.Text = "Rs. " + cgst.ToString();
                lblSgst.Text = "Rs. " + sgst.ToString();
                lblTotal.Text = "Rs. " + amount.ToString();

            }
            catch(ArgumentException )
            {
                lblErr.Text = "Kindly enter values";
            }
            catch (Exception ex)
            {
                lblErr.Text = "Kindly enter input in proper order.";
                
            }
            

        }
    }
}
