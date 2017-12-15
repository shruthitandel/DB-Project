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
        public String userlogin(string username, string password)
        {

            String name = d.userlogin(username, password);
            return name;
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
        public DataTable GetArtistTracks(string artistid)
        {
            DataTable dt = d.GetArtistTracks(artistid);
            return dt;
        }
        public int likeArtist(string artistid, string username, DateTime datetoday)
        {
            int a = d.likeArtist(artistid, username, datetoday);
            return a;
        }
        public int checkIfLikeExist(string artistid, string username)
        {
            int a = d.checkIfLikeExist(artistid, username);
            return a;
        }
        public int dislikeArtist(string artistid, string username)
        {
            int a = d.dislikeArtist(artistid, username);
            return a;
        }
        public DataTable GetAlbumTracks(string albumid)
        {
            DataTable dt = d.GetAlbumTracks(albumid);
            return dt;
        }

        public DataTable GetPlaylistFromCurrentUser(String username)
        {
            DataTable dt = d.GetPlaylistFromCurrentUser(username);
            return dt;
        }

        public DataTable GetUserFromCurrentPlaylist(String username)
        {
            DataTable dt = d.GetUserFromCurrentPlaylist(username);
            return dt;
        }

        public DataTable GetRecentlyPlayedTracks(String username)
        {
            DataTable dt = d.GetRecentlyPlayedTracks(username);
            return dt;
        }
        

        public DataTable GetAllPlaylist(String username)
        {
            DataTable dt = d.GetAllPlaylist(username);
            return dt;
        }

        public DataTable GetNewAlbums()
        {
            DataTable dt = d.GetNewAlbums();
            return dt;
        }

        public DataTable GetRecentTrackReleasedByLikedArtist(String username)
        {
            DataTable dt = d.GetRecentTrackReleasedByLikedArtist(username);
            return dt;
        }

        public DataTable GetUserDetail(String username)
        {
            DataTable dt = d.GetUserDetail(username);
            return dt;
        }

        public DataTable GetPlaylistTracks(int playlistid)
        {
            DataTable dt = d.GetPlaylistTracks(playlistid);
            return dt;
        }
        public int createplaylist(string username, string playlisttype, string playlisttitle, DateTime todaydate, string trackid)
        {
            int result = d.createplaylist(username, playlisttype, playlisttitle, todaydate, trackid);
            return result;
        }
        public DataTable getPlaylist(string username)
        {
            DataTable dt = d.GetPlaylist(username);
            return dt;

        }
        public int addinplaylist(int playlistid, string trackid)
        {
            int result = d.addinplaylist(playlistid, trackid);
            return result;
        }
        public void addinsongplayed(DataTable dt, string albumid, string username)
        {
            d.addinsongplayed(dt, albumid, username);

        }
        public void addinsongplayedplay(DataTable dt, int playlistid, string username)
        {
            d.addinsongplayedplay(dt, playlistid, username);

        }

        public int ratetrack(string username, string trackid, int rating, DateTime ratedate)
        {
            int result = d.ratetrack(username, trackid, rating, ratedate);
            return result;
        }
        public int getrating(string username, string trackid)
        {
            int result = d.getrating(username, trackid);
            return result;
        }
        public int updateratetrack(string username, string trackid, int rating, DateTime ratedate)
        {
            int result = d.updateratetrack(username, trackid, rating, ratedate);
            return result;
        }

        public DataTable GetUsersDetailsByKeyword(string username)
        {
            DataTable dt = d.GetUsersDetailsByKeyword(username);
            return dt;

        }

        public int followUser(string currentusername, string usernametobefollowed)
        {
            int result = d.followUser(currentusername, usernametobefollowed);
            return result;
        }

        public int unFollowUser(string currentusername, string usernametobeunfollowed)
        {
            int result = d.unFollowUser(currentusername, usernametobeunfollowed);
            return result;
        }

        public int updateUserDetails(string username, string name, string email, string city)
        {
            int result = d.updateUserDetails(username,name,email,city);
            return result;
        }

        public int checkIfFollowExists(string currentusername, string usernametobefollowed)
        {
            int result = d.checkIfFollowExist(currentusername, usernametobefollowed);
            return result;
        }

        public void addsongplayed(string username, string trackid, DateTime todaydate)
        {
            d.addsongplayed(username, trackid, todaydate);
        }
        public void addsongplayed(string username, string trackid, int playlistid, DateTime todaydate)
        {
            d.addsongplayed(username, trackid, playlistid, todaydate);
        }
        public void addsongplayed(string username, string trackid, string albumid, DateTime todaydate)
        {
            d.addsongplayed(username, trackid, albumid, todaydate);
        }

    }
}
