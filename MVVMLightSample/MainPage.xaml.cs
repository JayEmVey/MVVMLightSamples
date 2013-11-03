namespace MVVMLightSample
{
    using System.Windows;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Defines the main page
    /// </summary>
    public partial class MainPage 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Messenger.Default.Register<string>(this, ShowMessage);
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}