namespace MongoDBChat
{
    using MongoDB.Driver;
    using System;
    using System.Windows;
    using MongoDBData;
    using System.Windows.Threading;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "mongodb://user:pass@ds052837.mongolab.com:52837/chat";

        private DateTime signedInTimeUTC;
        private User user;
        private MongoDatabase chatDb;

        public MainWindow()
        {
            InitializeComponent();

            this.signedInTimeUTC = DateTime.Now.ToUniversalTime();

            this.chatDb = GetChatDatabase(ConnectionString);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += ShowMessages;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private MongoDatabase GetChatDatabase(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            this.user = new User { Name = "Anonymous" };
            return server.GetDatabase("chat");
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            string username = this.username.Text;
            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters.");
            }
            else
            {
                MessageBox.Show("You logged in successfully.");
                this.user = new User { Name = this.username.Text };
            }
        }

        public void ShowMessages(object sender, EventArgs e)
        {
            var lastMessagesQuery = Query<Message>.Where(msg => msg.PostDate > this.signedInTimeUTC);
            var messages = chatDb.GetCollection<Message>("messages").Find(lastMessagesQuery);

            foreach (var msg in messages)
            {
                string text = string.Format("[{0}] {1}: {2}", msg.PostDate.ToLocalTime(), msg.User.Name, msg.Text);

                if (!this.LbMsgs.Items.Contains(text))
                {
                    this.LbMsgs.Items.Add(text);
                }
            }
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            var textBox = TbNewMsg;

            Message newMessage = new Message
            {
                Text = textBox.Text,
                PostDate = DateTime.Now,
                User = this.user
            };

            var messages = this.chatDb.GetCollection<Message>("messages");
            messages.Insert(newMessage);

            textBox.Clear();
        }
    }
}
