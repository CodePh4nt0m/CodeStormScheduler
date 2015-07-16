using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CodeStormData.Data;
using Microsoft.AspNet.SignalR;

namespace CodeStormScheduler
{
    public class MessagesRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CodeStormConnection"].ConnectionString;

        public void RegisterNotification()
        {
            //We have selected the entire table as the command, so SQL Server executes this script and sees if there is a change in the result, raise the event
            string commandText = @"
                                    Select
                                        dbo.UserMessages.MessageId,
                                        dbo.UserMessages.Message,
                                        dbo.UserMessages.ReceiverId,
                                        dbo.UserMessages.SenderId,
                                        dbo.UserMessages.Status,
                                        dbo.UserMessages.CDate                                     
                                    From
                                        dbo.UserMessages                                     
                                    ";

            SqlDependency.Start(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();
                    var sqlDependency = new SqlDependency(command);


                    sqlDependency.OnChange += new OnChangeEventHandler(sqlDependency_OnChange);

                    // NOTE: You have to execute the command, or the notification will never fire.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }

        private void sqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {

            if (e.Info == SqlNotificationInfo.Insert)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
                MessageData messageData = new MessageData();
                var msg = messageData.GetLatestMessage();
                context.Clients.Group(msg.ReceiverId).refreshNotification(msg.Message);
            }
            //Call the RegisterNotification method again
            RegisterNotification();
        }
    }
}