using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public class UserFormDialog : Form
    {
        DataGridView form;
        EventAggregator eventAggregator;
        Button saveButton;
        PeopleRepo peopleRepo;
        Person personToModify;
        string mode;

        public UserFormDialog(EventAggregator eventAggregator, 
            PeopleRepo peopleRepo, string mode)
        {
            Initialise(eventAggregator, peopleRepo, mode);
        }

        public UserFormDialog(EventAggregator eventAggregator,
            PeopleRepo peopleRepo, string mode, Person personToModify)
        {
            this.personToModify = personToModify;
            Initialise(eventAggregator, peopleRepo, mode);

        }

        private void Initialise(EventAggregator eventAggregator, 
            PeopleRepo peopleRepo, string mode)
        {
            this.mode = mode;
            this.eventAggregator = eventAggregator;
            this.peopleRepo = peopleRepo;


            Size = new System.Drawing.Size(400, 600);
            form = new DataGridView();
            SetupDataGridView();

            saveButton = new Button { Text = "Save", 
                Location = new System.Drawing.Point(150, 300), 
                Width = 100, Height = 100 };

            saveButton.MouseClick += onSaveButtonClicked;
            Controls.Add(saveButton);
        }



        private void onSaveButtonClicked(object Sender, MouseEventArgs args)
        {
            if (ValidateData())
            {
                new ValidationDialog();
                return;
            }

            Category who = Category.Student;

                if ((string)form.Rows[4].Cells[1].Value == "Teacher")
                {
                    who = Category.Teacher;
                }
                else if ((string)form.Rows[4].Cells[1].Value == "Student")
                {
                    who = Category.Student;
                }
             
            
            Person person = new Person
            {
                Firstname = (string)form.Rows[0].Cells[1].Value,
                Surname = (string)form.Rows[1].Cells[1].Value,
                Birthday = (string)form.Rows[2].Cells[1].Value,
                Address = (string)form.Rows[3].Cells[1].Value,
                Category = who
            };


            if (mode == "add")
            {
                eventAggregator.Publish(new AddNewPersonEvent { Person = person});
            }
            else if (mode == "modify")
            {
                eventAggregator.Publish(new ChangePersonEvent {
                    OldPerson = personToModify,
                    Person = person});
            }

            Close();

        }
    

        private void SetupDataGridView()
        {
            form.ColumnCount = 2;
            form.RowCount = 5;
            form.Rows[0].Cells[0].Value = "First Name";
            form.Rows[1].Cells[0].Value = "Second Name";
            form.Rows[2].Cells[0].Value = "Birthday";
            form.Rows[3].Cells[0].Value = "Address";
            form.Rows[4].Cells[0].Value = "Teacher or Student?";
            form.Size = new System.Drawing.Size(400, 300);
            Controls.Add(form);

            if (mode == "modify")
            {
                form.Rows[0].Cells[1].Value = personToModify.Firstname;
                form.Rows[1].Cells[1].Value = personToModify.Surname;
                form.Rows[2].Cells[1].Value = personToModify.Birthday;
                form.Rows[3].Cells[1].Value = personToModify.Address;
                form.Rows[4].Cells[1].Value = personToModify.Category.ToString();
            }
        }

        private bool ValidateData()
        {
            return (!(
                    form.Rows[0].Cells[1].Value != null &&
                    form.Rows[1].Cells[1].Value != null &&
                    form.Rows[2].Cells[1].Value != null &&
                    form.Rows[3].Cells[1].Value != null &&
                    form.Rows[4].Cells[1].Value != null &&
                    IsNotEmpty(form.Rows[0].Cells[1].Value.ToString()) &&
                    IsNotEmpty(form.Rows[1].Cells[1].Value.ToString()) &&
                    IsNotEmpty(form.Rows[2].Cells[1].Value.ToString()) &&
                    IsNotEmpty(form.Rows[3].Cells[1].Value.ToString()) &&
                    IsNotEmpty(form.Rows[4].Cells[1].Value.ToString()) &&
                    (form.Rows[4].Cells[1].Value.ToString() == "Student" 
                    || form.Rows[4].Cells[1].Value.ToString() == "Teacher")
                ));
        }

        private bool IsNotEmpty(string word)
        {
            if (word == null) return false;
            return word != "";
        }

        private class ValidationDialog : Form
        {
            Label label = new Label();
            public ValidationDialog()
            {
                label.Text = "All Fields Must be Filled, Category must be either Student Or Teacher";
                label.Width = 600;
                Controls.Add(label);
                ShowDialog();
            }
        }
    }

    
}
