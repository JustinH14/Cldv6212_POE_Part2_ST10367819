using System.Text;

namespace icetask3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             comboBox1.Items.Add("Coffee");
            comboBox1.Items.Add("Tea");
            comboBox1.Items.Add("Milkshake");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            private void btnAddToOrder_Click(object sender, EventArgs e)
            {
                var selectedItem = comboBox1.SelectedItem.ToString();
                var quantity = (int)numericUpDown1.Value;
                var pricePerItem = GetPricePerItem(selectedItem); // Implement this method to return the price of the selected item
                var totalPrice = pricePerItem * quantity;

                listBox1.Items.Add($"{selectedItem} x{quantity} - ${totalPrice}");


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           private void btnDisplayReceipt_Click(object sender, EventArgs e)
            {
                var receiptItems = new StringBuilder();
                foreach (var item in listBox1.Items)
                {
                    receiptItems.AppendLine(item.ToString());
                }

                MessageBox.Show(receiptItems.ToString(), "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>
{
    {"Coffee", 2.99m},
    {"Tea", 1.99m},
    {"Milkshake", 3.99m}
};

        private decimal GetPricePerItem(string itemName)
        {
            if (itemPrices.TryGetValue(itemName, out var price))
            {
                return price;
            }
            return 0; // Return 0 or throw an exception if the item is not found
        }
    }
}
