using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public class UsersListDataPanel : DataGridView, ISubscriber<CategoryNodeClicked>, ISubscriber<PersonAdded>
    {
        private EventAggregator eventAggregator;
        private Button openModalWindowButton;
        private PeopleRepo peopleRepo;
        public UsersListDataPanel(EventAggregator eventAggregator, PeopleRepo peopleRepo) : base()
        {
            this.eventAggregator = eventAggregator;
            this.peopleRepo = peopleRepo;
            eventAggregator.AddSubscriber<CategoryNodeClicked>(this);
            eventAggregator.AddSubscriber<PersonAdded>(this);
            SetupDataGrid();
            SetupButton();
            
        }

        private void SetupButton()
        {
            openModalWindowButton = new Button()
            {
                Text = "Add User",
                Width = 100,
                Height = 100,
                Location = new System.Drawing.Point(600, 100)
            };

            openModalWindowButton.MouseClick += onAddButtonClick;
            Controls.Add(openModalWindowButton);
        }

        private void onAddButtonClick(object sender, MouseEventArgs args)
        {
            UserFormDialog dialog = new UserFormDialog(eventAggregator, peopleRepo, "add");
            dialog.ShowDialog();
        }

        private void SetupDataGrid()
        {
            ColumnCount = 4;
            Columns[0].Name = "Firstname";
            Columns[1].Name = "Surname";
            Columns[2].Name = "Birthday";
            Columns[3].Name = "Address";
            ReadOnly = true;
            Size = new System.Drawing.Size(700, 800);
        }

        public void PopulateDataGrid(List<Person> persons)
        {
           
            persons.ForEach(x => Rows.Add(x.ToArray()));
        }

        void ISubscriber<CategoryNodeClicked>.Handle(CategoryNodeClicked Notification)
        {
            Rows.Clear();
            if (Notification.Category == Category.Student)
                PopulateDataGrid(peopleRepo.GetStudents());
            else if (Notification.Category == Category.Teacher)
                PopulateDataGrid(peopleRepo.GetTeachers());
        }

        void ISubscriber<PersonAdded>.Handle(PersonAdded Notification)
        {
            Rows.Clear();
            if (Notification.Person.Category == Category.Student)
                PopulateDataGrid(peopleRepo.GetStudents());
            else if (Notification.Person.Category == Category.Teacher)
                PopulateDataGrid(peopleRepo.GetTeachers());
        }
    }
}
