namespace BLL;
using BOL;
using DAL;
public class Usermanager
{
    public List<User> GetAllUsers(){
        List<User> allusers=new List<User>();
        allusers=DBMgr.Getalluserslist();
        return allusers;
    }

    public static void InsertUser(User user){
        DBMgr.InsertUser(user);
    }
}
