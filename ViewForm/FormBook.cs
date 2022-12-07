using System;
using System.Windows.Forms;
using System.Collections.Generic;
using LibraryBusinessLogic.BusinessLogics;
using Database.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.ViewModels;
using Unity;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

namespace ViewForm
{
    public partial class FormBook : Form
    {
        public int Id { set { id = value; }
        }
        private readonly IBookLogic _logic;
        private readonly IAuthorLogic _logicA;
        private string image = null;
        private int? id;

        public FormBook(IBookLogic logic, IAuthorLogic logicS)
        {
            InitializeComponent();
            _logic = logic;
            _logicA = logicS;
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            List<AuthorViewModel> viewA = _logicA.Read(null);
            foreach (var author in viewA)
            {
                listBoxModified1.AddItem(author.AuthorName);
            }
            romanovaTextBox1.template = @"^\d{2}\s\w{3,9}\s\d{4}$";
            if (id.HasValue)
            {
                try
                {
                    BookViewModel view = _logic.Read(new BookBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxTitle.Text = view.BookName;
                        listBoxModified1.ValueList = view.Author;
                        romanovaTextBox1.text = view.DateOut.ToString("dd MMMM yyyy");
                        pictureBox.Image = StringToImage(view.Image);
                        image = view.Image;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new BookBindingModel
                {
                    Id = id,
                    BookName = textBoxTitle.Text,
                    Image = image,
                    Author = listBoxModified1.ValueList,
                    DateOut = DateTime.ParseExact(romanovaTextBox1.text, "dd MMMM yyyy", new CultureInfo("ru-RU"))
                }) ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancell_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Title = "Выберите изображение";
            dialog.Filter = "jpg files (*.jpg)|*.jpg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var image_new = new Bitmap(dialog.FileName);
                pictureBox.Image = image_new;
                image = ImageToString(image_new);
            }

            dialog.Dispose();
        }
        private Image StringToImage(string bytes)
        {
            byte[] arrayimg = Convert.FromBase64String(bytes);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }
        private string ImageToString(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}
