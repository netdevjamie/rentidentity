using System.ComponentModel;

namespace RentIdentity.Data
{
    public class Enums
    {
        public enum UserType
        {
            Admin,
            Broker,
            Landlord,
            Tenant,
            Api,
            Developer
        }
        public enum ProfileRating
        {
            Premium,
            Complete,
            Unfinished,
        }
        public enum HomeType
        {
            [Description("House")]
            House,
            [Description("Apartment")]
            Apartment,
            [Description("Condo")]
            Condo,
        }

        public enum LeaseDuration
        {

            [Description("One Year")]
            OneYear,
            [Description("Six Month")]
            SixMonth,
            [Description("Month-to-Month")]
            MonthToMonth
        }

        public enum Gender
        {
            [Description("Female")]
            Female,
            [Description("Male")]
            Male
        }

        public enum State
        {
            AL,
            [Description("Alaska")]
            AK,
            [Description("Arkansas")]
            AR,
            [Description("Arizona")]
            AZ,
            [Description("California")]
            CA,
            [Description("Colorado")]
            CO,
            [Description("Connecticut")]
            CT,
            [Description("D.C.")]
            DC,
            [Description("Delaware")]
            DE,
            [Description("Florida")]
            FL,
            [Description("Georgia")]
            GA,
            [Description("Hawaii")]
            HI,
            [Description("Iowa")]
            IA,
            [Description("Idaho")]
            ID,
            [Description("Illinois")]
            IL,
            [Description("Indiana")]
            IN,
            [Description("Kansas")]
            KS,
            [Description("Kentucky")]
            KY,
            [Description("Louisiana")]
            LA,
            [Description("Massachusetts")]
            MA,
            [Description("Maryland")]
            MD,
            [Description("Maine")]
            ME,
            [Description("Michigan")]
            MI,
            [Description("Minnesota")]
            MN,
            [Description("Missouri")]
            MO,
            [Description("Mississippi")]
            MS,
            [Description("Montana")]
            MT,
            [Description("North Carolina")]
            NC,
            [Description("North Dakota")]
            ND,
            [Description("Nebraska")]
            NE,
            [Description("New Hampshire")]
            NH,
            [Description("New Jersey")]
            NJ,
            [Description("New Mexico")]
            NM,
            [Description("Nevada")]
            NV,
            [Description("New York")]
            NY,
            [Description("Oklahoma")]
            OK,
            [Description("Ohio")]
            OH,
            [Description("Oregon")]
            OR,
            [Description("Pennsylvania")]
            PA,
            [Description("Rhode Island")]
            RI,
            [Description("South Carolina")]
            SC,
            [Description("South Dakota")]
            SD,
            [Description("Tennessee")]
            TN,
            [Description("Texas")]
            TX,
            [Description("Utah")]
            UT,
            [Description("Virginia")]
            VA,
            [Description("Vermont")]
            VT,
            [Description("Washington")]
            WA,
            [Description("Wisconsin")]
            WI,
            [Description("West Virginia")]
            WV,
            [Description("Wyoming")]
            WY
        }
    }
}