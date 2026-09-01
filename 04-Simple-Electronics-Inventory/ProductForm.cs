using ElectronicsInventory.Database;
using ElectronicsInventory.Models;

namespace ElectronicsInventory;

public partial class ProductForm : Form
{
    private readonly Product? _existingProduct;

    /// <summary>Add mode</summary>
    public ProductForm()
    {
        InitializeComponent();
        Text = "Add Product";
        lblTitle.Text = "Add Product";
    }

    /// <summary>Edit mode</summary>
    public ProductForm(Product product) : this()
    {
        _existingProduct = product;
        Text = "Edit Product";
        lblTitle.Text = "Edit Product";

        txtName.Text = product.Name;
        txtCategory.Text = product.Category;
        txtPrice.Text = product.Price.ToString("F2");
        txtQuantity.Text = product.Quantity.ToString();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string category = txtCategory.Text.Trim();
        string priceText = txtPrice.Text.Trim();
        string quantityText = txtQuantity.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(category))
        {
            MessageBox.Show("Please enter a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCategory.Focus();
            return;
        }

        if (!decimal.TryParse(priceText, out decimal price) || price < 0)
        {
            MessageBox.Show("Please enter a valid price (0 or greater).", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPrice.Focus();
            return;
        }

        if (!int.TryParse(quantityText, out int quantity) || quantity < 0)
        {
            MessageBox.Show("Please enter a valid quantity (0 or greater).", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtQuantity.Focus();
            return;
        }

        try
        {
            if (_existingProduct is null)
            {
                DatabaseConnection.InsertProduct(name, category, price, quantity);
                MessageBox.Show("Product added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DatabaseConnection.UpdateProduct(_existingProduct.Id, name, category, price, quantity);
                MessageBox.Show("Product updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not save product.\n\n" + ex.Message, "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
