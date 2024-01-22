using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Entities
{
    public partial class Service
    {
        public int Duration
        {
            get
            {
                return DurationInSeconds / 60;
            }
        }

        public string DiscountText
        {
            get
            {
                var text = "";
                if (Discount != null)
                    text = $"* скидка {Discount * 100}%";
                return text;
            }
        }

        public string CostText
        {
            get
            {
                var text = "";
                if (Discount != null)
                    text = (Convert.ToInt32(Cost)*(1-Discount)).ToString();
                else
                    text = Cost.ToString("0");
                return text;
            }
        }
        
        public string LastCost
        {
            get
            {
                var text = "";
                if (Discount != null)
                    text = Cost.ToString("0");
                return text;
            }
        }
    }
}
