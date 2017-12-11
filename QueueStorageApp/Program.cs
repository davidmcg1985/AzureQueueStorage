using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace QueueStorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnection"));

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("tasks");

            queue.CreateIfNotExists();

            //CloudQueueMessage message = new CloudQueueMessage("Hello World");
            //var time = new TimeSpan(24, 0, 0);         
            //queue.AddMessage(message, time, null);

            CloudQueueMessage message = queue.GetMessage();
            Console.WriteLine(message.AsString);
            queue.DeleteMessage(message);

            //CloudQueueMessage message = queue.PeekMessage();
            //Console.WriteLine(message.AsString);

            Console.ReadKey();
        }
    }
}
