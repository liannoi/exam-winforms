using System;
using System.Windows.Forms;
using UserControl.FormUI.Presenters;

namespace UserControl.FormUI
{
    /// <summary>
    /// View of the main form.
    /// </summary>
    public partial class Dashboard : Form
    {
        #region Events

        /// <summary>
        /// The event of loading form (<see cref="Dashboard"/>).
        /// </summary>
        public event EventHandler WinLoad;

        /// <summary>
        /// The event of changing index in the ComboBox
        /// (<see cref="usersComboBox"/>).
        /// </summary>
        public event EventHandler UsersComboIndexChanged;

        /// <summary>
        /// The event of clicking the Add item (<see cref="addItem"/>) in the
        /// context menu when the right mouse button is clicked on the
        /// ComboBox (<see cref="usersComboBox"/>).
        /// </summary>
        public event EventHandler AddItemClick;

        /// <summary>
        /// The event of clicking the Save item (<see cref="saveItem"/>) in the
        /// context menu when the right mouse button is clicked on the ComboBox
        /// (<see cref="usersComboBox"/>).
        /// </summary>
        public event EventHandler SaveItemClick;

        /// <summary>
        /// The event of clicking the Remove item (<see cref="removeItem"/>) in the
        /// context menu when the right mouse button is clicked on the ComboBox
        /// (<see cref="usersComboBox"/>).
        /// </summary>
        public event EventHandler RemoveItemClick;

        /// <summary>
        /// The event of pressing the button Save.
        /// </summary>
        public event EventHandler SaveButtonClick;

        /// <summary>
        /// The event of checking item in the CheckedListBox
        /// (<see cref="rolesCheckedListBox"/>).
        /// </summary>
        public event EventHandler CheckedListItemCheck;

        #endregion

        #region Properties

        /// <summary>
        /// The class object responsible for the "instant" change of data in
        /// the collection, depending on the data in the binding element.
        /// </summary>
        public BindingSource BindingSource { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of the main form.
        /// </summary>
        public Dashboard()
        {
            // Auto-generated object initialization.
            InitializeComponent();

            // Allocation of memory for bindings.
            BindingSource = new BindingSource();

            // Signed event forms on our events.
            Load += Dashboard_WinLoad;
            usersComboBox.SelectedIndexChanged += UsersComboBox_SelectedIndexChanged;
            addItem.Click += AddItem_Click;
            saveItem.Click += SaveItem_Click;
            removeItem.Click += RemoveItem_Click;
            saveButton.Click += SaveButton_Click;
            rolesCheckedListBox.ItemCheck += RolesCheckedListBox_ItemCheck;

            // "Transfer" control to the Presenter form.
            new DashboardPresenter(this);
        }

        #endregion

        #region Event handlers

        private void RolesCheckedListBox_ItemCheck(object sender,
            ItemCheckEventArgs e)
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

        private void UsersComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            UsersComboIndexChanged(usersComboBox, e);
        }

        private void Dashboard_WinLoad(object sender, EventArgs e)
        {
            WinLoad(this, e);
        }

        #endregion

        #region References to the controls

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

        #endregion
    }
}
