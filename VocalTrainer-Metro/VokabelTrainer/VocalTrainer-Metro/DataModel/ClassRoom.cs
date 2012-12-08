using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace VocalTrainer_Metro.DataModel
{
    public class ClassRoom //: VocalTrainer_Metro.Common.BindableBase
    {
        private static Uri baseUri = new Uri("ms-appx:///");
        private string uniqueId = string.Empty;
        private string title = string.Empty;
        private string subtitle = string.Empty;
        private string description = string.Empty;
        private ImageSource image = null;
        private string imagePath = string.Empty;
        private List<Translation> translations = new List<Translation>();

        #region "Getters and Setters"

        public List<Translation> Translations
        {
            get { return this.translations; }
            set { this.translations = value; }
        }

        public string UniqueId
        {
            get { return this.uniqueId; }
            set { this.uniqueId = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Subtitle
        {
            get { return this.subtitle; }
            set { this.subtitle = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public ImageSource Image
        {
            get
            {
                if (this.image == null && this.imagePath != null)
                {
                    this.image = new BitmapImage(new Uri(ClassRoom.baseUri, this.imagePath));
                }
                return this.image;
            }
            set
            {
                this.imagePath = null;
                this.image = value;
            }
        }

        public void SetImage(String path)
        {
            this.image = null;
            this.imagePath = path;
        }

        public override string ToString()
        {
            return this.Title;
        }

        #endregion

        public ClassRoom()
        {
            //empty.
        }

        public ClassRoom(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.uniqueId = uniqueId;
            this.title = title;
            this.subtitle = subtitle;
            this.description = description;
            this.imagePath = imagePath;
        }

    }
}
