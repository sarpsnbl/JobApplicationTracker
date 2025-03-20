using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JobTrackerApp
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=(localdb)\\ProjectModels;Database=JobTrackerDB;Integrated Security=True;";

        public List<JobApplication> GetAllJobApplications()
        {
            List<JobApplication> jobApplications = new List<JobApplication>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve Job Applications including ReminderDate
                string jobQuery = "SELECT * FROM JobApplications";
                using (SqlCommand jobCommand = new SqlCommand(jobQuery, connection))
                using (SqlDataReader jobReader = jobCommand.ExecuteReader())
                {
                    while (jobReader.Read())
                    {
                        var jobApp = new JobApplication
                        {
                            ID = Convert.ToInt32(jobReader["ID"]),
                            CompanyName = jobReader["CompanyName"].ToString(),
                            CompanyEmail = jobReader["CompanyEmail"].ToString(),
                            Position = jobReader["Position"].ToString(),
                            Status = jobReader["Status"].ToString(),
                            DateApplied = Convert.ToDateTime(jobReader["DateApplied"]),
                            Location = jobReader["Location"].ToString(),
                            JobType = jobReader["JobType"].ToString(),
                            Notes = jobReader["Notes"].ToString(),
                            Website = jobReader["Website"].ToString(),
                            ReminderDate = jobReader["ReminderDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(jobReader["ReminderDate"])
                        };

                        jobApplications.Add(jobApp);
                    }
                }
            }

            return jobApplications;
        }


        public void AddJobApplication(JobApplication jobApp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert Job Application
                        string jobQuery = @"
                    INSERT INTO JobApplications 
                    (CompanyName, CompanyEmail, Position, Status, DateApplied, Location, JobType, Notes, Website, ReminderDate) 
                    VALUES 
                    (@CompanyName, @CompanyEmail, @Position, @Status, @DateApplied, @Location, @JobType, @Notes, @Website, @ReminderDate);
                    SELECT SCOPE_IDENTITY();";

                        int jobId;
                        using (SqlCommand jobCommand = new SqlCommand(jobQuery, connection, transaction))
                        {
                            jobCommand.Parameters.AddWithValue("@CompanyName", jobApp.CompanyName);
                            jobCommand.Parameters.AddWithValue("@CompanyEmail", jobApp.CompanyEmail ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@Position", jobApp.Position);
                            jobCommand.Parameters.AddWithValue("@Status", jobApp.Status);
                            jobCommand.Parameters.AddWithValue("@DateApplied", jobApp.DateApplied);
                            jobCommand.Parameters.AddWithValue("@Location", jobApp.Location ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@JobType", jobApp.JobType);
                            jobCommand.Parameters.AddWithValue("@Notes", jobApp.Notes ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@Website", jobApp.Website ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@ReminderDate", jobApp.ReminderDate ?? (object)DBNull.Value);

                            jobId = Convert.ToInt32(jobCommand.ExecuteScalar());
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }



        public void UpdateJobApplication(JobApplication jobApp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Update Job Application including ReminderDate
                        string jobQuery = @"
                    UPDATE JobApplications SET 
                    CompanyName = @CompanyName, 
                    CompanyEmail = @CompanyEmail, 
                    Position = @Position, 
                    Status = @Status, 
                    DateApplied = @DateApplied, 
                    Location = @Location, 
                    JobType = @JobType, 
                    Notes = @Notes,
                    Website = @Website,
                    ReminderDate = @ReminderDate
                    WHERE ID = @ID";

                        using (SqlCommand jobCommand = new SqlCommand(jobQuery, connection, transaction))
                        {
                            jobCommand.Parameters.AddWithValue("@ID", jobApp.ID);
                            jobCommand.Parameters.AddWithValue("@CompanyName", jobApp.CompanyName);
                            jobCommand.Parameters.AddWithValue("@CompanyEmail", jobApp.CompanyEmail ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@Position", jobApp.Position);
                            jobCommand.Parameters.AddWithValue("@Status", jobApp.Status);
                            jobCommand.Parameters.AddWithValue("@DateApplied", jobApp.DateApplied);
                            jobCommand.Parameters.AddWithValue("@Location", jobApp.Location ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@JobType", jobApp.JobType);
                            jobCommand.Parameters.AddWithValue("@Notes", jobApp.Notes ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@Website", jobApp.Website ?? (object)DBNull.Value);
                            jobCommand.Parameters.AddWithValue("@ReminderDate", jobApp.ReminderDate == DateTime.MinValue ? (object)DBNull.Value : jobApp.ReminderDate);

                            jobCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public void DeleteJobApplication(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Delete Job Application
                        string jobDeleteQuery = "DELETE FROM JobApplications WHERE ID = @ID";
                        using (SqlCommand jobCommand = new SqlCommand(jobDeleteQuery, connection, transaction))
                        {
                            jobCommand.Parameters.AddWithValue("@ID", id);
                            jobCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
