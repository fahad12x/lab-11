using Microsoft.Data.SqlClient;

namespace lab_11_web_2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            if (Preferences.ContainsKey("Name"))
            {
                Navigation.PushAsync(new Page1());
            }
        }

        private void Button_Clicked(object sender, EventArgs e) // login button
        {
            SqlConnection con = new SqlConnection("Data Source=SQL9001.site4now.net;User ID=db_aaf4eb_fahad12x_admin;Password=QWERTasdfg12x");
            String sql;
            sql = "select * from usersaccounts  where name = '" + txt1.Text + "' and pass = '" + txt2.Text + "' ";
            SqlCommand comm = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                Preferences.Set("Name", txt1.Text);
                Preferences.Set("Pass", txt2.Text);

                Navigation.PushAsync(new Page1());
            } // home page


            else
                DisplayAlert("Alert", "Wrong username or password", "OK");

            reader.Close();
            con.Close();
        }

    }

}
