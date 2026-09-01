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

        // Default dates for new products
        dtpManufactureDate.Value = DateTime.Today;
        dtpExpiryDate.Value = DateTime.Today.AddYears(2);

        if (cmbCategory.Items.Count > 0)
            cmbCategory.SelectedIndex = 0;
    }

    /// <summary>Edit mode</summary>
    public ProductForm(Product product) : this()
    {
        _existingProduct = product;
        Text = "Edit Product";
        lblTitle.Text = "Edit Product";

        txtName.Text = product.Name;

        // Select matching category in dropdown (or add it if missing)
        int catIndex = cmbCategory.FindStringExact(product.Category);
        if (catIndex >= 0)
            cmbCategory.SelectedIndex = catIndex;
        else
        {
            cmbCategory.Items.Add(product.Category);
            cmbCategory.SelectedItem = product.Category;
        }

        txtPrice.Text = product.Price.ToString("F2");
        txtQuantity.Text = product.Quantity.ToString();
        dtpManufactureDate.Value = product.ManufactureDate;
        dtpExpiryDate.Value = product.ExpiryDate;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string category = cmbCategory.SelectedItem?.ToString()?.Trim() ?? string.Empty;
        string priceText = txtPrice.Text.Trim();
        string quantityText = txtQuantity.Text.Trim();
        DateTime manufactureDate = dtpManufactureDate.Value.Date;
        DateTime expiryDate = dtpExpiryDate.Value.Date;

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(category))
        {
            MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbCategory.Focus();
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

        if (expiryDate < manufactureDate)
        {
            MessageBox.Show("Expiry date cannot be before manufacture date.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpExpiryDate.Focus();
            return;
        }

        try
        {
            if (_existingProduct is null)
            {
                DatabaseConnection.InsertProduct(name, category, price, quantity, manufactureDate, expiryDate);
                MessageBox.Show("Product added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DatabaseConnection.UpdateProduct(_existingProduct.Id, name, category, price, quantity,
                    manufactureDate, expiryDate);
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
