using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Enumz;
using BookHavenWinFormUi.Utilz;
using ScottPlot.Colormaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace BookHavenWinFormUi.PanelForms.Books
{
    public partial class BookDetailsDialog : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BookRequestDto BookData { get; set; }
        private bool _isEditMode = false;
        public event Action<BookRequestDto>? OnBookAdded;
        public BookDetailsDialog()
        {
            InitializeComponent();
            _isEditMode = false;

            BookData = new BookRequestDto
            {
                Title = "",
                Author = "",
                BookGenre = BookHavenClassLibrary.Enumz.BookGenres.Fiction, // Default genre
                Isbn = "",
                SellingPrice = 0,
                StockQuantity = 0
            };
            this.Load += BookDetailsDialog_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        // Constructor for Edit mode
        public BookDetailsDialog(BookResponseDto bookToEdit)
        {
            InitializeComponent();
            Text = "Edit Book";
            btnSave.Text = "Update Book";
            _isEditMode = true;

            // Initialize BookData from the existing book
            BookData = new BookRequestDto
            {
                Title = bookToEdit.Title,
                Author = bookToEdit.Author,
                BookGenre = bookToEdit.BookGenre,
                Isbn = bookToEdit.Isbn,
                SellingPrice = bookToEdit.SellingPrice,
                StockQuantity = bookToEdit.StockQuantity
            };

            // Setup event handlers
            this.Load += BookDetailsDialog_Load;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void BookDetailsDialog_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.LoadEnumToComboBox<BookGenres>(cmbGenreList);
            //LoadGenresToComboBox();

            // If in edit mode, populate the fields with existing data
            if (_isEditMode)
            {
                txtBookTitle.Text = BookData.Title;
                txtAuthorName.Text = BookData.Author;
                txtISBN.Text = BookData.Isbn;
                txtSellingPrice.Text = BookData.SellingPrice.ToString();
                txtCurrentStock.Text = BookData.StockQuantity.ToString();
                cbAddAnother.Visible = false;
                // Select the correct genre
                ComboBoxHelper.SelectEnumInComboBox<BookGenres>(cmbGenreList, BookData.BookGenre);
                //SelectGenreInComboBox(BookData.BookGenre);
            }
        }

        //private void LoadGenresToComboBox()
        //{
        //    // Get all enum values
        //    var genres = Enum.GetValues(typeof(BookGenres))
        //                     .Cast<BookGenres>();

        //    // Create a list to store display names and values
        //    var genreList = new List<KeyValuePair<string, BookGenres>>();

        //    // Iterate through each enum value to get the display name from EnumMember attribute
        //    foreach (var genre in genres)
        //    {
        //        // Get enum type
        //        Type type = typeof(BookGenres);

        //        // Get field info for the current enum value
        //        var fieldInfo = type.GetField(genre.ToString());

        //        // Get EnumMember attribute if present
        //        var enumMemberAttribute = fieldInfo.GetCustomAttributes(
        //            typeof(EnumMemberAttribute), false)
        //            .FirstOrDefault() as EnumMemberAttribute;

        //        // Get display name (either from attribute or enum name)
        //        string displayName = enumMemberAttribute?.Value ?? genre.ToString();

        //        // Add to list
        //        genreList.Add(new KeyValuePair<string, BookGenres>(displayName, genre));
        //    }

        //    // Set the data source, display and value members
        //    cmbGenreList.DataSource = genreList;
        //    cmbGenreList.DisplayMember = "Key";   // Display name from EnumMember attribute
        //    cmbGenreList.ValueMember = "Value";   // Actual enum value
        //}

        //private void SelectGenreInComboBox(BookGenres genre)
        //{
        //    for (int i = 0; i < cmbGenreList.Items.Count; i++)
        //    {
        //        var item = (KeyValuePair<string, BookGenres>)cmbGenreList.Items[i];
        //        if (item.Value == genre)
        //        {
        //            cmbGenreList.SelectedIndex = i;
        //            break;
        //        }
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                MessageBox.Show("Please enter a book title.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAuthorName.Text))
            {
                MessageBox.Show("Please enter an author name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthorName.Focus();
                return;
            }

            if (cmbGenreList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a genre.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGenreList.Focus();
                return;
            }

            // Try parsing numeric values
            decimal sellingPrice;
            if (!decimal.TryParse(txtSellingPrice.Text, out sellingPrice) || sellingPrice < 0)
            {
                MessageBox.Show("Please enter a valid selling price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSellingPrice.Focus();
                return;
            }

            int stockQuantity;
            if (!int.TryParse(txtCurrentStock.Text, out stockQuantity) || stockQuantity < 0)
            {
                MessageBox.Show("Please enter a valid stock quantity.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentStock.Focus();
                return;
            }

            // Get selected genre
            var selectedItem = (KeyValuePair<string, BookGenres>)cmbGenreList.SelectedItem;
            BookGenres selectedGenre = selectedItem.Value;

            // Update BookData
            BookData.Title = txtBookTitle.Text;
            BookData.Author = txtAuthorName.Text;
            BookData.BookGenre = selectedGenre;
            BookData.Isbn = txtISBN.Text;
            BookData.SellingPrice = sellingPrice;
            BookData.StockQuantity = stockQuantity;



            // If cbAddAnother is checked, keep dialog open and reset fields
            if (cbAddAnother.Checked && !_isEditMode)
            {
                OnBookAdded?.Invoke(BookData); // Send book to caller
                MessageBox.Show("Book saved. Ready to add another.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                return;
            }
            if (!_isEditMode)
            {
                OnBookAdded?.Invoke(BookData);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.OK;

                Close();
            }

                // Close dialog with success
              
            Close();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ResetForm()
        {
            txtBookTitle.Clear();
            txtAuthorName.Clear();
            txtISBN.Clear();
            txtSellingPrice.Clear();
            txtCurrentStock.Clear();
            cmbGenreList.SelectedIndex = 0;

            BookData = new BookRequestDto
            {
                Title = "",
                Author = "",
                BookGenre = BookGenres.Fiction,
                Isbn = "",
                SellingPrice = 0,
                StockQuantity = 0
            };

            txtBookTitle.Focus();

            BookData = new BookRequestDto
            {
                Title = "",
                Author = "",
                BookGenre = BookHavenClassLibrary.Enumz.BookGenres.Fiction, // Default genre
                Isbn = "",
                SellingPrice = 0,
                StockQuantity = 0
            };
        }
    }
}
