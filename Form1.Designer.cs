namespace PolekForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Search = new System.Windows.Forms.TabPage();
            this.removeMovieBtn = new System.Windows.Forms.Button();
            this.moviePicture = new System.Windows.Forms.PictureBox();
            this.changeTitleBtn = new System.Windows.Forms.Button();
            this.openWebsiteButton = new System.Windows.Forms.Button();
            this.genreResultLabel = new System.Windows.Forms.Label();
            this.ratingResultLabel = new System.Windows.Forms.Label();
            this.dateResultLabel = new System.Windows.Forms.Label();
            this.linkResultLabel = new System.Windows.Forms.Label();
            this.titleResultLabel = new System.Windows.Forms.Label();
            this.changeGenre = new System.Windows.Forms.TextBox();
            this.changeRating = new System.Windows.Forms.TextBox();
            this.changeDate = new System.Windows.Forms.TextBox();
            this.changeLink = new System.Windows.Forms.TextBox();
            this.changeTitle = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.foundMovies = new System.Windows.Forms.ListBox();
            this.AddTab = new System.Windows.Forms.TabPage();
            this.addMovietoDBBtn = new System.Windows.Forms.Button();
            this.newOpenLinkBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newMovieGenre = new System.Windows.Forms.TextBox();
            this.newMovieRating = new System.Windows.Forms.TextBox();
            this.newMovieDate = new System.Windows.Forms.TextBox();
            this.newMovieLink = new System.Windows.Forms.TextBox();
            this.newMovieTitle = new System.Windows.Forms.TextBox();
            this.newMoviePictureBx = new System.Windows.Forms.PictureBox();
            this.foundLinksBox = new System.Windows.Forms.ListBox();
            this.addMovieBtn = new System.Windows.Forms.Button();
            this.addMovieTB = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviePicture)).BeginInit();
            this.AddTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newMoviePictureBx)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(439, 30);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(162, 20);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Search);
            this.tabControl1.Controls.Add(this.AddTab);
            this.tabControl1.Location = new System.Drawing.Point(-6, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(985, 463);
            this.tabControl1.TabIndex = 1;
            // 
            // Search
            // 
            this.Search.Controls.Add(this.removeMovieBtn);
            this.Search.Controls.Add(this.moviePicture);
            this.Search.Controls.Add(this.changeTitleBtn);
            this.Search.Controls.Add(this.openWebsiteButton);
            this.Search.Controls.Add(this.genreResultLabel);
            this.Search.Controls.Add(this.ratingResultLabel);
            this.Search.Controls.Add(this.dateResultLabel);
            this.Search.Controls.Add(this.linkResultLabel);
            this.Search.Controls.Add(this.titleResultLabel);
            this.Search.Controls.Add(this.changeGenre);
            this.Search.Controls.Add(this.changeRating);
            this.Search.Controls.Add(this.changeDate);
            this.Search.Controls.Add(this.changeLink);
            this.Search.Controls.Add(this.changeTitle);
            this.Search.Controls.Add(this.searchTextBox);
            this.Search.Controls.Add(this.foundMovies);
            this.Search.Controls.Add(this.searchButton);
            this.Search.Location = new System.Drawing.Point(4, 22);
            this.Search.Name = "Search";
            this.Search.Padding = new System.Windows.Forms.Padding(3);
            this.Search.Size = new System.Drawing.Size(977, 437);
            this.Search.TabIndex = 0;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // removeMovieBtn
            // 
            this.removeMovieBtn.Location = new System.Drawing.Point(809, 374);
            this.removeMovieBtn.Name = "removeMovieBtn";
            this.removeMovieBtn.Size = new System.Drawing.Size(162, 52);
            this.removeMovieBtn.TabIndex = 18;
            this.removeMovieBtn.Text = "Remove";
            this.removeMovieBtn.UseVisualStyleBackColor = true;
            this.removeMovieBtn.Click += new System.EventHandler(this.removeMovieBtn_Click);
            // 
            // moviePicture
            // 
            this.moviePicture.Location = new System.Drawing.Point(14, 70);
            this.moviePicture.Name = "moviePicture";
            this.moviePicture.Size = new System.Drawing.Size(147, 201);
            this.moviePicture.TabIndex = 17;
            this.moviePicture.TabStop = false;
            this.moviePicture.Click += new System.EventHandler(this.moviePicture_Click);
            // 
            // changeTitleBtn
            // 
            this.changeTitleBtn.Location = new System.Drawing.Point(515, 305);
            this.changeTitleBtn.Name = "changeTitleBtn";
            this.changeTitleBtn.Size = new System.Drawing.Size(162, 52);
            this.changeTitleBtn.TabIndex = 16;
            this.changeTitleBtn.Text = "Change";
            this.changeTitleBtn.UseVisualStyleBackColor = true;
            this.changeTitleBtn.Click += new System.EventHandler(this.changeTitleBtn_Click);
            // 
            // openWebsiteButton
            // 
            this.openWebsiteButton.Location = new System.Drawing.Point(683, 248);
            this.openWebsiteButton.Name = "openWebsiteButton";
            this.openWebsiteButton.Size = new System.Drawing.Size(75, 23);
            this.openWebsiteButton.TabIndex = 15;
            this.openWebsiteButton.Text = "Open";
            this.openWebsiteButton.UseVisualStyleBackColor = true;
            this.openWebsiteButton.Click += new System.EventHandler(this.openWebsiteButton_Click);
            // 
            // genreResultLabel
            // 
            this.genreResultLabel.AutoSize = true;
            this.genreResultLabel.Location = new System.Drawing.Point(201, 335);
            this.genreResultLabel.Name = "genreResultLabel";
            this.genreResultLabel.Size = new System.Drawing.Size(39, 13);
            this.genreResultLabel.TabIndex = 14;
            this.genreResultLabel.Text = "Genre:";
            // 
            // ratingResultLabel
            // 
            this.ratingResultLabel.AutoSize = true;
            this.ratingResultLabel.Location = new System.Drawing.Point(199, 308);
            this.ratingResultLabel.Name = "ratingResultLabel";
            this.ratingResultLabel.Size = new System.Drawing.Size(41, 13);
            this.ratingResultLabel.TabIndex = 13;
            this.ratingResultLabel.Text = "Rating:";
            // 
            // dateResultLabel
            // 
            this.dateResultLabel.AutoSize = true;
            this.dateResultLabel.Location = new System.Drawing.Point(207, 281);
            this.dateResultLabel.Name = "dateResultLabel";
            this.dateResultLabel.Size = new System.Drawing.Size(33, 13);
            this.dateResultLabel.TabIndex = 12;
            this.dateResultLabel.Text = "Date:";
            // 
            // linkResultLabel
            // 
            this.linkResultLabel.AutoSize = true;
            this.linkResultLabel.Location = new System.Drawing.Point(210, 254);
            this.linkResultLabel.Name = "linkResultLabel";
            this.linkResultLabel.Size = new System.Drawing.Size(30, 13);
            this.linkResultLabel.TabIndex = 11;
            this.linkResultLabel.Text = "Link:";
            // 
            // titleResultLabel
            // 
            this.titleResultLabel.AutoSize = true;
            this.titleResultLabel.Location = new System.Drawing.Point(210, 227);
            this.titleResultLabel.Name = "titleResultLabel";
            this.titleResultLabel.Size = new System.Drawing.Size(30, 13);
            this.titleResultLabel.TabIndex = 10;
            this.titleResultLabel.Text = "Title:";
            // 
            // changeGenre
            // 
            this.changeGenre.Location = new System.Drawing.Point(246, 332);
            this.changeGenre.Name = "changeGenre";
            this.changeGenre.Size = new System.Drawing.Size(100, 20);
            this.changeGenre.TabIndex = 9;
            // 
            // changeRating
            // 
            this.changeRating.Location = new System.Drawing.Point(246, 305);
            this.changeRating.Name = "changeRating";
            this.changeRating.Size = new System.Drawing.Size(100, 20);
            this.changeRating.TabIndex = 8;
            // 
            // changeDate
            // 
            this.changeDate.Location = new System.Drawing.Point(246, 278);
            this.changeDate.Name = "changeDate";
            this.changeDate.Size = new System.Drawing.Size(100, 20);
            this.changeDate.TabIndex = 7;
            // 
            // changeLink
            // 
            this.changeLink.Location = new System.Drawing.Point(246, 251);
            this.changeLink.Name = "changeLink";
            this.changeLink.Size = new System.Drawing.Size(431, 20);
            this.changeLink.TabIndex = 6;
            // 
            // changeTitle
            // 
            this.changeTitle.Location = new System.Drawing.Point(246, 224);
            this.changeTitle.Name = "changeTitle";
            this.changeTitle.Size = new System.Drawing.Size(685, 20);
            this.changeTitle.TabIndex = 5;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(246, 30);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(187, 20);
            this.searchTextBox.TabIndex = 3;
            // 
            // foundMovies
            // 
            this.foundMovies.FormattingEnabled = true;
            this.foundMovies.Location = new System.Drawing.Point(246, 70);
            this.foundMovies.Name = "foundMovies";
            this.foundMovies.Size = new System.Drawing.Size(685, 147);
            this.foundMovies.TabIndex = 2;
            this.foundMovies.SelectedIndexChanged += new System.EventHandler(this.FoundMovies_SelectedIndexChanged);
            // 
            // AddTab
            // 
            this.AddTab.Controls.Add(this.addMovietoDBBtn);
            this.AddTab.Controls.Add(this.newOpenLinkBtn);
            this.AddTab.Controls.Add(this.label5);
            this.AddTab.Controls.Add(this.label4);
            this.AddTab.Controls.Add(this.label3);
            this.AddTab.Controls.Add(this.label2);
            this.AddTab.Controls.Add(this.label1);
            this.AddTab.Controls.Add(this.newMovieGenre);
            this.AddTab.Controls.Add(this.newMovieRating);
            this.AddTab.Controls.Add(this.newMovieDate);
            this.AddTab.Controls.Add(this.newMovieLink);
            this.AddTab.Controls.Add(this.newMovieTitle);
            this.AddTab.Controls.Add(this.newMoviePictureBx);
            this.AddTab.Controls.Add(this.foundLinksBox);
            this.AddTab.Controls.Add(this.addMovieBtn);
            this.AddTab.Controls.Add(this.addMovieTB);
            this.AddTab.Location = new System.Drawing.Point(4, 22);
            this.AddTab.Name = "AddTab";
            this.AddTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddTab.Size = new System.Drawing.Size(977, 437);
            this.AddTab.TabIndex = 1;
            this.AddTab.Text = "Add";
            this.AddTab.UseVisualStyleBackColor = true;
            // 
            // addMovietoDBBtn
            // 
            this.addMovietoDBBtn.Location = new System.Drawing.Point(704, 287);
            this.addMovietoDBBtn.Name = "addMovietoDBBtn";
            this.addMovietoDBBtn.Size = new System.Drawing.Size(125, 42);
            this.addMovietoDBBtn.TabIndex = 15;
            this.addMovietoDBBtn.Text = "Add Movie";
            this.addMovietoDBBtn.UseVisualStyleBackColor = true;
            this.addMovietoDBBtn.Click += new System.EventHandler(this.addMovietoDBBtn_Click);
            // 
            // newOpenLinkBtn
            // 
            this.newOpenLinkBtn.Location = new System.Drawing.Point(836, 162);
            this.newOpenLinkBtn.Name = "newOpenLinkBtn";
            this.newOpenLinkBtn.Size = new System.Drawing.Size(135, 22);
            this.newOpenLinkBtn.TabIndex = 14;
            this.newOpenLinkBtn.Text = "Open";
            this.newOpenLinkBtn.UseVisualStyleBackColor = true;
            this.newOpenLinkBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Genre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Rating:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Link:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // newMovieGenre
            // 
            this.newMovieGenre.Location = new System.Drawing.Point(229, 299);
            this.newMovieGenre.Name = "newMovieGenre";
            this.newMovieGenre.Size = new System.Drawing.Size(100, 20);
            this.newMovieGenre.TabIndex = 8;
            // 
            // newMovieRating
            // 
            this.newMovieRating.Location = new System.Drawing.Point(229, 272);
            this.newMovieRating.Name = "newMovieRating";
            this.newMovieRating.Size = new System.Drawing.Size(100, 20);
            this.newMovieRating.TabIndex = 7;
            // 
            // newMovieDate
            // 
            this.newMovieDate.Location = new System.Drawing.Point(229, 245);
            this.newMovieDate.Name = "newMovieDate";
            this.newMovieDate.Size = new System.Drawing.Size(100, 20);
            this.newMovieDate.TabIndex = 6;
            // 
            // newMovieLink
            // 
            this.newMovieLink.Location = new System.Drawing.Point(229, 219);
            this.newMovieLink.Name = "newMovieLink";
            this.newMovieLink.Size = new System.Drawing.Size(413, 20);
            this.newMovieLink.TabIndex = 5;
            // 
            // newMovieTitle
            // 
            this.newMovieTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMovieTitle.Location = new System.Drawing.Point(229, 192);
            this.newMovieTitle.Name = "newMovieTitle";
            this.newMovieTitle.Size = new System.Drawing.Size(600, 20);
            this.newMovieTitle.TabIndex = 4;
            // 
            // newMoviePictureBx
            // 
            this.newMoviePictureBx.Location = new System.Drawing.Point(16, 63);
            this.newMoviePictureBx.Name = "newMoviePictureBx";
            this.newMoviePictureBx.Size = new System.Drawing.Size(161, 199);
            this.newMoviePictureBx.TabIndex = 3;
            this.newMoviePictureBx.TabStop = false;
            // 
            // foundLinksBox
            // 
            this.foundLinksBox.FormattingEnabled = true;
            this.foundLinksBox.Location = new System.Drawing.Point(197, 64);
            this.foundLinksBox.Name = "foundLinksBox";
            this.foundLinksBox.Size = new System.Drawing.Size(632, 121);
            this.foundLinksBox.TabIndex = 2;
            this.foundLinksBox.SelectedIndexChanged += new System.EventHandler(this.foundLinksBox_SelectedIndexChanged);
            // 
            // addMovieBtn
            // 
            this.addMovieBtn.Location = new System.Drawing.Point(564, 36);
            this.addMovieBtn.Name = "addMovieBtn";
            this.addMovieBtn.Size = new System.Drawing.Size(78, 23);
            this.addMovieBtn.TabIndex = 1;
            this.addMovieBtn.Text = "Search";
            this.addMovieBtn.UseVisualStyleBackColor = true;
            this.addMovieBtn.Click += new System.EventHandler(this.addMovieBtn_Click);
            // 
            // addMovieTB
            // 
            this.addMovieTB.Location = new System.Drawing.Point(197, 38);
            this.addMovieTB.Name = "addMovieTB";
            this.addMovieTB.Size = new System.Drawing.Size(364, 20);
            this.addMovieTB.TabIndex = 0;
            this.addMovieTB.TextChanged += new System.EventHandler(this.addMovieTB_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 460);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moviePicture)).EndInit();
            this.AddTab.ResumeLayout(false);
            this.AddTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newMoviePictureBx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Search;
        private System.Windows.Forms.ListBox foundMovies;
        private System.Windows.Forms.TabPage AddTab;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox changeGenre;
        private System.Windows.Forms.TextBox changeRating;
        private System.Windows.Forms.TextBox changeDate;
        private System.Windows.Forms.TextBox changeLink;
        private System.Windows.Forms.TextBox changeTitle;
        private System.Windows.Forms.Button openWebsiteButton;
        private System.Windows.Forms.Label genreResultLabel;
        private System.Windows.Forms.Label ratingResultLabel;
        private System.Windows.Forms.Label dateResultLabel;
        private System.Windows.Forms.Label linkResultLabel;
        private System.Windows.Forms.Label titleResultLabel;
        private System.Windows.Forms.Button changeTitleBtn;
        private System.Windows.Forms.PictureBox moviePicture;
        private System.Windows.Forms.Button addMovieBtn;
        private System.Windows.Forms.TextBox addMovieTB;
        private System.Windows.Forms.ListBox foundLinksBox;
        private System.Windows.Forms.PictureBox newMoviePictureBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newMovieGenre;
        private System.Windows.Forms.TextBox newMovieRating;
        private System.Windows.Forms.TextBox newMovieDate;
        private System.Windows.Forms.TextBox newMovieLink;
        private System.Windows.Forms.TextBox newMovieTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newOpenLinkBtn;
        private System.Windows.Forms.Button addMovietoDBBtn;
        private System.Windows.Forms.Button removeMovieBtn;
    }
}

