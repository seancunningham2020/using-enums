using System.ComponentModel;
using System.Web.Mvc;

namespace UsingEnums.Models
{
    public class MainPageViewModel
    {
        public int SelectedUserAction { get; set; }

        [DisplayName("User Actions")]
        public SelectList UserActions { get; set; }
    }
}