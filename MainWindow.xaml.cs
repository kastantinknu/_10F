using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class CommandSlider : Slider, ICommandSource
    {
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandSlider), new UIPropertyMetadata(null));

        //public object CommandParameter { get; }
        public IInputElement CommandTarget { get; }

        private EventHandler canExecuteChangedHandler;
        public CommandSlider() : base()
        {


        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(CommandSlider),
                new PropertyMetadata((ICommand)null,
                    new PropertyChangedCallback(CommandChanged)));

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        // Command dependency property change callback.
        private static void CommandChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            CommandSlider cs = (CommandSlider)d;
            cs.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }
        // Add a new command to the Command Property.
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            // If oldCommand is not null, then we need to remove the handlers.
            if (oldCommand != null)
            {
                RemoveCommand(oldCommand, newCommand);
            }
            AddCommand(oldCommand, newCommand);
        }

        // Remove an old command from the Command Property.
        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }

        // Add the command.
        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            canExecuteChangedHandler = handler;
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += canExecuteChangedHandler;
            }
        }
        private void CanExecuteChanged(object sender, EventArgs e)
        {

            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;

                // If a RoutedCommand.
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
                // If a not RoutedCommand.
                else
                {
                    if (Command.CanExecute(CommandParameter))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
            }
        }
        // If Command is defined, moving the slider will invoke the command;
        // Otherwise, the slider will behave normally.
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            if (this.Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;

                if (command != null)
                {
                    command.Execute(CommandParameter, CommandTarget);
                }
                else
                {
                    ((ICommand)Command).Execute(CommandParameter);
                }
            }
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
