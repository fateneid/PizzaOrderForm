using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderForm
{
    public partial class MainPizzaForm : Form
    {
        public MainPizzaForm()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {

            UpdateTotalPrice();

            if(rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if (rbMeduim.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }

        }

        void UpdateToppings()
        {

            UpdateTotalPrice();

            string sToppings = "";

            if (chExtraCheese.Checked) sToppings = "Extra Chees";
            if (chOnion.Checked) sToppings += ", Onion";
            if (chMushrooms.Checked) sToppings += ", Mushrooms";
            if (chOlives.Checked) sToppings += ", Olives";
            if (chTomatoes.Checked) sToppings += ", Tomatos";
            if (chGreenPeppers.Checked) sToppings += ", Green Peppars";
            if (sToppings.StartsWith(",")) sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            if (sToppings == "") sToppings = "No Toppings";

            lblToppings.Text = sToppings;

        }

        void UpdateCrust()
        {

            UpdateTotalPrice();

            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }

            if(rbThickCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }

        }

        void UpdateWhereToEat()
        {

            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
                return;
            }

        }

        void UpdateHowMany()
        {
            UpdateTotalPrice();
            lblHowMany.Text = numHowMany.Value.ToString();
        }


        float GetSelectedSizePrice()
        {

            if (rbSmall.Checked) return Convert.ToSingle(rbSmall.Tag);
            else if (rbMeduim.Checked) return Convert.ToSingle(rbMeduim.Tag);
            else return Convert.ToSingle(rbLarge.Tag);

        }

        float CalculateToppingsPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chExtraCheese.Checked) ToppingsTotalPrice += Convert.ToSingle(chExtraCheese.Tag);
            if (chOnion.Checked) ToppingsTotalPrice += Convert.ToSingle(chOnion.Tag);
            if (chMushrooms.Checked) ToppingsTotalPrice += Convert.ToSingle(chMushrooms.Tag);
            if (chOlives.Checked) ToppingsTotalPrice += Convert.ToSingle(chOlives.Tag);
            if (chTomatoes.Checked) ToppingsTotalPrice += Convert.ToSingle(chTomatoes.Tag);
            if (chGreenPeppers.Checked) ToppingsTotalPrice += Convert.ToSingle(chGreenPeppers.Tag);

            return ToppingsTotalPrice;

        }

        float GetSelectedCrustPrice()
        {

            if (rbThinCrust.Checked) return Convert.ToSingle(rbThinCrust.Tag);
            else return Convert.ToSingle(rbThickCrust.Tag);

        }

        int GetHowMany()
        {

            return ((int)numHowMany.Value);

        }


        float CalculateTotalPrice()
        {
            return (GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrustPrice()) * GetHowMany();
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
            UpdateHowMany();
        }

        void ResetForm()
        {

            //reset Groups
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbHowMany.Enabled = true;

            //reset Size
            rbMeduim.Checked = true;

            //reset Toppings.
            chExtraCheese.Checked = false;
            chOnion.Checked = false;
            chMushrooms.Checked = false;
            chOlives.Checked = false;
            chTomatoes.Checked = false;
            chGreenPeppers.Checked = false;

            //reset CrustType
            rbThinCrust.Checked = true;

            //reset Where to Eat
            rbEatIn.Checked = true;

            //reset How Many
            numHowMany.Value = 1;

            //Reset Order Button
            btnOrderPizza.Enabled = true;

        }


        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                gbHowMany.Enabled = false;

            }
            else MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void chExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void MainPizzaForm_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void numHowMany_ValueChanged(object sender, EventArgs e)
        {
            UpdateHowMany();
        }


    }
}
