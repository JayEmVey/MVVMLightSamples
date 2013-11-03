// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   This class contains properties that the main View can data bind to.
//   <para>
//   Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
//   </para>
//   <para>
//   You can also use Blend to data bind with the tool's support.
//   </para>
//   <para>
//   See http://www.galasoft.ch/mvvm
//   </para>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MVVMLightSample.ViewModel
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using Model;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The person
        /// </summary>
        private Person _person;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                _person = new Person { Name = "Sara", Age = 30 };
            }
            else
            {
                // Code runs "for real"
                _person = new Person { Name = "Mary", Age = 35 };
            }

            PropertyChanged += MainViewModel_PropertyChanged;
            ShowMessageCommand = new RelayCommand(ShowMessage);
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                Set("Person", ref _person, value);
            }
        }

        /// <summary>
        /// Gets the show message command.
        /// </summary>
        /// <value>
        /// The show message command.
        /// </value>
        public ICommand ShowMessageCommand { get; private set; }

        /// <summary>
        /// Unregisters this instance from the Messenger class.
        /// <para>To cleanup additional resources, override this method, clean
        /// up and then call base.Cleanup().</para>
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
            PropertyChanged -= MainViewModel_PropertyChanged;
        }

        /// <summary>
        /// Handles the PropertyChanged event of the MainViewModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Person")
            {
                //Do someting if necessary
            }
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        private void ShowMessage()
        {
            Messenger.Default.Send("This is a message.");
        }
    }
}