namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Item itemCoffee = new Item();
        Item itemGreentea = new Item();
        Item itemNoodle = new Item();
        Item itemPizza = new Item();
        public Form1()
        {
            InitializeComponent();

            itemCoffee.Name = "Coffee";
            itemCoffee.Price = 75;
            itemCoffee.Quantity = 0;

            itemGreentea.Name = "Greentea";
            itemGreentea.Price = 55;
            itemGreentea.Quantity = 0;

            itemNoodle.Name = "Noodle";
            itemNoodle.Price = 50;
            itemNoodle.Quantity = 0;

            itemPizza.Name = "Pizza";
            itemPizza.Price = 159;
            itemPizza.Quantity = 0;


            tbCoffeePrice.Text = itemCoffee.Price.ToString();
            tbCoffeeQuantity.Text = itemGreentea.Quantity.ToString();

            tbGreenTeaPrice.Text = itemGreentea.Price.ToString();
            tbGreenTeaQuantity.Text = itemGreentea.Quantity.ToString();

            tbNoodlePrice.Text = itemNoodle.Price.ToString();
            tbNoodleQuantity.Text = itemNoodle.Quantity.ToString();

            tbPizzaPrice.Text = itemPizza.Price.ToString();
            tbPizzaQuantity.Text = itemPizza.Quantity.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    double dCash = double.Parse(tbCash.Text);

                    double dBeverageTotal = 0;
                    double dFoodTotal = 0;

                    if (chbCoffee.Checked)
                    {
                        itemCoffee.Quantity = int.Parse(tbCoffeeQuantity.Text);
                        dBeverageTotal += itemCoffee.GetTotalPrice();
                    }
                    if (chbGreenTea.Checked)
                    {
                        itemGreentea.Quantity = int.Parse(tbGreenTeaQuantity.Text);
                        dBeverageTotal += itemGreentea.GetTotalPrice();
                    }

                    if (chbNoodle.Checked)
                    {
                        itemNoodle.Quantity = int.Parse(tbNoodleQuantity.Text);
                        dFoodTotal += itemNoodle.GetTotalPrice();
                    }
                    if (chbPizza.Checked)
                    {
                        itemPizza.Quantity = int.Parse(tbPizzaQuantity.Text);
                        dFoodTotal += itemPizza.GetTotalPrice();
                    }

                    double dGrandTotal = dBeverageTotal + dFoodTotal;

                    double dTotalDiscount = CalculateTotalDiscount(dBeverageTotal, dFoodTotal, dGrandTotal);

                    dGrandTotal -= dTotalDiscount;

                    if (dCash < dGrandTotal)
                    {
                        MessageBox.Show("เงินสดไม่เพียงพอ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    double dChange = dCash - dGrandTotal;

                    tbTotal.Text = dGrandTotal.ToString("F2");
                    tbChange.Text = dChange.ToString("F2");

                    CalculateChangeDenominations(dChange);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please fill in the numbers correctly", "Eoror", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private double CalculateTotalDiscount(double dBeverageTotal, double dFoodTotal, double dGrandTotal)
        {
            double dDiscountBev = chbBeverage.Checked ? double.Parse(tbBeverageDiscount.Text) : 0;
            double dDiscountFood = chbFood.Checked ? double.Parse(tbFoodDiscount.Text) : 0;
            double dDiscountAll = chbAll.Checked ? double.Parse(tbTotalDiscount.Text) : 0;

            double dTotalDiscount = (dBeverageTotal * dDiscountBev / 100) + (dFoodTotal * dDiscountFood / 100) + (dGrandTotal * dDiscountAll / 100);

            return dTotalDiscount;
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb1000.Text = changeCount[0].ToString();
            tb500.Text = changeCount[1].ToString();
            tb100.Text = changeCount[2].ToString();
            tb50.Text = changeCount[3].ToString();
            tb20.Text = changeCount[4].ToString();
            tb10.Text = changeCount[5].ToString();
            tb5.Text = changeCount[6].ToString();
            tb1.Text = changeCount[7].ToString();
            tb050.Text = changeCount[8].ToString();
            tb025.Text = changeCount[9].ToString();
        }
    }
}
