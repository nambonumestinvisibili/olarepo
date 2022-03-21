using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace Task1
{
    public class TreePanel : Panel, 
        ISubscriber<PersonAdded>, 
        ISubscriber<PersonChanged>
    {
        private TreeView _treeView = new TreeView();
        private List<Person> _persons;
        private EventAggregator _eventAggregator;
        private PeopleRepo peopleRepo;
        public TreePanel(EventAggregator eventAggregator, PeopleRepo peopleRepo)
            : base()
        {
            this.peopleRepo = peopleRepo;
            _persons = peopleRepo.GetPeople();

            _eventAggregator = eventAggregator;
            _eventAggregator.AddSubscriber<PersonAdded>(this);
            _eventAggregator.AddSubscriber<PersonChanged>(this);
            
            SetupTreeView();            
            
        }

        private void CategoryNodeOnClick(object sender, 
            TreeNodeMouseClickEventArgs args)
        {
            CategoryNodeClicked categoryNodeClicked;
            if (args.Node.Text == "Students")
            {
                categoryNodeClicked = new CategoryNodeClicked {
                    Category = Category.Student };
                _eventAggregator.Publish(categoryNodeClicked);

            }
            else if (args.Node.Text == "Teachers")
            {
                categoryNodeClicked = new CategoryNodeClicked { 
                    Category = Category.Teacher};
                _eventAggregator.Publish(categoryNodeClicked);
            }
            else
            {
                Person p = peopleRepo.Find(args.Node.Text);
                PersonNodeClicked personNodeClicked = new PersonNodeClicked { Person = p };
                _eventAggregator.Publish(personNodeClicked);
            }

        }

        private void SetupTreeView()
        {
            PopulateTreeView();
            _treeView.Show();
            _treeView.Size = new System.Drawing.Size(200, 800);
            Controls.Add(_treeView);
        }

        private void PopulateTreeView()
        {
            _treeView.BeginUpdate();
            _treeView.Nodes.Clear();
            _treeView.Nodes.Add(new TreeNode("Students"));
            _treeView.Nodes.Add(new TreeNode("Teachers"));
            _treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(CategoryNodeOnClick);

            _persons.Where(x => x.Category == Category.Student).ToList()
                .ForEach(y => _treeView.Nodes[0].Nodes.Add(new TreeNode(y.Firstname + " " + y.Surname)));

            _persons.Where(x => x.Category == Category.Teacher).ToList()
                .ForEach(y => _treeView.Nodes[1].Nodes.Add(new TreeNode(y.Firstname + " " + y.Surname)));
            _treeView.EndUpdate();
        }

        void ISubscriber<PersonChanged>.Handle(PersonChanged Notification)
        {
            PopulateTreeView();
        }

        void ISubscriber<PersonAdded>.Handle(PersonAdded Notification)
        {
            PopulateTreeView();
        }
    }
}
