using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    { 
        BindingList<UserModel> usersS = new BindingList<UserModel>();
        BindingList<UserModel> usersA = new BindingList<UserModel>();
        string csvStandardPath = @"StandardDataSet.csv";
        string csvAdvancedPath = @"AdvancedDataSet.csv";
        public ChallengeForm()
        {
            InitializeComponent();
            var csvStandard = File.ReadAllLines(csvStandardPath).ToList();
            var csvAdvanced = File.ReadAllLines(csvAdvancedPath).ToList();
            usersS = Standard(csvStandard);
            usersA= Advanced(csvAdvanced);
            WireUpDropDown();

        }
        private BindingList<UserModel> Standard(List<string> ls)
        { 
            var bL = new BindingList<UserModel>();
            for (int i = 1; i < ls.Count; i++)
            {
                var model = new UserModel();
                var data = ls[i].Split(',').ToList();
                model.FirstName = data[0];
                model.LastName = data[1];
                model.Age = Convert.ToInt32(data[3]);
                model.IsAlive = data[3].Trim()=="0" ?true : false;
                bL.Add(model);
            }
            return bL;
        }
        private BindingList<UserModel> Advanced(List<string> ls)
        {
            var bL = new BindingList<UserModel>();
            for (int i = 1; i < ls.Count; i++)
            {
                var model = new UserModel();
                var data = ls[i].Split(',').ToList();
                model.FirstName = data[3];
                model.LastName = data[1];
                model.Age = Convert.ToInt32(data[0]);
                model.IsAlive = data[2].Trim() == "0" ? true : false;
                bL.Add(model);
            }
            return bL;
        }

        private void WireUpDropDown()
        {
            if (radioButton1.Checked)
            {
                usersListBox.DataSource = usersS;
            }
            else
            {
                usersListBox.DataSource = usersA;
            }
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            UserModel model = ModelCreator();
            if (radioButton1.Checked)
            {
                usersS.Add(model); 
            }
            else
            {
                usersA.Add(model); 
            }
            WireUpDropDown();
        }

        private UserModel ModelCreator()
        {
            var model = new UserModel();
            if (firstNameText.Text != null &&
                lastNameLabel.Text != null &&
                agePicker.Value >= 0)
            {
                model.FirstName = firstNameText.Text;
                model.LastName = lastNameText.Text;
                model.Age = Convert.ToInt32(agePicker.Value);
                model.IsAlive = isAliveCheckbox.Checked;
            }

            return model;
        }

        private void saveListButton_Click(object sender, EventArgs e)
        { 
            if(radioButton1.Checked)
            {
                var text = firstNameText.Text +","+lastNameText.Text +","+agePicker.Value +","+(isAliveCheckbox.Checked?0:1);
                var csvStandard = File.ReadAllLines(csvStandardPath).ToList(); 
                csvStandard.Add(text);
                File.AppendAllLines(csvStandardPath, csvStandard);
                usersS = Standard(csvStandard); 
            }
            else
            { 
                var txt = agePicker.Value + ","+lastNameText.Text +","+ (isAliveCheckbox.Checked ? 0 : 1) + ","+firstNameText.Text;
                var csvAdvanced = File.ReadAllLines(csvAdvancedPath).ToList(); 
                csvAdvanced.Add(txt);
                File.AppendAllLines(csvStandardPath, csvAdvanced);
                usersA = Advanced(csvAdvanced); 
            }
            WireUpDropDown();
        }
    }
}
