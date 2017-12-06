using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class BOClass
    {
        
            private string username;
            private string password;
            private string name;
            private string emailid;
            private string city;
            private string trackTitle;
            private string artistName;
            private string trackDuration;



            public string Username
            {
                get { return username; }
                set { username = value; }
            }
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string EmailID
            {
                get { return emailid; }
                set { emailid = value; }
            }

            public string City
            {
                get { return city; }
                set { city = value; }
            }

            public string TrackTitle
            {
                get { return trackTitle; }
                set { trackTitle = value; }
            }
            public string ArtistName
            {
                get { return artistName; }
                set { artistName = value; }
            }
            public string TrackDuration
            {
                get { return trackDuration; }
                set { trackDuration = value; }
            }



    }
    }

