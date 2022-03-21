using System.Collections.Generic;
using System.Windows.Forms;

namespace Task1
{
    public class UserDataPanel : DataGridView, 
        ISubscriber<PersonNodeClicked>,
        ISubscriber<PersonChanged>
    {
        EventAggregator eventAggregator;
        PeopleRepo peopleRepo;
        Button modifyUserButton;
        Person currentPerson;

        public UserDataPanel(EventAggregator eventAggregator, PeopleRepo peopleRepo)
        {
            this.peopleRepo = peopleRepo;
            this.eventAggregator = eventAggregator;
            eventAggregator.AddSubscriber<PersonNodeClicked>(this);
            eventAggregator.AddSubscriber<PersonChanged>(this);
            SetUpDataGrid();
            SetupButton();
        }

        private void SetupButton()
        {
            modifyUserButton = new Button()
            {
                Text = "Modify user",
                Width = 100,
                Height = 100,
                Location = new System.Drawing.Point(600, 100)
            };

            modifyUserButton.MouseClick += OnModifyButtonClick;
            Controls.Add(modifyUserButton);
        }

        private void OnModifyButtonClick(object sender, MouseEventArgs args)
        {
            UserFormDialog dialog = new UserFormDialog(eventAggregator,
                peopleRepo, "modify", currentPerson);
            dialog.ShowDialog();
        }


        private void SetUpDataGrid()
        {
            ColumnCount = 2;
            RowCount = 5;
            ReadOnly = true;
            Rows[0].Cells[0].Value = "First Name";
            Rows[1].Cells[0].Value = "Second Name";
            Rows[2].Cells[0].Value = "Birthday Name";
            Rows[3].Cells[0].Value = "Address Name";
            Rows[4].Cells[0].Value = "Category";
            Size = new System.Drawing.Size(700, 800);
        }

        private void PopulateUserData(Person p)
        {
            currentPerson = p;
            Rows[0].Cells[1].Value = p.Firstname;
            Rows[1].Cells[1].Value = p.Surname;
            Rows[2].Cells[1].Value = p.Birthday;
            Rows[3].Cells[1].Value = p.Address;
            Rows[4].Cells[1].Value = p.Category;
        }

        void ISubscriber<PersonNodeClicked>.Handle(PersonNodeClicked Notification)
        {
            PopulateUserData(Notification.Person);
        }

        void ISubscriber<PersonChanged>.Handle(PersonChanged Notification)
        {
            PopulateUserData(Notification.Person);

        }
    }


}