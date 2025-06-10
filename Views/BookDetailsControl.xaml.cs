using HomeLibrary;
using System.Windows;
using System.Windows.Controls;

namespace WPF_TSD_project.Views
{
    public partial class BookDetailsControl : UserControl
    {
        private Book currentBook;

        public BookDetailsControl()
        {
            InitializeComponent();
            this.DataContext = null;
        }

        public void SetBook(Book book)
        {
            currentBook = book;
            this.DataContext = currentBook;
        }

        public event RoutedEventHandler<Book> DeleteRequested;

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBook != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete "{currentBook.Title}"?", "Confirm Deletion", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteRequested?.Invoke(this, currentBook);
                }
            }
        }
    }
}
