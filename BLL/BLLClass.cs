using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BO;
using System.Collections;
using System.Data;

namespace BLL
{
    public class BLLClass
    {
        DALClass d = new DALClass();
        public int userlogin(string username, string password)
        {

            int a = d.userlogin(username, password);
            return a;
        }

        public int insertuserdetails(string name, string email, string username, string password, string city)
        {
            int result = d.insertuserdetails(name, email, username, password, city);
            return result;
        }

        public DataTable GetTracksByKeyword(string keyword, string username)
        {
            DataTable dt = d.GetTracksByKeyword(keyword, username);
            return dt;
        }

        public DataTable GetArtistsByKeyword(string keyword)
        {
            DataTable dt = d.GetArtistsByKeyword(keyword);
            return dt;
        }

        public DataTable GetAlbumsByKeyword(string keyword)
        {
            DataTable dt = d.GetAlbumsByKeyword(keyword);
            return dt;
        }
        public DataTable GetPlayListByKeyword(string keyword, string username)
        {
            DataTable dt = d.GetPlayListByKeyword(keyword, username);
            return dt;
        }
        public DataTable GetArtistTracks(int artistid)
        {
            DataTable dt = d.GetArtistTracks(artistid);
            return dt;
        }
        public int likeArtist(int artistid, string username, DateTime datetoday)
        {
            int a = d.likeArtist(artistid, username, datetoday);
            return a;
        }
        public int checkIfLikeExist(int artistid, string username)
        {
            int a = d.checkIfLikeExist(artistid, username);
            return a;
        }
        public int dislikeArtist(int artistid, string username)
        {
            int a = d.dislikeArtist(artistid, username);
            return a;
        }
        public DataTable GetAlbumTracks(int artistid)
        {
            DataTable dt = d.GetAlbumTracks(artistid);
            return dt;
        }
    }
}
