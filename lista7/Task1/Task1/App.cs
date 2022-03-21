using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task1
{
    public class App : Form
    {
        EventAggregator eventAggregator;
        TreePanel treePanel;
        InfoPanel infoPanel;
        TableLayoutPanel mainPanel = new TableLayoutPanel();
        PeopleRepo peopleRepo;

        public App()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            eventAggregator = new EventAggregator();
            peopleRepo = new PeopleRepo(eventAggregator);

            CenterToScreen();
            Size = new Size(1000, 500);

            mainPanel.Size = new Size(700, 500);
            mainPanel.ColumnCount = 2;
            mainPanel.RowCount = 1;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Show();
            Controls.Add(mainPanel);
            
            treePanel = new TreePanel(eventAggregator, peopleRepo);
            treePanel.Dock = DockStyle.Fill;
            treePanel.Show();
            mainPanel.Controls.Add(treePanel);
            
            infoPanel = new InfoPanel(eventAggregator, peopleRepo);
            infoPanel.Size = new Size(700, 800);
            infoPanel.Show();
            mainPanel.Controls.Add(infoPanel);
        }
    }
}
