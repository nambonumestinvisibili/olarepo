using System.Collections.Generic;
using System.Windows.Forms;

namespace Task1
{
    public class InfoPanel : Panel, 
        ISubscriber<CategoryNodeClicked>,
        ISubscriber<PersonNodeClicked>
    {
        private EventAggregator eventAggregator;
        private UserDataPanel userDataPanel;
        private UsersListDataPanel usersListDataPanel;
        private PeopleRepo peopleRepo;

        public InfoPanel(EventAggregator eventAggregator, PeopleRepo peopleRepo) : base()
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.AddSubscriber<CategoryNodeClicked>(this);
            eventAggregator.AddSubscriber<PersonNodeClicked>(this);

            userDataPanel = new UserDataPanel(eventAggregator, peopleRepo);
            userDataPanel.Visible = false;
            Controls.Add(userDataPanel);

            usersListDataPanel = new UsersListDataPanel(eventAggregator, peopleRepo);
            usersListDataPanel.Visible = false;
            Controls.Add(usersListDataPanel);
        }        

        void ISubscriber<CategoryNodeClicked>.Handle(CategoryNodeClicked Notification)
        {
            usersListDataPanel.Visible = true;
            userDataPanel.Visible = false;
        }


        void ISubscriber<PersonNodeClicked>.Handle(PersonNodeClicked Notification)
        {
            usersListDataPanel.Visible = false;
            userDataPanel.Visible = true;
        }
    }
}