using System;
using System.Windows.Forms;
using UserControl.FormUI.Presenters;

namespace UserControl.FormUI
{
    public partial class Dashboard : Form
    {
        public event EventHandler WinLoad;
        public event EventHandler UsersComboIndexChanged;
        public event EventHandler AddItemClick;
        public event EventHandler SaveItemClick;
        public event EventHandler RemoveItemClick;
        public event EventHandler SaveButtonClick;
        public event EventHandler CheckedListItemCheck;

        public BindingSource BindingSource { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            BindingSource = new BindingSource();
            Load += Dashboard_WinLoad;
            usersComboBox.SelectedIndexChanged += UsersComboBox_SelectedIndexChanged;
            addItem.Click += AddItem_Click;
            saveItem.Click += SaveItem_Click;
            removeItem.Click += RemoveItem_Click;
            saveButton.Click += SaveButton_Click;
            rolesCheckedListBox.ItemCheck += RolesCheckedListBox_ItemCheck;
            new DashboardPresenter(this);
        }

        private void RolesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListItemCheck(rolesCheckedListBox, e);
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            SaveItemClick(saveItem, e);
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            RemoveItemClick(removeItem, e);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButtonClick(saveButton, e);
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItemClick(addItem, e);
        }

        private void UsersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsersComboIndexChanged(usersComboBox, e);
        }

        private void Dashboard_WinLoad(object sender, EventArgs e)
        {
            WinLoad(this, e);
        }

        public ref ComboBox GetUsersComboBox()
        {
            return ref usersComboBox;
        }

        public ref TextBox GetIdTextBox()
        {
            return ref idTextBox;
        }

        public ref TextBox GetEmailTextBox()
        {
            return ref emailTextBox;
        }

        public ref TextBox GetNameTextBox()
        {
            return ref nameTextBox;
        }

        public ref DateTimePicker GetBirthdayDateTimePicker()
        {
            return ref birthdayTimePicker;
        }

        public ref CheckedListBox GetRolesCheckedListBox()
        {
            return ref rolesCheckedListBox;
        }
    }
}
