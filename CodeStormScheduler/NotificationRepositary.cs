using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CodeStormData.Data;
using Microsoft.AspNet.SignalR;

namespace CodeStormScheduler
{
    public class NotificationRepositary
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CodeStormConnection"].ConnectionString;

        public void RegisterNotification()
        {
            //We have selected the entire table as the command, so SQL Server executes this script and sees if there is a change in the result, raise the event
            string commandText = @"
                                    Select
                                        dbo.SharedEvents.ShraredEventId,
                                        dbo.SharedEvents.EventId ,
                                        dbo.SharedEvents.UserId                                     
                                    From
                                        dbo.SharedEvents                                     
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
                SharedEventsData sharedEventData = new SharedEventsData();
                var shevent = sharedEventData.GetNewestSharedEvent();
                context.Clients.Group(shevent.sharable).showAlertNotification(shevent.eventname,shevent.owner);
            }
            //Call the RegisterNotification method again
            RegisterNotification();
        }
    }
}