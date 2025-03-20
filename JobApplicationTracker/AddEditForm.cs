using System;
using System.Windows.Forms;

namespace JobTrackerApp
{
    public partial class AddEditForm : Form
    {
        public JobApplication CurrentJobApplication { get; private set; }

        public AddEditForm()
        {
            InitializeComponent();
            CurrentJobApplication = new JobApplication();
            Text = "Add Job Application";
        }

        public AddEditForm(JobApplication jobApp)
        {
            InitializeComponent();
            CurrentJobApplication = jobApp;
            Text = "Edit Job Application";
            PopulateForm();
        }

        private void PopulateForm()
        {
            textBoxCompanyName.Text = CurrentJobApplication.CompanyName;
            textBoxCompanyEmail.Text = CurrentJobApplication.CompanyEmail;
            textBoxPosition.Text = CurrentJobApplication.Position;
            comboBoxStatus.Text = CurrentJobApplication.Status;
            dateTimePickerDateApplied.Value = CurrentJobApplication.DateApplied;
            textBoxLocation.Text = CurrentJobApplication.Location;
            comboBoxJobType.Text = CurrentJobApplication.JobType;
            textBoxNotes.Text = CurrentJobApplication.Notes;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CurrentJobApplication.CompanyName = textBoxCompanyName.Text;
                CurrentJobApplication.CompanyEmail = textBoxCompanyEmail.Text;
                CurrentJobApplication.Position = textBoxPosition.Text;
                CurrentJobApplication.Status = comboBoxStatus.Text;
                CurrentJobApplication.DateApplied = dateTimePickerDateApplied.Value; // This should remain as DateApplied
                CurrentJobApplication.Location = textBoxLocation.Text;
                CurrentJobApplication.JobType = comboBoxJobType.Text;
                CurrentJobApplication.Notes = textBoxNotes.Text;
                CurrentJobApplication.ReminderDate = dateTimePickerReminderDate.Value; // Corrected assignment here
                CurrentJobApplication.Website = textBoxWebsite.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxCompanyName.Text))
            {
                MessageBox.Show("Company Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPosition.Text))
            {
                MessageBox.Show("Position is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitializeComponent()
        {
            // Create controls
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxCompanyEmail = new System.Windows.Forms.TextBox();
            this.labelCompanyEmail = new System.Windows.Forms.Label();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.dateTimePickerDateApplied = new System.Windows.Forms.DateTimePicker();
            this.labelDateApplied = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.comboBoxJobType = new System.Windows.Forms.ComboBox();
            this.labelJobType = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();

            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(120, 20);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(250, 23);
            this.textBoxCompanyName.TabIndex = 0;

            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Location = new System.Drawing.Point(10, 20);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(100, 23);
            this.labelCompanyName.Text = "Company Name:";

            // 
            // textBoxCompanyEmail
            // 
            this.textBoxCompanyEmail.Location = new System.Drawing.Point(120, 50);
            this.textBoxCompanyEmail.Name = "textBoxCompanyEmail";
            this.textBoxCompanyEmail.Size = new System.Drawing.Size(250, 23);
            this.textBoxCompanyEmail.TabIndex = 1;

            // 
            // labelCompanyEmail
            // 
            this.labelCompanyEmail.Location = new System.Drawing.Point(10, 50);
            this.labelCompanyEmail.Name = "labelCompanyEmail";
            this.labelCompanyEmail.Size = new System.Drawing.Size(100, 23);
            this.labelCompanyEmail.Text = "Company Email:";

            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Location = new System.Drawing.Point(120, 80);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(250, 23);
            this.textBoxPosition.TabIndex = 2;

            // 
            // labelPosition
            // 
            this.labelPosition.Location = new System.Drawing.Point(10, 80);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(100, 23);
            this.labelPosition.Text = "Position:";

            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Location = new System.Drawing.Point(120, 110);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(250, 23);
            this.comboBoxStatus.TabIndex = 3;
            this.comboBoxStatus.Items.AddRange(new string[]
            {
                "Applied",
                "Interview Scheduled",
                "Interview Completed",
                "Offer Received",
                "Rejected",
                "Accepted",
                "Declined"
            });

            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(10, 110);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(100, 23);
            this.labelStatus.Text = "Status:";

            // 
            // dateTimePickerDateApplied
            // 
            this.dateTimePickerDateApplied.Location = new System.Drawing.Point(120, 140);
            this.dateTimePickerDateApplied.Name = "dateTimePickerDateApplied";
            this.dateTimePickerDateApplied.Size = new System.Drawing.Size(250, 23);
            this.dateTimePickerDateApplied.TabIndex = 4;

            // 
            // labelDateApplied
            // 
            this.labelDateApplied.Location = new System.Drawing.Point(10, 140);
            this.labelDateApplied.Name = "labelDateApplied";
            this.labelDateApplied.Size = new System.Drawing.Size(100, 23);
            this.labelDateApplied.Text = "Date Applied:";

            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(120, 170);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(250, 23);
            this.textBoxLocation.TabIndex = 5;

            // 
            // labelLocation
            // 
            this.labelLocation.Location = new System.Drawing.Point(10, 170);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(100, 23);
            this.labelLocation.Text = "Location:";

            // 
            // comboBoxJobType
            // 
            this.comboBoxJobType.Location = new System.Drawing.Point(120, 200);
            this.comboBoxJobType.Name = "comboBoxJobType";
            this.comboBoxJobType.Size = new System.Drawing.Size(250, 23);
            this.comboBoxJobType.TabIndex = 6;
            this.comboBoxJobType.Items.AddRange(new string[]
            {
                "Remote",
                "Hybrid",
                "On-site"
            });

            // 
            // labelJobType
            // 
            this.labelJobType.Location = new System.Drawing.Point(10, 200);
            this.labelJobType.Name = "labelJobType";
            this.labelJobType.Size = new System.Drawing.Size(100, 23);
            this.labelJobType.Text = "Job Type:";

            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(120, 230);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.ScrollBars = ScrollBars.Vertical;
            this.textBoxNotes.Size = new System.Drawing.Size(250, 50);
            this.textBoxNotes.TabIndex = 7;

            // 
            // labelNotes
            // 
            this.labelNotes.Location = new System.Drawing.Point(10, 230);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(100, 23);
            this.labelNotes.Text = "Notes:";

            //
            // labelWebsite
            //

            //
            // labelReminderDate
            //

            // Missing Labels
            this.labelWebsite = new System.Windows.Forms.Label();
            this.labelReminderDate = new System.Windows.Forms.Label();
            this.textBoxWebsite = new System.Windows.Forms.TextBox();  // TextBox for Website
            this.dateTimePickerReminderDate = new System.Windows.Forms.DateTimePicker();  // DateTimePicker for Reminder Date

            // Initialize Website Label
            this.labelWebsite.Location = new System.Drawing.Point(10, 290);
            this.labelWebsite.Name = "labelWebsite";
            this.labelWebsite.Size = new System.Drawing.Size(100, 23);
            this.labelWebsite.Text = "Website:";

            // Initialize Website TextBox
            this.textBoxWebsite.Location = new System.Drawing.Point(120, 290);
            this.textBoxWebsite.Name = "textBoxWebsite";
            this.textBoxWebsite.Size = new System.Drawing.Size(250, 23);

            // Initialize Reminder Date Label
            this.labelReminderDate.Location = new System.Drawing.Point(10, 320);
            this.labelReminderDate.Name = "labelReminderDate";
            this.labelReminderDate.Size = new System.Drawing.Size(100, 23);
            this.labelReminderDate.Text = "Reminder Date:";

            // Initialize Reminder Date DateTimePicker
            this.dateTimePickerReminderDate.Location = new System.Drawing.Point(120, 320);
            this.dateTimePickerReminderDate.Name = "dateTimePickerReminderDate";
            this.dateTimePickerReminderDate.Size = new System.Drawing.Size(250, 23);

            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(120, 360);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(230, 360);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler((sender, e) => DialogResult = DialogResult.Cancel);

            // 
            // AddEditForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 400);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.comboBoxJobType);
            this.Controls.Add(this.labelJobType);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.dateTimePickerDateApplied);
            this.Controls.Add(this.labelDateApplied);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.textBoxCompanyEmail);
            this.Controls.Add(this.labelCompanyEmail);
            this.Controls.Add(this.textBoxCompanyName);
            this.Controls.Add(this.labelCompanyName);
            // Add missing labels
            this.Controls.Add(this.labelWebsite);
            this.Controls.Add(this.labelReminderDate);
            // Add Website and Reminder Date controls to the form
            this.Controls.Add(this.textBoxWebsite);

            this.Controls.Add(this.dateTimePickerReminderDate);


            this.Name = "AddEditForm";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
        }

        // Declare controls
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxCompanyEmail;
        private System.Windows.Forms.Label labelCompanyEmail;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateApplied;
        private System.Windows.Forms.Label labelDateApplied;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.ComboBox comboBoxJobType;
        private System.Windows.Forms.Label labelJobType;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelWebsite;
        private System.Windows.Forms.Label labelReminderDate;
        private System.Windows.Forms.TextBox textBoxWebsite;
        private System.Windows.Forms.DateTimePicker dateTimePickerReminderDate;

    }
}