using CRUDDapperRepositoryPattern.Models;

namespace CRUDDapperRepositoryPattern
{
    public partial class Form1 : Form
    {
        EntityState objState = EntityState.Unchanged;

        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic.Image = Image.FromFile(ofd.FileName);
                if (studentBindingSource.Current is Student student)
                {
                    student.ImageUrl = ofd.FileName;
                }
            }
        }
        void ClearInput()
        {
            fullNameTextBox.Text = string.Empty;
            genderCheckBox.Checked = false;
            birthdayTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            pic.Image = null;
        }

        void ShowImage()
        {
            try
            {
                //Student student = studentBindingSource.Current as Student;
                //if(studnet != null)
                // => 패턴일치로 변경 (https://learn.microsoft.com/ko-kr/dotnet/csharp/fundamentals/functional/pattern-matching)

                // txtStudentID, txtFullName, chkGender, txtEmail, txtAddress의 경우 DataBindings속성의 Text가 바인딩이 되어 있으므로 입력 작업은 필요 없음
                if (studentBindingSource.Current is Student student)
                {
                    if (!string.IsNullOrEmpty(student.ImageUrl))
                        pic.Image = Image.FromFile(student.ImageUrl);
                    else
                        pic.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                StudentRepository studentRepository = new();
                studentBindingSource.DataSource = studentRepository.GetAll();
                pnlContainer.Enabled = false;

                if (studentBindingSource.Current is Student student)
                {
                    if (!string.IsNullOrEmpty(student.ImageUrl))
                        pic.Image = Image.FromFile(student.ImageUrl);
                    else
                        pic.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            pic.Image = null;
            pnlContainer.Enabled = true;
            studentBindingSource.Add(new Student());
            studentBindingSource.MoveLast();
            fullNameTextBox.Focus();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            pnlContainer.Enabled = false;
            studentBindingSource.ResetBindings(false);
            // ClearInput();
            this.Form1_Load(sender, e);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            objState = EntityState.Changed;
            pnlContainer.Enabled = true;
            fullNameTextBox.Focus();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowImage();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ShowImage();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            objState = EntityState.Deleted;
            if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (studentBindingSource.Current is Student student)
                    {
                        StudentRepository studentRepository = new();
                        if (studentRepository.Delete(student.StudentID))
                        {
                            studentBindingSource.RemoveCurrent();
                            pnlContainer.Enabled = false;
                            pic.Image = null;
                            objState = EntityState.Unchanged;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                studentBindingSource.EndEdit();
                if (studentBindingSource.Current is Student student)
                {
                    StudentRepository studentRepository = new();
                    // Insert
                    if (objState == EntityState.Added)
                    {
                        studentRepository.Insert(student);
                    }
                    // Update
                    else if (objState == EntityState.Changed)
                    {
                        studentRepository.Update(student);
                    }
                    dataGridView.Refresh();
                    pnlContainer.Enabled = false;
                    objState = EntityState.Unchanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void genderCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (genderCheckBox.CheckState == CheckState.Checked)
                genderCheckBox.Text = "Female";
            else if (genderCheckBox.CheckState == CheckState.Unchecked)
                genderCheckBox.Text = "Male";
            else
                genderCheckBox.Text = "???";
        }
    }
}