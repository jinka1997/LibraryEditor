using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CommonLibrary.CallWebApis;
using CommonLibrary.Web;

namespace LibraryCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var isbn = textBox1.Text;

            var api = new GoogleBooksApi();
            var boolInfo = api.ExecuteByIsbn(isbn);
            
            if (boolInfo.ItemCount == 0) { MessageBox.Show("データなし"); return; }

            foreach (var item in boolInfo.BookItems)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add("タイトル", item.Title);
                dataGridView1.Rows.Add("サブタイトル", item.Subtitle);
                dataGridView1.Rows.Add("ISBN_13", item.Isbn13);
                dataGridView1.Rows.Add("ISBN_10", item.Isbn10);
                dataGridView1.Rows.Add("著者", item.Authors);
                dataGridView1.Rows.Add("発行日", item.PublishedDate);
                dataGridView1.Rows.Add("説明", item.Description);
                dataGridView1.Rows.Add("ページ数", item.PageCount);
                dataGridView1.Rows.Add("言語", item.Language);
                dataGridView1.Rows.Add("リンク", item.InfoLink);
                dataGridView1.Rows.Add("印刷種類", item.PrintType);
                dataGridView1.Rows.Add("カテゴリ", item.Categories);
            }      
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }
    }
}
