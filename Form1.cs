using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Collections.Specialized;

//TODO HANDLE APOSTRAPHES 

namespace PolekForm
{
    public partial class Form1 : Form
    {
        //Connection information for the server
        private string ConnectionInfo;


        public Form1()
        {
            InitializeComponent();

            // initialize database connection string:
            string version = "MSSQLLocalDB";
            string filename = "|DataDirectory|\\PolekServer.mdf";

            ConnectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename={1};Integrated Security=True;",
              version, filename);


            updateTitleBar();


            //Print newlines to console for easy reading
            Console.Out.WriteLine();
            Console.Out.WriteLine();
            Console.Out.WriteLine();
            Console.Out.WriteLine();
        }

        private void updateTitleBar()
        {
            //Connect to the DB
            SqlConnection db;

            db = new SqlConnection(ConnectionInfo);
            db.Open();

            //Query
            string sql = String.Format(@"
            SELECT COUNT(*) AS Count FROM Films;
            ");

            //Execute query and fill adapter
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            cmd.CommandText = sql;
            adapter.Fill(ds);

            //Close connection
            db.Close();

            //Fill listbox
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                string msg = string.Format("{0}",
                  Convert.ToString(row["Count"]));

                //Display total film count in title
                this.Text = "PolekDVD.   Total Films: " + msg;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get the movie title
            string movieTitle = searchTextBox.Text.Replace("'","''");


            //Change the spaces in title to be wildcards
            //REMEMBER STRINGS ARE IMMUTABLE SO YOU HAVE TO CREATE A NEW STRING,
            //IT DOESN'T HAPPEN AUTOMAGICALLY
            movieTitle = movieTitle.Replace(' ', '%');

            //Connect to the DB
            SqlConnection db;

            db = new SqlConnection(ConnectionInfo);
            db.Open();

            //Query
            //Use the 'N' delimiter in order to make the values nvars, for unicode.
            //Look this up
            string sql = String.Format(@"
            SELECT Title FROM Films 
            Where Title LIKE N'%{0}%'
            ORDER BY Title;
            ", movieTitle);

            //Execute query and fill adapter
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            cmd.CommandText = sql;
            adapter.Fill(ds);

            //Close connection
            db.Close();

            //Clear listbox
            foundMovies.Items.Clear();

            //Fill listbox
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                string msg = string.Format("{0}",
                  Convert.ToString(row["Title"]));

                //Console.Out.WriteLine(msg);

                //this.listBox1.Items.Add(msg);
                foundMovies.Items.Add(msg);
            }
        }

        private void FoundMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reset picture
            moviePicture.Image = null;

            //Get the movie title
            string movieTitle = foundMovies.GetItemText(foundMovies.SelectedItem).Replace("'","''");
            Console.Out.WriteLine(movieTitle);

            //Connect to the DB
            SqlConnection db;

            db = new SqlConnection(ConnectionInfo);
            db.Open();

            //Query
            string sql = String.Format(@"
            SELECT * FROM Films 
            Where Title LIKE N'{0}'
            ORDER BY Title;
            ", movieTitle);

            //Execute query and fill adapter
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            cmd.CommandText = sql;
            adapter.Fill(ds);

            //Close connection
            db.Close();

            //Fill Text Areas
            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                //Clear text
                changeTitle.Clear();
                changeLink.Clear();
                changeDate.Clear();
                changeGenre.Clear();
                changeRating.Clear();

                //Set text
                changeTitle.AppendText(Convert.ToString(row["Title"]));
                changeLink.AppendText(Convert.ToString(row["Link"]));
                changeDate.AppendText(Convert.ToString(row["Date"]));
                changeGenre.AppendText(Convert.ToString(row["Type"]));
                changeRating.AppendText(Convert.ToString(row["Rating"]));

            }


            //Get the HTML
            string htmlCode = "";
            try {
                using (WebClient client = new WebClient())
                {
                    htmlCode = client.DownloadString(changeLink.Text.ToString());
                }
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine("Could not get website html");
                Console.Out.WriteLine(ex.GetType().ToString());
            }


            //Agile HTML parse image
            try
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//img[@src]")
                                .Where(o => o.Attributes[0].Name == "src")
                                .ToList();

                //Display the image from the link
                moviePicture.Load(result[0].GetAttributeValue("src", null));
                moviePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex)
            {
                Console.Out.WriteLine("Could not load movie image");
                Console.Out.WriteLine(ex.GetType().ToString());
            }

        }


        private void openWebsiteButton_Click(object sender, EventArgs e)
        {
            //If link is not empty
            if (!string.IsNullOrWhiteSpace(changeLink.Text.ToString()) || !string.IsNullOrEmpty(changeLink.Text.ToString()))
            {
                string website = changeLink.Text.ToString();
                try { 
                System.Diagnostics.Process.Start(website);
                }
                catch(Exception c)
                {
                    MessageBox.Show("Could not open the website", "Bad Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.Out.WriteLine(c.GetType().ToString());
                }
            }
        }

        private void changeTitleBtn_Click(object sender, EventArgs e)
        {
            //If new title is empty, return
            if (string.IsNullOrWhiteSpace(changeTitle.Text.ToString()) || string.IsNullOrEmpty(changeTitle.Text.ToString()))
            {
                MessageBox.Show("New title must not be blank!", "Bad Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //If no source movie selected, return
            if(foundMovies.SelectedItem == null)
            {
                MessageBox.Show("No source movie selected", "No Source", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

       
            //Get the movie info
            string movieTitle = foundMovies.GetItemText(foundMovies.SelectedItem);
            string newMovieTitle = changeTitle.Text.ToString();
            string newMovieLink = changeLink.Text.ToString();
            string newMovieDate = changeDate.Text.ToString();
            string newMovieType = changeGenre.Text.ToString();
            string newMovieRating = changeRating.Text.ToString();


            //Connect to the DB
            SqlConnection db;

            db = new SqlConnection(ConnectionInfo);
            db.Open();

            //Query
            string sql = String.Format(@"
            UPDATE Films
            SET Title = N'{0}' , Link = N'{1}' , Date = N'{2}' , Type = N'{3}' , Rating = N'{4}' 
            Where Title LIKE N'{5}'
            ", newMovieTitle, newMovieLink, newMovieDate, newMovieType, newMovieRating, movieTitle);

            //Execute query and fill dataset
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            cmd.CommandText = sql;
            adapter.Fill(ds);

            //Close connection
            db.Close();

            //Refresh the search
            searchTextBox.Clear();
            searchTextBox.Text = newMovieTitle;

            //Call the search function to refresh the list
            button1_Click(new object(), new EventArgs());
        }

        private void Search_Click(object sender, EventArgs e)
        {
        }

        private void addMovieBtn_Click(object sender, EventArgs e)
        {
            //Clear the listbox
            foundLinksBox.Items.Clear();

            //Get the search string and format
            string searchQuery = addMovieTB.Text.ToString();
            string modifiedSearchQuery = searchQuery.Replace(' ', '+');

            Console.Out.WriteLine(modifiedSearchQuery);

            //Get the HTML
            string htmlCode = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var htmlData = client.DownloadData("http://www.filmweb.pl/search?q=" + modifiedSearchQuery);
                    htmlCode = Encoding.UTF8.GetString(htmlData);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not get website html");
                Console.Out.WriteLine(ex.GetType().ToString());
            }

            


            //Agile HTML parse links
            try
            {
                //Get the li id part
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//li[@id]");
                string htmlPart = "";
                foreach (var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                //Get the div part
                doc.LoadHtml(htmlPart);
                result = doc.DocumentNode
                            .SelectNodes("//div[@class]");
                htmlPart = "";
                foreach (var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                //Get the h3 part
                doc.LoadHtml(htmlPart);
                result = doc.DocumentNode
                            .SelectNodes("//h3");
                htmlPart = "";
                foreach (var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                //Get the link 
                doc.LoadHtml(htmlPart);
                result = doc.DocumentNode
                            .SelectNodes("//a");
                foreach (var item in result)
                {
                    //Add links to listbox
                    foundLinksBox.Items.Add("http://www.filmweb.pl" + item.GetAttributeValue("href", null));
                }

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not load movie links");
                Console.Out.WriteLine(ex.GetType().ToString());
            }

        }


        private void moviePicture_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void foundLinksBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear all fields
            newMoviePictureBx.Image = null;
            newMovieTitle.Clear();
            newMovieDate.Clear();
            newMovieGenre.Clear();
            newMovieRating.Clear();
            newMovieLink.Clear();

            //Get the link
            string link = foundLinksBox.GetItemText(foundLinksBox.SelectedItem);

            //Get the HTML
            string htmlCode = "";
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var htmlData = client.DownloadData(link);
                    htmlCode = Encoding.UTF8.GetString(htmlData);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not get website html");
                Console.Out.WriteLine(ex.GetType().ToString());
            }

            //Agile HTML parse image
            try
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//img[@src]")
                                .Where(o => o.Attributes[0].Name == "src")
                                .ToList();

                //Display the image from the link
                newMoviePictureBx.Load(result[0].GetAttributeValue("src", null));
                newMoviePictureBx.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not load movie image");
                Console.Out.WriteLine(ex.GetType().ToString());
            }

            //Agile HTML parse title
            try
            {

                //Polish / English

                //Get the h2 part
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//h1[@class]")
                                .Where(o => o.Attributes[0].Name == "class")
                                .ToList();
                string htmlPart = "";
                foreach (var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                //Get the Polish Title
                doc.LoadHtml(htmlPart);
                var result2 = doc.DocumentNode
                            .SelectNodes("//a[@typeof]");
                htmlPart = "";
                foreach (var item in result2)
                {
                    newMovieTitle.Text = item.GetAttributeValue("title", null);
                }

                //Get the English Title
                doc.LoadHtml(htmlCode);
                result = doc.DocumentNode.SelectNodes("//*[@id=\"body\"]/div/div/div[1]/div/div[1]/div[2]/div/div[1]/h2").ToList();

                newMovieTitle.Text += " / " + result[0].OuterHtml.Split('<','>')[2];

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not load movie title");
                Console.Out.WriteLine(ex.GetType().ToString());
            }


            //Put in link
            newMovieLink.Text = foundLinksBox.GetItemText(foundLinksBox.SelectedItem);

            //Agile HTML parse date
            try
            {
                //Get the span part
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//span[@class=\"halfSize\"]")
                                .Where(o => o.Attributes[0].Name == "class")
                                .ToList();
                string htmlPart = "";
                foreach (var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                //Get the date
                string date = htmlPart.Split('(', ')')[1];

                //Write date
                newMovieDate.Text = date;

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not load movie title");
                Console.Out.WriteLine(ex.GetType().ToString());
            }

            //Agile HTML parse rating
            try
            {
                //Get the span part
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//*[@id=\"sidebar\"]/div[1]/div[1]/div[2]/div/div[1]/div[1]/span[1]/span");
                string htmlPart = "";
                foreach (var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                Console.Out.WriteLine(htmlPart);

                //Get the rating part
                string[] numericSplitRating = htmlPart.Split('<', '>' );
                double numericRating = Convert.ToDouble((numericSplitRating[2].Replace(" ", "")).Replace(",","."));


                //Replace numeric with string
                //Conditions:
                // 7.6+ bardzo dobry
                // 6.5 - 7.5 dobry
                // 5.5 - 6.5 niezly
                // 4.5 - 5.5 sriedni
                // 3.5 - 4.5 ujdzie
                // 2.5 - 3.5 slaby
                string categRating = "";
                if (numericRating > 7.6)
                    categRating = "BARDZO DOBRY";
                else if ((numericRating <= 7.5) || (numericRating >= 6.5))
                    categRating = "DOBRY";
                else if ((numericRating <= 6.5) || (numericRating >= 5.5))
                    categRating = "NIEZLY";
                else if ((numericRating <= 5.5) || (numericRating >= 4.5))
                    categRating = "SRIEDNI";
                else if ((numericRating <= 4.5) || (numericRating >= 3.5))
                    categRating = "UJDZIE";
                else if ((numericRating <= 3.5))
                    categRating = "SLABY";


                //Set the rating
                newMovieRating.Text = categRating;

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not parse rating");
                Console.Out.WriteLine(ex.GetType().ToString());
            }


            //Agile HTML parse genre
            try
            {
                //Get the span part
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                var result = doc.DocumentNode
                                .SelectNodes("//ul[@class=\"inline sep-comma genresList\"]")
                                .Where(o => o.Attributes[0].Name == "class")
                                .ToList();
                string htmlPart = "";
                foreach(var item in result)
                {
                    htmlPart += item.OuterHtml;
                }

                //Get the genre part
                doc.LoadHtml(htmlPart);
                result = doc.DocumentNode.SelectNodes("//a[@href]").ToList();

                //Set the genre
                newMovieGenre.Text = result[0].OuterHtml.Split('<', '>')[2].ToUpper();

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Could not parse genre");
                Console.Out.WriteLine(ex.GetType().ToString());
            }
        }
    



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Open selected link
            try
            {
                System.Diagnostics.Process.Start(foundLinksBox.GetItemText(foundLinksBox.SelectedItem));
            }
            catch (Exception c)
            {
                MessageBox.Show("Could not open the website", "Bad Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.Out.WriteLine(c.GetType().ToString());
            }
        }

        private void addMovietoDBBtn_Click(object sender, EventArgs e)
        {
            //If title is not empty
            if (!string.IsNullOrWhiteSpace(newMovieTitle.Text.ToString()) || !string.IsNullOrEmpty(newMovieTitle.Text.ToString()))
            {
                //Get the movie info
                string movieTitle = newMovieTitle.Text.ToString().Replace("'","''");
                string movieLink = newMovieLink.Text.ToString();
                string movieDate = newMovieDate.Text.ToString();
                string movieType = newMovieGenre.Text.ToString();
                string movieRating = newMovieRating.Text.ToString();


                //Connect to the DB
                SqlConnection db;

                db = new SqlConnection(ConnectionInfo);
                db.Open();

                //Query
                string sql = String.Format(@"
            INSERT INTO Films (Title, Link, Date, Type, Rating)
            VALUES (N'{0}' , N'{1}' , N'{2}' , N'{3}' , N'{4}')
            ", movieTitle, movieLink, movieDate, movieType, movieRating);

                //Execute query and fill dataset
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                cmd.CommandText = sql;
                adapter.Fill(ds);

                //Close connection
                db.Close();

                MessageBox.Show("Movie added", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                updateTitleBar();
            }
        }

        private void removeMovieBtn_Click(object sender, EventArgs e)
        {
            //Get the movie parameters
            string movieTitle = changeTitle.Text.ToString().Replace("'", "''");
            string movieLink = changeLink.Text.ToString().Replace("'", "''");
            string movieDate = changeDate.Text.ToString().Replace("'", "''");
            string movieType = changeGenre.Text.ToString().Replace("'", "''");
            string movieRating = changeRating.Text.ToString().Replace("'", "''");

            //Are you sure?
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + movieTitle, "Remove Film", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            //Connect to the DB
            SqlConnection db;

            db = new SqlConnection(ConnectionInfo);
            db.Open();


            //Form the string
            string formatString = "";
            if (!string.IsNullOrWhiteSpace(movieLink) && !string.IsNullOrEmpty(movieLink))
                formatString += "AND Link = N'" + movieLink + "' ";
            if (!string.IsNullOrWhiteSpace(movieDate) && !string.IsNullOrEmpty(movieDate))
                formatString += "AND Date = N'" + movieDate + "' ";
            if (!string.IsNullOrWhiteSpace(movieType) && !string.IsNullOrEmpty(movieType))
                formatString += "AND Type = N'" + movieType + "' ";
            if (!string.IsNullOrWhiteSpace(movieRating) && !string.IsNullOrEmpty(movieRating))
                formatString += "AND Rating = N'" + movieRating + "' ";

            //Query
            string sql = String.Format(@"
            DELETE FROM Films
            WHERE Title = N'{0}' {1}
            ", movieTitle, formatString);

            //Execute query and fill dataset
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            cmd.CommandText = sql;
            adapter.Fill(ds);

            //Close connection
            db.Close();

            //Reset all fields
            changeTitle.Clear();
            changeDate.Clear();
            changeLink.Clear();
            changeRating.Clear();
            changeGenre.Clear();
            moviePicture.Image = null;

            //Call the search function to refresh the list
            button1_Click(new object(), new EventArgs());

            updateTitleBar();
        }

        private void addMovieTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
