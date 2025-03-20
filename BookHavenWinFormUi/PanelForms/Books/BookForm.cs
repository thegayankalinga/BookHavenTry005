using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Enumz;
using BookHavenClassLibrary.Interfaces;
using BookHavenWinFormUi.PanelForms.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BookHavenWinFormUi.PanelForms
{
    public partial class BookForm : Form
    {
        private readonly IBookRepository _bookRepository;
        private int? editingBookId = null;
        private List<BookResponseDto> allBooks = new List<BookResponseDto>();

        public BookForm(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            InitializeComponent();
            this.Load += BookForm_Load;
        }

        private void ConfigureDataGridView()
        {
            // Clear existing columns
            gridViewBookList.Columns.Clear();

            // Add columns
            gridViewBookList.ColumnCount = 7;

            gridViewBookList.Columns[0].Name = "ID";
            gridViewBookList.Columns[1].Name = "Title";
            gridViewBookList.Columns[2].Name = "Author";
            gridViewBookList.Columns[3].Name = "Genre";
            gridViewBookList.Columns[4].Name = "ISBN";
            gridViewBookList.Columns[5].Name = "Price";
            gridViewBookList.Columns[6].Name = "StockQty";

            // Set auto-sizing for better appearance
            gridViewBookList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBookList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridViewBookList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBookList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBookList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBookList.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridViewBookList.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            // Set row height to make it look better
            gridViewBookList.RowTemplate.Height = 30;

            // Enable full row selection
            gridViewBookList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridViewBookList.MultiSelect = false;

            // Set better visual appearance
            gridViewBookList.AllowUserToAddRows = false;
            gridViewBookList.AllowUserToResizeColumns = true;
            gridViewBookList.AllowUserToResizeRows = false;
            gridViewBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewBookList.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridViewBookList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            gridViewBookList.RowTemplate.Height = 30;
            gridViewBookList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridViewBookList.MultiSelect = false;
            gridViewBookList.AllowUserToAddRows = false;

        }

        private async Task LoadBooksAsync()
        {


            if (gridViewBookList.InvokeRequired)
            {
                gridViewBookList.Invoke(new MethodInvoker(async () => await LoadBooksAsync()));
                return;
            }

            if (gridViewBookList.Columns.Count == 0)
            {
                ConfigureDataGridView();
            }

            gridViewBookList.Rows.Clear();

            allBooks = await _bookRepository.GetAllBooksAsync().ConfigureAwait(false);

            // Ensure UI update happens on the main thread
            DisplayAllBooks(allBooks);

        }

        private void DisplayAllBooks(List<BookResponseDto> booksToDisplay)
        {

            if (gridViewBookList.InvokeRequired)
            {
                gridViewBookList.Invoke(new MethodInvoker(() => DisplayAllBooks(booksToDisplay)));
                return;
            }

            gridViewBookList.Rows.Clear();

            foreach (var book in booksToDisplay)
            {
                // Prevent duplicate entries in DataGridView
                if (!gridViewBookList.Rows.Cast<DataGridViewRow>()
                    .Any(row => Convert.ToInt32(row.Cells["ID"].Value) == book.BookId))
                {
                    gridViewBookList.Rows.Add(
                        book.BookId,
                        book.Title,
                        book.Author,
                        book.BookGenre,
                        book.Isbn,
                        book.SellingPrice,
                        book.StockQuantity
                    );
                }
            }
        }


        private async void BookForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Form is loading");
            ConfigureDataGridView();
            await LoadBooksAsync();
            SetupFilterComboBoxes();


        }

        private void SetupFilterComboBoxes()
        {
            LoadGenresToFilterComboBox();
            LoadAuthorsToFilterComboBox();
        }

        private void LoadGenresToFilterComboBox()
        {
            var genres = Enum.GetValues(typeof(BookGenres))
                .Cast<BookGenres>();

            var genreList = new List<KeyValuePair<string, BookGenres>>();
            genreList.Add(new KeyValuePair<string, BookGenres>("All Genres", 0));

            foreach (var genre in genres)
            {
                Type type = typeof(BookGenres);
                var fieldInfo = type.GetField(genre.ToString());

                var enumMemberAttribute = fieldInfo.GetCustomAttributes(
                    typeof(EnumMemberAttribute), false)
                    .FirstOrDefault() as EnumMemberAttribute;

                string displayName = enumMemberAttribute?.Value ?? genre.ToString();
                genreList.Add(new KeyValuePair<string, BookGenres>(displayName, genre));
            }

            cmbGenre.DataSource = genreList;
            cmbGenre.DisplayMember = "Key";
            cmbGenre.ValueMember = "Value";
        }

        private void LoadAuthorsToFilterComboBox()
        {
            var authors = allBooks.Select(b => b.Author).Distinct().OrderBy(allBooks => allBooks).ToList();
            authors.Insert(0, "All Authors");
            cmbAuthor.DataSource = authors;
        }

        private void ApplyFilters()
        {
            string searchText = txtSearchKey.Text.Trim().ToLower();
            string selectedAuthor = cmbAuthor.SelectedItem != null ? cmbAuthor.SelectedItem.ToString() : string.Empty;

            //string selectedAuthor = cmbAuthor.SelectedItem.ToString();
            var selectedGenreItem = cmbGenre.SelectedItem as KeyValuePair<string, BookGenres>?;

            var filterBooks = allBooks.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                filterBooks = filterBooks.Where(b =>
                b.Title.ToLower().Contains(searchText) ||
                b.Isbn.ToLower().Contains(searchText)).ToList();
            }

            if (selectedGenreItem.HasValue && selectedGenreItem.Value.Key != "All Genres")
            {
                BookGenres selectedGenre = selectedGenreItem.Value.Value;
                filterBooks = filterBooks.Where(b => b.BookGenre == selectedGenre).ToList();
            }

            DisplayAllBooks(filterBooks);
        }

        private void LoadGenresToComboBox()
        {
            // Get all enum values
            var genres = Enum.GetValues(typeof(BookHavenClassLibrary.Enumz.BookGenres))
                             .Cast<BookHavenClassLibrary.Enumz.BookGenres>();

            // Create a list to store display names and values
            var genreList = new List<KeyValuePair<string, BookHavenClassLibrary.Enumz.BookGenres>>();

            // Iterate through each enum value to get the display name from EnumMember attribute
            foreach (var genre in genres)
            {
                // Get enum type
                Type type = typeof(BookHavenClassLibrary.Enumz.BookGenres);

                // Get field info for the current enum value
                var fieldInfo = type.GetField(genre.ToString());

                // Get EnumMember attribute if present
                var enumMemberAttribute = fieldInfo.GetCustomAttributes(
                    typeof(EnumMemberAttribute), false)
                    .FirstOrDefault() as EnumMemberAttribute;

                // Get display name (either from attribute or enum name)
                string displayName = enumMemberAttribute?.Value ?? genre.ToString();

                // Add to list
                genreList.Add(new KeyValuePair<string, BookHavenClassLibrary.Enumz.BookGenres>(displayName, genre));
            }

            // Set the data source, display and value members
            cmbGenre.DataSource = genreList;
            cmbGenre.DisplayMember = "Key";   // Display name from EnumMember attribute
            cmbGenre.ValueMember = "Value";   // Actual enum value
        }

        private async void btnSaveBook_Click(object sender, EventArgs e)
        {
            using (var bookDialog = new BookDetailsDialog())
            {
                if (bookDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the book data from the dialog
                    BookRequestDto newBook = bookDialog.BookData;

                    // Save to repository
                    SaveBookAsync(newBook, null);
                }
            }

        }

        private void cmbBookGenres_MouseClick(object sender, MouseEventArgs e)
        {
            LoadGenresToComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true; // Prevent the Enter key sound
            }
        }

        private void cmbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            // Reset search box and filters
            txtSearchKey.Text = string.Empty;
            cmbAuthor.SelectedIndex = 0; // "All Authors"
            cmbGenre.SelectedIndex = 0; // "All Genres"

            // Display all books
            DisplayAllBooks(allBooks);
        }

        private async void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (gridViewBookList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete.", "No Book Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected book ID
            int bookId = Convert.ToInt32(gridViewBookList.SelectedRows[0].Cells[0].Value);
            string bookTitle = gridViewBookList.SelectedRows[0].Cells[1].Value.ToString();

            // Confirm deletion
            var result = MessageBox.Show($"Are you sure you want to delete '{bookTitle}'?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete from repository
                    await _bookRepository.DeleteBookAsync(bookId);

                    MessageBox.Show("Book deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the book list
                    await LoadBooksAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting book: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void SaveBookAsync(BookRequestDto bookData, int? bookId)
        {
            try
            {
                if (bookId == null)
                {
                    // Add new book
                    await _bookRepository.AddBookAsync(bookData);
                    MessageBox.Show("Book added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing book
                    await _bookRepository.UpdateBookAsync((int)bookId, bookData);
                    MessageBox.Show("Book updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refresh the book list
                await LoadBooksAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving book: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (gridViewBookList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to edit.", "No Book Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected book ID
            int bookId = Convert.ToInt32(gridViewBookList.SelectedRows[0].Cells[0].Value);

            // Find the book in our list
            var bookToEdit = allBooks.FirstOrDefault(b => b.BookId == bookId);

            if (bookToEdit != null)
            {
                // Create and show the modal dialog for editing the book
                using (var bookDialog = new BookDetailsDialog(bookToEdit))
                {
                    if (bookDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the updated book data from the dialog
                        BookRequestDto updatedBook = bookDialog.BookData;

                        // Update in repository
                        SaveBookAsync(updatedBook, bookId);
                    }
                }
            }
        }
    }
}
