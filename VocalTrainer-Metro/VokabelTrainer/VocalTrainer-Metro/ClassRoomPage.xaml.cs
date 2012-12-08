using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace VocalTrainer_Metro
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ClassRoomPage : VocalTrainer_Metro.Common.LayoutAwarePage
    {
        private string classroomID = string.Empty;

        public ClassRoomPage()
        {
            this.InitializeComponent();
            
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            
        }

        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.classroomID = e.Parameter as string;
            this.pageTitle.Text = classroomID;
        }
    }
}
