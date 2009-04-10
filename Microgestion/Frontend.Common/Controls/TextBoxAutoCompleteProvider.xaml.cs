using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace Blackspot.Microgestion.Frontend.Common.Controls
{
    public delegate IEnumerable AutoCompleteEventHandler(string text, int maxResults);

    /// <summary>
    /// Interaction logic for TextBoxAutoCompleteProvider.xaml
    /// </summary>
    public partial class TextBoxAutoCompleteProvider : UserControl, INotifyPropertyChanged
    {
        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TextBoxAutoCompleteProvider));

        // Provide CLR accessors for the event
        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        private void RaiseSelectionChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TextBoxAutoCompleteProvider.SelectionChangedEvent);
            RaiseEvent(newEventArgs);
        }
        protected void OnSelectionChanged()
        {
            RaiseSelectionChangedEvent();
        }
        #region Properties



        #region MovesFocus Dep Prop
        public bool MovesFocus
        {
            get { return (bool)GetValue(MovesFocusProperty); }
            set { SetValue(MovesFocusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MoveFocus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MovesFocusProperty =
            DependencyProperty.Register("MovesFocus", typeof(bool), typeof(TextBoxAutoCompleteProvider), new UIPropertyMetadata(true));
        #endregion

        #region TargetControl Dep Prop
        public TextBox TargetControl
        {
            get { return (TextBox)GetValue(TargetControlProperty); }
            set { SetValue(TargetControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetControl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetControlProperty =
            DependencyProperty.Register("TargetControl",
                                        typeof(TextBox),
                                        typeof(TextBoxAutoCompleteProvider),
                                        new UIPropertyMetadata(null,
                                                    new PropertyChangedCallback(TargetControl_Changed)),
                                                    new ValidateValueCallback(TargetControl_Validate)
                                        );
        private static bool TargetControl_Validate(object value)
        {
            TextBox newv = value as TextBox;
            if (newv == null && value != null) return false;
            return true;
        }

        private static void TargetControl_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue)
            {
                TextBoxAutoCompleteProvider me = d as TextBoxAutoCompleteProvider;
                TextBox oldv = e.OldValue as TextBox;
                TextBox newv = e.NewValue as TextBox;
                if (oldv != null)
                {
                    oldv.LostFocus -= new RoutedEventHandler(me.TargetControl_LostFocus);
                    oldv.GotFocus -= new RoutedEventHandler(me.TargetControl_GotFocus);
                    oldv.KeyUp -= new KeyEventHandler(me.TargetControl_KeyUp);
                    oldv.PreviewKeyUp -= new KeyEventHandler(me.TargetControl_PreviewKeyUp);
                    oldv.PreviewKeyDown -= new KeyEventHandler(me.TargetControl_PreviewKeyDown);
                }
                if (newv != null)
                {
                    me.pop.PlacementTarget = newv;
                    newv.LostFocus += new RoutedEventHandler(me.TargetControl_LostFocus);
                    newv.GotFocus += new RoutedEventHandler(me.TargetControl_GotFocus);
                    newv.KeyUp += new KeyEventHandler(me.TargetControl_KeyUp);
                    newv.PreviewKeyUp += new KeyEventHandler(me.TargetControl_PreviewKeyUp);
                    newv.PreviewKeyDown += new KeyEventHandler(me.TargetControl_PreviewKeyDown);
                }
            }
        }

        private void TargetControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab && lstBox.SelectedItem != null)
            {
                pop.IsOpen = false;
                TargetControl.Text = String.IsNullOrEmpty(DisplayMemberPath) ?
                                     lstBox.SelectedItem.ToString() :
                                     lstBox.SelectedItem.GetType().GetProperty(
                                     DisplayMemberPath).GetValue(lstBox.SelectedItem, null).ToString();
                if (MovesFocus)
                    TargetControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                e.Handled = true;
            }
        }

        private void TargetControl_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                pop.IsOpen = false;
                lstBox.SelectedItem = null;
                e.Handled = true;
            }
            if (IsTextChangingKey(e.Key))
            {
                Suggest();
            }
        }

        private bool IsTextChangingKey(Key key)
        {
            if (key == Key.Back || key == Key.Delete)
                return true;
            else
            {
                int keyValue = (int)key;

                return 
                    (keyValue >= 34 && keyValue <= 69) // 0-9-A-Z
                    ||
                    (keyValue >= 74 && keyValue <= 83); // 0-9
            }
        }

        private void TargetControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (lstBox.SelectedIndex > 0)
                {
                    lstBox.SelectedIndex--;
                }
            }
            if (e.Key == Key.Down)
            {
                if (lstBox.SelectedIndex < lstBox.Items.Count - 1)
                {
                    lstBox.SelectedIndex++;
                }
            }
            if (e.Key == Key.Enter)
            {
                pop.IsOpen = false;
                if (lstBox.SelectedItem != null)
                {
                    TargetControl.Text = String.IsNullOrEmpty(DisplayMemberPath) ?
                                         lstBox.SelectedItem.ToString() :
                                         lstBox.SelectedItem.GetType().GetProperty(
                                            DisplayMemberPath).GetValue(lstBox.SelectedItem, null).ToString();
                }
                if (MovesFocus)
                    TargetControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        private void TargetControl_GotFocus(object sender, RoutedEventArgs e)
        {
            Suggest();
        }

        private void TargetControl_LostFocus(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
        }

        private void Suggest()
        {
            // Skip if TargetControl are not defined or if not enough characters typed
            if (TargetControl == null) return;
            if (TargetControl.Text.Length < MinTypedCharacters)
            {
                pop.IsOpen = false;
                lstBox.ItemsSource = null;
                return;
            }
            if (SearchMethod == null) throw new NullReferenceException("SeachMethod cannot be null.");

            IEnumerable res = SearchMethod(TargetControl.Text, MaxResults);

            lstBox.ItemsSource = res;
            if (lstBox.Items.Count > 0)
            {
                lstBox.SelectedIndex = 0;
            }

            pop.VerticalOffset = TargetControl.ActualHeight;
            pop.IsOpen = true;
        }

        #endregion

        #region MinTypedCharacters Dep Prop
        public int MinTypedCharacters
        {
            get { return (int)GetValue(MinTypedCharactersProperty); }
            set { SetValue(MinTypedCharactersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinTypedCharacters.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinTypedCharactersProperty =
            DependencyProperty.Register("MinTypedCharacters",
                                        typeof(int),
                                        typeof(TextBoxAutoCompleteProvider),
                                        new UIPropertyMetadata(3),
                                        new ValidateValueCallback(Validate_MinTypedCharacters));


        private static bool Validate_MinTypedCharacters(object value)
        {
            if (!(value is int)) return false;

            int ival = Convert.ToInt32(value);

            if (ival < 0) return false;

            return true;
        }
        #endregion

        #region MaxResults Dep Prop
        public int MaxResults
        {
            get { return (int)GetValue(MaxResultsProperty); }
            set { SetValue(MaxResultsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinTypedCharacters.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxResultsProperty =
            DependencyProperty.Register("MaxResults",
                                        typeof(int),
                                        typeof(TextBoxAutoCompleteProvider),
                                        new UIPropertyMetadata(10),
                                        new ValidateValueCallback(Validate_MaxResults));


        private static bool Validate_MaxResults(object value)
        {
            if (!(value is int)) return false;

            int ival = Convert.ToInt32(value);

            if (ival <= 0) return false;

            return true;
        }
        #endregion

        #region AvailableSuggestions

        public int AvailableSuggestions
        {
            get { return lstBox.Items.Count; }
        }

        #endregion

        public AutoCompleteEventHandler SearchMethod { get; set; }

        #region Other props
        public string DisplayMemberPath
        {
            get { return lstBox.DisplayMemberPath; }
            set { lstBox.DisplayMemberPath = value; }
        }

        public string SelectedValuePath
        {
            get { return lstBox.SelectedValuePath; }
            set { lstBox.SelectedValuePath = value; }
        }

        public DataTemplate ItemTemplate
        {
            get { return lstBox.ItemTemplate; }
            set { lstBox.ItemTemplate = value; }
        }

        public ItemsPanelTemplate ItemsPanel
        {
            get { return lstBox.ItemsPanel; }
            set { lstBox.ItemsPanel = value; }
        }

        public DataTemplateSelector ItemTemplateSelector
        {
            get { return lstBox.ItemTemplateSelector; }
            set { lstBox.ItemTemplateSelector = value; }
        }

        public object SelectedItem
        {
            get { return lstBox.SelectedItem; }
            set { lstBox.SelectedItem = value; NotifyPropertyChanged("SelectedItem"); }
        }

        public object SelectedValue
        {
            get { return lstBox.SelectedValue; }
            set { lstBox.SelectedValue = value; NotifyPropertyChanged("SelectedValue"); }
        }

        public PopupAnimation PopupAnimation
        {
            get { return pop.PopupAnimation; }
            set { pop.PopupAnimation = value; }
        }

        #endregion
        #endregion

        //  public event UsedSuggestedItemHandler UsedSuggestedItem;

        public TextBoxAutoCompleteProvider()
        {
            InitializeComponent();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void lstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NotifyPropertyChanged("SelectedItem");
            NotifyPropertyChanged("SelectedValue");
            RaiseSelectionChangedEvent();
        }
    }
}
