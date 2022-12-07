using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SokBotApp.Entities
{
    public class CupFirstCourseStatistics : CupFirstCourse, INavigate
    {

        public CupFirstCourseStatistics()
        {

        }


        public Page NavigateTo()
        {
            var nav = new EventStatistics(this);
            return nav;
        }
    }
}
