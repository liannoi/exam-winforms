// Copyright 2019 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using UserControl.Models.Models;

namespace UserControl.FormUI.Presenters
{
    /// <summary>
    /// Presenter of the main form.
    /// </summary>
    public class DashboardPresenter
    {
        #region Fields

        /// <summary>
        /// The main form.
        /// </summary>
        private readonly Dashboard dashboard;

        /// <summary>
        /// Сollection of users.
        /// </summary>
        private List<User> users;

        private User currentUser;
        private readonly BinaryFormatter binaryFormatter;

        #endregion

        public DashboardPresenter(Dashboard dashboard)
        {
            this.dashboard = dashboard;

            // Deserialization to fill controls.
            binaryFormatter = new BinaryFormatter();
            Deserialize();

            dashboard.WinLoad += Dashboard_WinLoad;
            dashboard.UsersComboIndexChanged += Dashboard_UsersComboIndexChanged;
            dashboard.AddItemClick += Dashboard_AddItemClick;
            dashboard.SaveItemClick += Dashboard_SaveItemClick;
            dashboard.RemoveItemClick += Dashboard_RemoveItemClick;
            dashboard.SaveButtonClick += Dashboard_SaveButtonClick;
            dashboard.CheckedListItemCheck += Dashboard_CheckedListItemCheck;
        }

        #region Event handlers

        private void Dashboard_CheckedListItemCheck(object sender, EventArgs e)
        {
            int selectedIndex = dashboard.GetRolesCheckedListBox().SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            _ = dashboard.GetRolesCheckedListBox().GetItemCheckState(selectedIndex) == CheckState.Checked ? currentUser.Roles[selectedIndex].IsChecked = false : currentUser.Roles[selectedIndex].IsChecked = true;
            Serialize();
        }

        private void Dashboard_SaveButtonClick(object sender, EventArgs e)
        {
            Serialize();
        }

        private void Dashboard_RemoveItemClick(object sender, EventArgs e)
        {
            users.RemoveAt(dashboard.GetUsersComboBox().SelectedIndex);
            ResetBindings();
        }

        private void Dashboard_SaveItemClick(object sender, EventArgs e)
        {
            Serialize();
        }

        private void Dashboard_AddItemClick(object sender, EventArgs e)
        {
            User user = new User
            {
                Id = users.Max(result => result.Id) + 1,
                DateBirthday = DateTime.Now,
                Roles = DataManager.GetRoles()
            };
            users.Add(user);
            ResetBindings();
            dashboard.GetUsersComboBox().SelectedIndex = dashboard.GetUsersComboBox().Items.Count - 1;
        }

        private void Dashboard_UsersComboIndexChanged(object sender,
            EventArgs e)
        {
            currentUser = users.Where(result => result.Id == Convert.ToInt32(dashboard.GetUsersComboBox().SelectedValue)).FirstOrDefault();
            if (currentUser == null)
            {
                return;
            }
            dashboard.GetRolesCheckedListBox().Items.Clear();
            FillCheckedListBox();
        }

        private void Dashboard_WinLoad(object sender, EventArgs e)
        {
            FillComboBox();
            dashboard.GetUsersComboBox().SelectedIndex = 0;
            SetupBindingSource();
        }

        #endregion

        #region Auxiliary methods

        private void ResetBindings()
        {
            dashboard.BindingSource.ResetBindings(true);
        }

        private void FillCheckedListBox()
        {
            foreach (Role role in currentUser.Roles)
            {
                dashboard.GetRolesCheckedListBox().Items.Add(role.Name);
                if (!role.IsChecked)
                {
                    continue;
                }
                dashboard.GetRolesCheckedListBox().SetItemChecked(dashboard.GetRolesCheckedListBox().Items.Count - 1, true);
            }
        }

        private void SetupBindingSource()
        {
            dashboard.BindingSource.DataSource = users;
            dashboard.GetUsersComboBox().ValueMember = "Id";
            dashboard.GetUsersComboBox().DisplayMember = "ToString";
            dashboard.GetUsersComboBox().DataSource = dashboard.BindingSource;
            dashboard.GetIdTextBox().DataBindings.Add("Text", dashboard.BindingSource, "Id", false, DataSourceUpdateMode.OnPropertyChanged);
            dashboard.GetEmailTextBox().DataBindings.Add("Text", dashboard.BindingSource, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            dashboard.GetNameTextBox().DataBindings.Add("Text", dashboard.BindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            dashboard.GetBirthdayDateTimePicker().DataBindings.Add("Value", dashboard.BindingSource, "DateBirthday", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FillComboBox()
        {
            foreach (User user in users)
            {
                dashboard.GetUsersComboBox().Items.Add(user);
            }
        }

        private void Serialize()
        {
            using (FileStream fileStream = new FileStream("data.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, users);
            }
        }

        private void Deserialize()
        {
            if (!IsFileCreated())
            {
                users = DataManager.GetUsers();
                foreach (User user in users)
                {
                    user.Roles = DataManager.GetRoles();
                }
                return;
            }
            using (FileStream fileStream = new FileStream("data.dat", FileMode.Open, FileAccess.Read))
            {
                users = (List<User>)binaryFormatter.Deserialize(fileStream);
            }
        }

        private bool IsFileCreated()
        {
            try
            {
                using (FileStream fileStream = new FileStream("data.dat", FileMode.Open, FileAccess.Read))
                {
                }
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
