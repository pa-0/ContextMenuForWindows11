﻿using ContextMenuCustomApp.Service.Menu;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ContextMenuCustomApp.View.Menu
{
    public sealed partial class DirectoryMatchCheckbox : UserControl
    {
        public DirectoryMatchCheckbox()
        {
            this.InitializeComponent();
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(int), typeof(DirectoryMatchCheckbox), new PropertyMetadata(0, (o, v) =>
        {
            var self = (DirectoryMatchCheckbox)o;
            if (v.NewValue is int value)
            {
                self.DirectoryCheckbox.IsChecked = (value & (int)DirectoryMatchFlagEnum.Directory) == (int)DirectoryMatchFlagEnum.Directory;
                self.BackgroundCheckbox.IsChecked = (value & (int)DirectoryMatchFlagEnum.Background) == (int)DirectoryMatchFlagEnum.Background;
                self.DesktopCheckbox.IsChecked = (value & (int)DirectoryMatchFlagEnum.Desktop) == (int)DirectoryMatchFlagEnum.Desktop;
            }
            else
            {
                self.DirectoryCheckbox.IsChecked = false;
                self.BackgroundCheckbox.IsChecked = false;
                self.DesktopCheckbox.IsChecked = false;
            }
        }));

        private void Checkbox_Click(object sender, RoutedEventArgs e)
        {
            this.Value = (DirectoryCheckbox.IsChecked == true ? (int)DirectoryMatchFlagEnum.Directory : 0)
                | (BackgroundCheckbox.IsChecked == true ? (int)DirectoryMatchFlagEnum.Background : 0)
                | (DesktopCheckbox.IsChecked == true ? (int)DirectoryMatchFlagEnum.Desktop : 0);
        }
    }
}
