using JobTrackerApp;

public partial class MainForm : Form
{
    private DatabaseHelper dbHelper;

    public MainForm()
    {
        InitializeComponent();
        dbHelper = new DatabaseHelper();
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dataGridViewJobApplications.DataSource = dbHelper.GetAllJobApplications();
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        using (AddEditForm addForm = new AddEditForm())
        {
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                dbHelper.AddJobApplication(addForm.CurrentJobApplication);
                RefreshDataGrid();
            }
        }
    }

    private void buttonEdit_Click(object sender, EventArgs e)
    {
        if (dataGridViewJobApplications.SelectedRows.Count > 0)
        {
            JobApplication selectedJob = (JobApplication)dataGridViewJobApplications.SelectedRows[0].DataBoundItem;

            using (AddEditForm editForm = new AddEditForm(selectedJob))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.UpdateJobApplication(editForm.CurrentJobApplication);
                    RefreshDataGrid();
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a job application to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
        if (dataGridViewJobApplications.SelectedRows.Count > 0)
        {
            if (MessageBox.Show("Are you sure you want to delete this job application?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                JobApplication selectedJob = (JobApplication)dataGridViewJobApplications.SelectedRows[0].DataBoundItem;
                dbHelper.DeleteJobApplication(selectedJob.ID);
                RefreshDataGrid();
            }
        }
        else
        {
            MessageBox.Show("Please select a job application to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void buttonCheckReminder_Click(object sender, EventArgs e)
    {
        // Get all job applications
        var allJobApplications = dbHelper.GetAllJobApplications();

        // Get today's date
        DateTime today = DateTime.Today;

        // Check if any application has the ReminderDate set to today
        foreach (var jobApp in allJobApplications)
        {
            if (jobApp.ReminderDate.HasValue && jobApp.ReminderDate.Value.Date == today)
            {
                MessageBox.Show($"Reminder: You have a job application with a reminder for today: {jobApp.CompanyName} ({jobApp.Position})",
                    "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                break; // Exit after showing the first reminder message
            }
        }
    }

    private void InitializeComponent()
    {
        dataGridViewJobApplications = new DataGridView();
        buttonAdd = new Button();
        buttonEdit = new Button();
        buttonDelete = new Button();
        buttonCheckReminder = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewJobApplications).BeginInit();
        SuspendLayout();
        // 
        // dataGridViewJobApplications
        // 
        dataGridViewJobApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewJobApplications.Location = new Point(12, 12);
        dataGridViewJobApplications.Name = "dataGridViewJobApplications";
        dataGridViewJobApplications.RowHeadersWidth = 62;
        dataGridViewJobApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewJobApplications.Size = new Size(1187, 300);
        dataGridViewJobApplications.TabIndex = 0;
        dataGridViewJobApplications.CellContentClick += dataGridViewJobApplications_CellContentClick;
        // 
        // buttonAdd
        // 
        buttonAdd.Location = new Point(12, 318);
        buttonAdd.Name = "buttonAdd";
        buttonAdd.Size = new Size(75, 33);
        buttonAdd.TabIndex = 1;
        buttonAdd.Text = "Add";
        buttonAdd.UseVisualStyleBackColor = true;
        buttonAdd.Click += buttonAdd_Click;
        // 
        // buttonEdit
        // 
        buttonEdit.Location = new Point(93, 318);
        buttonEdit.Name = "buttonEdit";
        buttonEdit.Size = new Size(75, 33);
        buttonEdit.TabIndex = 2;
        buttonEdit.Text = "Edit";
        buttonEdit.UseVisualStyleBackColor = true;
        buttonEdit.Click += buttonEdit_Click;
        // 
        // buttonDelete
        // 
        buttonDelete.Location = new Point(174, 318);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 33);
        buttonDelete.TabIndex = 3;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += buttonDelete_Click;
        // 
        // buttonCheckReminder
        // 
        buttonCheckReminder.Location = new Point(255, 318);
        buttonCheckReminder.Name = "buttonCheckReminder";
        buttonCheckReminder.Size = new Size(190, 33);
        buttonCheckReminder.TabIndex = 4;
        buttonCheckReminder.Text = "Check Reminders";
        buttonCheckReminder.UseVisualStyleBackColor = true;
        buttonCheckReminder.Click += buttonCheckReminder_Click;
        // 
        // MainForm
        // 
        ClientSize = new Size(1211, 384);
        Controls.Add(buttonCheckReminder);
        Controls.Add(buttonDelete);
        Controls.Add(buttonEdit);
        Controls.Add(buttonAdd);
        Controls.Add(dataGridViewJobApplications);
        Name = "MainForm";
        Text = "Job Application Tracker";
        ((System.ComponentModel.ISupportInitialize)dataGridViewJobApplications).EndInit();
        ResumeLayout(false);
    }

    private DataGridView dataGridViewJobApplications;
    private Button buttonAdd;
    private Button buttonEdit;
    private Button buttonDelete;
    private Button buttonCheckReminder;

    private void dataGridViewJobApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
