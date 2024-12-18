using Microsoft.Data.SqlClient;

namespace lab_11_web_2;

public partial class Page1 : ContentPage
{
    List<BookCata> BookC = new List<BookCata>();
    public Page1()
	{
        InitializeComponent();
        BookC.Add(new BookCata
        { cataTitle = "Sience Books", ImageUrl = "b1.jpg", cata = 1 });
        BookC.Add(new BookCata
        { cataTitle = "Programming Books", ImageUrl = "b2.jpg", cata = 2 });
        BookC.Add(new BookCata
        { cataTitle = "Math Books", ImageUrl = "b3.jpg", cata = 3 });
        BookC.Add(new BookCata
        { cataTitle = "IT Books", ImageUrl = "b4.jpg", cata = 4 });
        BookC.Add(new BookCata
        { cataTitle = "General Books", ImageUrl = "b5.jpg", cata = 5 });
        BookC.Add(new BookCata
        { cataTitle = "Data Books", ImageUrl = "b6.jpg", cata = 6 });
        collView.ItemsSource = BookC;

    }

    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BookCata current = (e.CurrentSelection.FirstOrDefault() as BookCata);

        List<Book> Books = new List<Book>();
        SqlConnection con = new SqlConnection("Data Source=SQL9001.site4now.net;User ID=db_aaf4eb_fahad12x_admin;Password=QWERTasdfg12x");
        String sql;
        sql = "SELECT * FROM book where category = '" + current.cata + "'";
        SqlCommand comm = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader reader = comm.ExecuteReader();
        while (reader.Read())
        {
            Books.Add(new Book
            {
                Title = (string)reader["title"],
                Price = (int)(reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0),
                ImageUrl = (string)reader["imgfile"]
            });
        }
        reader.Close();
        con.Close();
        myListView.ItemsSource = Books;
    }


    private void myListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Book selectedBook = e.SelectedItem as Book;
        selectedBook.quant = 1;
        Navigation.PushAsync(new Page2(selectedBook));
    }



}