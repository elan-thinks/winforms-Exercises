using ElectronicsInventory.Database;
using ElectronicsInventory.Models;

namespace ElectronicsInventory;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadProducts();
    }

    private void LoadProducts()
    {
        try
        {
            var products = DatabaseConnection.GetAllProducts();
            BindProducts(products);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Could not load products.\n\n" +
                "Make sure the 'products' table exists in database winforms_exercises.\n\n" +
                "Error: " + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void BindProducts(List<Product> products)
    {
        dgvProducts.Rows.Clear();
        foreach (var p in products)
        {
            dgvProducts.Rows.Add(p.Id, p.Name, p.Category, p.Price.ToString("F2"), p.Quantity);
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        string search = txtSearch.Text.Trim();
        if (string.IsNullOrWhiteSpace(search))
        {
            LoadProducts();
            return;
        }

        try
        {
            var products = DatabaseConnection.SearchProducts(search);
            BindProducts(products);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Search failed.\n\n" + ex.Message, "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClearSearch_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        LoadProducts();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        LoadProducts();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using var form = new ProductForm();
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            LoadProducts();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvProducts.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a product first.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var row = dgvProducts.SelectedRows[0];
        var product = new Product
        {
            Id = Convert.ToInt32(row.Cells["colId"].Value),
            Name = row.Cells["colName"].Value?.ToString() ?? "",
            Category = row.Cells["colCategory"].Value?.ToString() ?? "",
            Price = decimal.Parse(row.Cells["colPrice"].Value?.ToString() ?? "0"),
            Quantity = int.Parse(row.Cells["colQuantity"].Value?.ToString() ?? "0")
        };

        using var form = new ProductForm(product);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            LoadProducts();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvProducts.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a product first.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("Are you sure you want to delete this product?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["colId"].Value);
            DatabaseConnection.DeleteProduct(id);
            MessageBox.Show("Product deleted successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not delete product.\n\n" + ex.Message, "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
