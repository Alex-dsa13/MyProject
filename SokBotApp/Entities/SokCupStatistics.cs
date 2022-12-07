using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SokBotApp.Entities
{
    public class SokCupStatistics : SokCup, INavigate
    {

        public SokCupStatistics()
        {

        }

        public Page NavigateTo()
        {
            var nav = new SokCupStatisticsPage(this);
            return nav;
        }
    }
}
